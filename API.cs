using System.Text.Json;
using DotNetEnv;
using Newtonsoft.Json;
using TextImprove.ApiResponses;

namespace TextImprove
{
	public class API
	{
		public static async Task<GrammarAndSpellCheck?> SendText(string contents)
		{
            Env.Load();
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");

            if (!string.IsNullOrEmpty(apiKey))
            {
                GrammarAndSpellCheck? response = await GetImprovedText(apiKey, contents);

                if (response != null)
                {
                    return response;
                }

                return null;
            }

            Interface.DisplayError("No API key found");
            return null;
        }

        static async Task<GrammarAndSpellCheck?> GetImprovedText(string key, string contents)
        {
            string choice = CheckInput.CheckChoiceInput();

            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "textgears-textgears-v1.p.rapidapi.com");

            HttpResponseMessage response = await client.PostAsync($"https://textgears-textgears-v1.p.rapidapi.com/{choice}",
                new FormUrlEncodedContent(new Dictionary<string, string> {
                        {
                            "text", contents
                        }
                })
            );

            if (response.IsSuccessStatusCode)
            {
                Interface.DisplayMessage("API returned 200");
                string content = await response.Content.ReadAsStringAsync();

                GrammarAndSpellCheck? checkDeserialized = JsonConvert.DeserializeObject<GrammarAndSpellCheck>(content);

                if (checkDeserialized == null)
                    return null;

                return checkDeserialized;
            }
            else
            {
                Interface.DisplayError("Error fetching response: " + response.ReasonPhrase);
                return null;
            }
        }
    }
}

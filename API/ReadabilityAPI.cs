using System.Text.Json;
using DotNetEnv;
using Newtonsoft.Json;
using TextImprove.ApiResponses;

namespace TextImprove
{
    public class ReadabilityAPI
    {
        public static async Task<ReadabilityCheckModel?> SendText(string contents, string? apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                ReadabilityCheckModel? response = await GetImprovedText(apiKey, contents);

                if (response != null)
                {
                    return response;
                }

                return null;
            }

            Interface.DisplayError("No API key found");
            return null;
        }

        static async Task<ReadabilityCheckModel?> GetImprovedText(string key, string contents)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "textgears-textgears-v1.p.rapidapi.com");

            HttpResponseMessage response = await client.PostAsync($"https://textgears-textgears-v1.p.rapidapi.com/readability",
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

                ReadabilityCheckModel? checkDeserialized = JsonConvert.DeserializeObject<ReadabilityCheckModel>(content);

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

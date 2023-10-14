using System;
using dotenv.net;

namespace TextImprove
{
	public class API
	{
		public static async Task<string?> SendText()
		{
            DotEnv.Load();
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");

            if (!string.IsNullOrEmpty(apiKey))
            {
                string? response = await GetImprovedText(apiKey);

                if (!string.IsNullOrEmpty(response))
                    return response;

                Console.WriteLine("No response recieved");
                return null;
            }

            Console.WriteLine("No API key found");
            return null;
        }

        static async Task<string?> GetImprovedText(string key)
        {
            Console.WriteLine("What do you want to do with the text?");
            Console.WriteLine("Press 1 for readability check");
            Console.WriteLine("Press 2 for spelling check");
            Console.WriteLine("Press 3 for grammar check");

            bool validInput = false;
            int inputInt;
            string choice = "";

            while (!validInput)
            {
                string? input = Console.ReadLine();

                if (input != null && int.TryParse(input, out inputInt))
                {
                    switch (inputInt)
                    {
                        case 1:
                            choice = "readability";
                            validInput = true;
                            break;

                        case 2:
                            choice = "spelling";
                            validInput = true;
                            break;

                        case 3:
                            choice = "grammar";
                            validInput = true;
                            break;

                        default:
                            Console.WriteLine("Invalid input, please enter a number between 1 and 3");
                            continue;
                    }
                }
            }

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "textgears-textgears-v1.p.rapidapi.com");

                HttpResponseMessage response = await client.GetAsync($"https://textgears-textgears-v1.p.rapidapi.com/{choice}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    return null;
                }
                else
                {
                    Console.WriteLine("Error fetching response: " + response.ReasonPhrase);
                    return null;
                }
            }
        }
    }
}

public class ApiResponse
{
    public required string Word { get; set; }
}

﻿using DotNetEnv;
using TextImprove.ApiResponses;
using TextImprove.Tools;
using Xceed.Words.NET;

namespace TextImprove;

class Program
{
    static async Task Main(string[] args)
    {
       Interface.DisplayMessage("Please enter the path of the file you wish to improve: ");

        Env.Load();
        string? apiKey = Environment.GetEnvironmentVariable("API_KEY");

        bool validInput = false;
        string filePath = "";
        string fileContents;

        ReadabilityCheckModel? readabilityCheckResult;
        GrammarAndSpellCheckModel? grammarAndSpellCheckResult;

        while (!validInput)
        {
            string? input = Console.ReadLine();
            if (input != null)
            {
                filePath = input;
                validInput = true;
            }
        }

        try
        {
            string suffix = Path.GetExtension(filePath);

            if (suffix.Equals(".docx"))
                fileContents = ExtractText.ExtractDocx(filePath);
            else
                fileContents = File.ReadAllText(filePath);

            Interface.DisplayMessage("Contents read successfully");

            string choice = CheckInput.CheckChoiceInput();

            if (choice.Equals("readability"))
            {
                readabilityCheckResult = await ReadabilityAPI.SendText(fileContents, apiKey);
                if (readabilityCheckResult != null)
                    HandleResult.HandleReadabilityResult(readabilityCheckResult);
                else
                    Interface.DisplayError("Recieved null from API");
            } else
            {
                grammarAndSpellCheckResult = await GrammarAndSpellAPI.SendText(fileContents, choice, apiKey);
                if (grammarAndSpellCheckResult != null)
                    HandleResult.HandleGrammarAndSpellResult(grammarAndSpellCheckResult);
                else
                    Interface.DisplayError("Recieved null from API");
            }
        } catch (FileNotFoundException)
        {
            Interface.DisplayError("No file found at given path");
        } catch (Exception ex)
        {
            Interface.DisplayError($"An error occured: {ex}");
        }   
    }
}


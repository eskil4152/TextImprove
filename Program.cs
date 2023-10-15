using DotNetEnv;
using TextImprove.ApiResponses;

namespace TextImprove;

class Program
{
    static async Task Main(string[] args)
    {
       Interface.DisplayMessage("Please enter the path of the file you wish to improve: ");

        bool validInput = false;
        string filePath = "";

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
            string fileContents = File.ReadAllText(filePath);
            Interface.DisplayMessage("Contents read successfully");

            GrammarAndSpellCheck? result = await API.SendText(fileContents);

            if (result != null)
            {
                HandleResult.Handle(result);
            } else
            {
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


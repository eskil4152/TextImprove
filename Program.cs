using DotNetEnv;
using TextImprove.ApiResponses;
using Xceed.Words.NET;

namespace TextImprove;

class Program
{
    static async Task Main(string[] args)
    {
       Interface.DisplayMessage("Please enter the path of the file you wish to improve: ");

        bool validInput = false;
        string filePath = "";
        string fileContents;

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
                fileContents = ExtractTextFromDocx(filePath);
            else
                fileContents = File.ReadAllText(filePath);

            Console.WriteLine("Content: " + fileContents);

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

    static string ExtractTextFromDocx(string path)
    {
        using DocX doc = DocX.Load(path);
        return doc.Text;
    }

}


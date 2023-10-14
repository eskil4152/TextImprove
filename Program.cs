namespace TextImprove;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the path of the file you wish to improve: ");

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
            Console.WriteLine("File Contents: ");
            Console.WriteLine(fileContents);

        } catch (FileNotFoundException)
        {
            Console.WriteLine("No file found at given path");
        } catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex}");
        }
        
    }
}


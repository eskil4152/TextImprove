using System;
namespace TextImprove
{
	public class CheckInput
	{
		public static string CheckChoiceInput()
		{
            bool validInput = false;
            string choice = "";
            int inputInt;

            Interface.DisplayMessage("What do you want to do with the text?");
            Interface.DisplayMessage("Press 1 for readability check");
            Interface.DisplayMessage("Press 2 for spelling check");
            Interface.DisplayMessage("Press 3 for grammar check");
            
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
                            Interface.DisplayError("Invalid input, please enter a number between 1 and 3");
                            continue;
                    }
                }
            }

            return choice;
        }
	}
}


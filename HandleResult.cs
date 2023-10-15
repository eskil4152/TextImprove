using System;
using TextImprove.ApiResponses;

namespace TextImprove
{
	public class HandleResult
	{
		public static void Handle(GrammarAndSpellCheck grammarAndSpellCheck)
		{
			Interface.DisplayMessage("Handled");
			
			List<Error> errors = grammarAndSpellCheck.Response.Errors;

			foreach (Error error in errors)
			{
				Interface.Spacer();

				Console.WriteLine("Bad: " + error.Bad);
				Console.WriteLine("Better alternative: ");

				foreach (string s in error.Better)
				{
					Console.WriteLine(s);
				}

				Console.WriteLine("Description: " + error.Description.En);
				Interface.DisplayMessage($"Character position {error.Offset}");
			}
		}
	}
}


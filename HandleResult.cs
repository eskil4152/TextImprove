using System;
using TextImprove.ApiResponses;

namespace TextImprove
{
	public class HandleResult
	{
		public static void Handle(GrammarAndSpellCheck grammarAndSpellCheck)
		{
			Interface.DisplayMessage("Handled");

			var status = grammarAndSpellCheck.status;
			List<Error> errors = grammarAndSpellCheck.response.errors;

			foreach (Error error in errors)
			{
				Interface.Spacer();

				Console.WriteLine("Bad: " + error.bad);
				Console.WriteLine("Better alternative: ");

				foreach (string s in error.better)
				{
					Console.WriteLine(s);
				}

				Console.WriteLine("Description: " + error.description.en);
			}
		}
	}
}


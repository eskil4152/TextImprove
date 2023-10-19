using System;
using TextImprove.ApiResponses;

namespace TextImprove
{
	public class HandleResult
	{
		public static void HandleGrammarAndSpellResult(ResultModel grammarAndSpellCheckModel)
		{
            List<Error> errors = grammarAndSpellCheckModel.Response.Errors!;

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

        public static void HandleReadabilityResult(ResultModel readabilityCheckModel)
        {
            var values = HandleValues(readabilityCheckModel);

            Interface.DisplayMessage($"Smog: {values.smog}");
            Interface.DisplayMessage($"Coleman Liau: {values.colemanLiau}");
            Interface.DisplayMessage($"Gunning Fog: {values.gunningFog}");

            Interface.DisplayMessage($"Clear Length: {values.clearLength}");
            Interface.DisplayMessage($"Length: {values.length}");
            Interface.DisplayMessage($"Sentences: {values.sentences}");
            Interface.DisplayMessage($"Words: {values.words}");

            Interface.DisplayMessage($"Positivity: {values.positive}");
            Interface.DisplayMessage($"Negatviity: {values.negative}");

            Interface.DisplayMessage($"Grade: {values.grade}");
            Interface.DisplayMessage($"Interpretations: {values.interpretation}");
            Interface.DisplayMessage($"Reading Ease: {values.readingEase}");
        }

        public static (double smog, double colemanLiau, double gunningFog,
            int clearLength, int length, int sentences, int words,
            double positive, double negative,
            string grade, string interpretation, double readingEase) HandleValues(ResultModel readabilityCheckModel)
        {
            Stats stats = readabilityCheckModel.Response.Stats!;
            Counters counters = stats.counters;
            Emotion emotion = stats.emotion;
            FleschKincaid fleschKincaid = stats.fleschKincaid;

            double smog = stats.smog;
            double colemanLiau = stats.colemanLiau;
            double gunningFog = stats.gunningFog;

            int clearLength = counters.clearLength;
            int length = counters.length;
            int sentences = counters.sentences;
            int words = counters.words;

            double positive = emotion.positive;
            double negative = emotion.negative;

            string grade = fleschKincaid.grade;
            string interpretation = fleschKincaid.interpretation;
            double readingEase = fleschKincaid.readingEase;

            return (smog, colemanLiau, gunningFog, clearLength, length, sentences, words, positive, negative, grade, interpretation, readingEase);
        }
    }
}


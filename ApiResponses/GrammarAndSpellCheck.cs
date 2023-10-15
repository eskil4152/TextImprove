using System;
namespace TextImprove.ApiResponses
{
	public class GrammarAndSpellCheck
	{
		public bool status { get; set; }
        public Response response { get; set; }
    }

    public class Response
    {
        public List<Error> errors { get; set; }
    }

    public class Error
    {
        public string bad { get; set; }
        public List<string> better { get; set; }
        public Description description { get; set; }
        public string id { get; set; }
        public int length { get; set; }
        public int offset { get; set; }
        public string type { get; set; }
    }

    public class Description
    {
        public string en { get; set; }
    }
}


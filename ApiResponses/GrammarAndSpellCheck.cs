using System;
using Newtonsoft.Json;

namespace TextImprove.ApiResponses
{
	public class GrammarAndSpellCheck
	{
        [JsonProperty("status")]
        public bool Status { get; set; } = false;

        [JsonProperty("response")]
        public Response Response { get; set; } = new Response();
    }

    public class Response
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; } = new List<Error>();
    }

    public class Error
    {
        [JsonProperty("bad")]
        public string Bad { get; set; } = "";

        [JsonProperty("better")]
        public List<string> Better { get; set; } = new List<string>();

        [JsonProperty("description")]
        public Description Description { get; set; } = new Description();

        [JsonProperty("id")]
        public string Id { get; set; } = "";

        [JsonProperty("length")]
        public int Length { get; set; } = 0;

        [JsonProperty("offset")]
        public int Offset { get; set; } = 0;

        [JsonProperty("type")]
        public string Type { get; set; } = "";
    }

    public class Description
    {
        [JsonProperty("en")]
        public string En { get; set; } = "";
    }
}


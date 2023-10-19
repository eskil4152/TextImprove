using System;
using Newtonsoft.Json;

namespace TextImprove.ApiResponses
{
	public class ResultModel
	{
        [JsonProperty("status")]
        public bool Status { get; set; } = false;

        [JsonProperty("response")]
        public Response Response { get; set; } = new Response();
    }

    public class Response
    {
        [JsonProperty("errors")]
        public List<Error>? Errors { get; set; }

        [JsonProperty("stats")]
        public Stats? Stats;
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

    public class Stats
    {
        public double smog;
        public double colemanLiau;
        public Counters counters;
        public Emotion emotion;
        public FleschKincaid fleschKincaid;
        public double gunningFog;
    }

    public class Counters
    {
        public int clearLength;
        public int length;
        public int sentences;
        public int words;
    }

    public class Emotion
    {
        public double negative;
        public double positive;
    }

    public class FleschKincaid
    {
        public string grade;
        public string interpretation;
        public double readingEase;
    }
}


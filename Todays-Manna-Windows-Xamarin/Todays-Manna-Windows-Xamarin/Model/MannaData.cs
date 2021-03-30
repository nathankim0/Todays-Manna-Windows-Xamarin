using Newtonsoft.Json;

namespace TodaysMannaWindows
{
    public class MannaData
    {
        [JsonProperty("verse")]
        public string Verse { get; set; } = "";

        [JsonProperty("contents")]
        public string[] Contents { get; set; } = { "", "" };
    }
}

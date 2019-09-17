using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class DocumentToSignResquest
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "skip_email")]
        public int SkipEmail { get; set; }

        [JsonProperty(PropertyName = "workflow")]
        public int Workflow { get; set; }
    }
}
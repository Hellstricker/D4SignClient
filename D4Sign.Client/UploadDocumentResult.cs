using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class UploadDocumentResult
    {
        [JsonProperty(PropertyName = "uuid")]
        public string ReferenceId { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class GetDocumentRequest
    {
        [JsonProperty(PropertyName = "type")]
        public string DocumentDownloadType { get; set; }
    }
}
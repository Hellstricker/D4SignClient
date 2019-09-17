using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class ReplaceDocumentSignerResquest
    {
        [JsonProperty(PropertyName = "email-before")]
        public string CurrentDocumentSignerEmail { get; set; }

        [JsonProperty(PropertyName = "key-signer")]
        public string CurrentDocumentSignerKey { get; set; }

        [JsonProperty(PropertyName = "email-after")]
        public string NewDocumentSignerEmail { get; set; }        
    }
}
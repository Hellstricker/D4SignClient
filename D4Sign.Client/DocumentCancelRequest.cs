using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class DocumentCancelRequest
    {
        [JsonProperty(PropertyName = "email-signer")]
        public string DocumentSignerEmail { get; set; }

        [JsonProperty(PropertyName = "key-signer")]
        public string DocumentSignerKey { get; set; }        
    }
}
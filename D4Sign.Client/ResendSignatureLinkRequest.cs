using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class ResendSignatureLinkRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string DocumentSignerEmail { get; set; }

        [JsonProperty(PropertyName = "key_signer")]
        public string DocumentSignerKey { get; set; }
    }
}
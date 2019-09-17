using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class CreateDocumentBatch
    {
        [JsonProperty(PropertyName = "keys")]
        public string[] DocumentKeys { get; set; }
    }
}
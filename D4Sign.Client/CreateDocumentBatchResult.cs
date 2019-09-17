using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class CreateDocumentBatchResult
    {
        [JsonProperty(PropertyName = "message")]
        public string Message;

        [JsonProperty(PropertyName = "uuid_batches")]
        public string BatchReferenceKey;

        [JsonProperty(PropertyName = "total")]
        public int Total;
    }
}
using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class DocumentCancelResult
    {
        [JsonProperty(PropertyName = "uuidDoc")]
        public string DocumentKey;

        [JsonProperty(PropertyName = "nameDoc")]
        public string DocumentName;

        [JsonProperty(PropertyName = "type")]
        public string DocumentType;

        [JsonProperty(PropertyName = "size")]
        public int DocumentSize;

        [JsonProperty(PropertyName = "pages")]
        public int DocumentPages;

        [JsonProperty(PropertyName = "uuidSafe")]
        public string DocumentSafeBoxKey;

        [JsonProperty(PropertyName = "safeName")]
        public string DocumentSafeBoxName;

        [JsonProperty(PropertyName = "statusId")]
        public DocumentStatus DocumentStatus;

        [JsonProperty(PropertyName = "statusName")]
        public string DocumentStatusName;        
    }
}
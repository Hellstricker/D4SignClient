using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class UploadDocumentResquest
    {
        
        [JsonProperty(PropertyName = "base64_binary_file")]
        public string Content { get; set; }
        
        [JsonProperty(PropertyName = "mime_type")]
        public string MimeType { get; set; }        
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "uuid_folder")]
        public string Folder { get; set; }
    }
}
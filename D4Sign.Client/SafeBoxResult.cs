using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class SafeBoxResult
    {
        [JsonProperty(PropertyName = "uuid_safe")]
        public string ReferenceId { get; set; }

        [JsonProperty(PropertyName = "name-safe")]
        public string Name { get; set; }
    }
}
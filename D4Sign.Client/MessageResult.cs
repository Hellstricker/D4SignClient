using Newtonsoft.Json;

namespace D4Sign.Client
{
    public class MessageResult
    {        
        [JsonProperty(PropertyName = "message")]
        public string Message;
    }
}
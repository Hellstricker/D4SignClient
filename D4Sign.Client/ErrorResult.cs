using Newtonsoft.Json;
using System.Collections.Generic;

namespace D4Sign.Client
{
    internal class ErrorResult
    {
        public IList<string> Errors { get; internal set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; internal set; }
    }
}
using Newtonsoft.Json;
using System.Collections.Generic;

namespace D4Sign.Client
{
    public class AddDocumentSignersRequest
    {        
        [JsonProperty(PropertyName = "signers")]
        public List<DocumentSignerRequest> Signers;
    }
}
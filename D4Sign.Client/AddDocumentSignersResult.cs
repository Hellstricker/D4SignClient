using Newtonsoft.Json;
using System.Collections.Generic;

namespace D4Sign.Client
{
    public class AddDocumentSignersResult
    {        
        [JsonProperty(PropertyName = "message")]
        List<CreateDocumentSignerResultItem> Signers { get; set; }


        public class CreateDocumentSignerResultItem
        {
            [JsonProperty(PropertyName = "key_signer")]
            public string SignerKey { get; set; }

            [JsonProperty(PropertyName = "email")]
            public string Email { get; set; }

            [JsonProperty(PropertyName = "act")]
            public SignatureActionType SignatureAction { get; set; }

            [JsonProperty(PropertyName = "foreign")]
            public SignerNationalityType ForeingnSigner { get; set; }

            [JsonProperty(PropertyName = "assinatura_presencial")]
            public SignatureType FaceToFaceSignature { get; set; }
        }
    }
}
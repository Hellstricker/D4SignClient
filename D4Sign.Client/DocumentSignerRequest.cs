using Newtonsoft.Json;
using System;

namespace D4Sign.Client
{
    public class DocumentSignerRequest
    {

        public DocumentSignerRequest(string email, SignatureActionType signatureAction, SignerNationalityType foreingnSigner, SignatureType faceToFaceSignature, CertificateType icpbrCertificate)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("email", "Email is null or empty");

            Email = email;
            SignatureAction = signatureAction.GetHashCode();
            ForeingnSigner = foreingnSigner.GetHashCode();
            IcpbrCertificate = icpbrCertificate.GetHashCode();
            FaceToFaceSignature = faceToFaceSignature.GetHashCode();            
        }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; private set; }

        [JsonProperty(PropertyName = "act")]
        public int SignatureAction { get; private set; }

        [JsonProperty(PropertyName = "foreign")]
        public int ForeingnSigner { get; private set; }

        [JsonProperty(PropertyName = "certificadoicpbr")]
        public int IcpbrCertificate { get; private set; }

        [JsonProperty(PropertyName = "assinatura_presencial")]
        public int FaceToFaceSignature { get; private set; }
    }
}
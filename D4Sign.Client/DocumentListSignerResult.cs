using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace D4Sign.Client
{
    public class DocumentListSignersResult
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

        [JsonProperty(PropertyName = "list")]
        public List<Signer> Signers;


        public class Signer
        {
            [JsonProperty(PropertyName = "key_signer")]
            public string Key;

            [JsonProperty(PropertyName = "user_name")]
            public string Name;

            [JsonProperty(PropertyName = "user_document")]
            public string Document;

            [JsonProperty(PropertyName = "email")]
            public string Email;

            [JsonProperty(PropertyName = "signed")]
            public int Signed;
                        
            [JsonProperty(PropertyName = "sign_info")]
            public SignInfo SignInfo;

            [JsonProperty(PropertyName = "type")]
            public SignatureActionType ActionType;

            [JsonProperty(PropertyName = "foreign")]
            public SignerNationalityType Nationality;

            [JsonProperty(PropertyName = "certificadoicpbr")]
            public CertificateType CertificateType;

            [JsonProperty(PropertyName = "assinatura_presencial")]
            public SignatureType SignatureType;

            [JsonProperty(PropertyName = "embed_methodauth")]
            public string EmbededMethodAuth;

            [JsonProperty(PropertyName = "embed_smsnumber")]
            public string EmbededSMSNumber;

            [JsonProperty(PropertyName = "email_sent")]
            public int EmailSent;

            [JsonProperty(PropertyName = "email_sent_status")]
            public string EmailSentStatus;

            [JsonProperty(PropertyName = "email_sent_message")]
            public string EmailSentMessage;

            [JsonProperty(PropertyName = "upload_allowed")]
            public int UploadAllowed;

            [JsonProperty(PropertyName = "upload_obs")]
            public string UploadNote;

            [JsonProperty(PropertyName = "date")]
            public DateTime Date;
        }

        public class SignInfo
        {
            [JsonProperty(PropertyName = "ip")]
            public string Ip;

            [JsonProperty(PropertyName = "ip_reverser")]
            public string IpReverser;

            [JsonProperty(PropertyName = "geolocation")]
            public string GeoLocation;

            [JsonProperty(PropertyName = "user_agent")]
            public string UserAgent;

            [JsonProperty(PropertyName = "date_signed")]
            public DateTime? Date;

            [JsonProperty(PropertyName = "date_signed_atom")]
            public DateTime? DateAtom;
        }
    }
}
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace D4Sign.Client
{
    /// <summary>
    /// D4Sign SDK. For more information visit <see cref="http://docapi.d4sign.com.br/">D4Sign API REST</see>
    /// </summary>
    public class D4SignClient
    {
        private readonly ILog log;
        /// <summary>
        /// Get D4Sign Host
        /// </summary>
        public string Host { get; private set; }
        private string Token { get; set; }
        private string CryptKey { get; set; }
        private string Version { get; set; }

        /// <summary>
        /// Initialize new instance of class <see cref="D4SignClient"/>
        /// </summary>
        public D4SignClient(string host, string version, string token, string cryptKey)
        {
            if (string.IsNullOrEmpty(host)) throw new ArgumentNullException("host", "Host is null or empty");
            if (string.IsNullOrEmpty(version)) throw new ArgumentNullException("version", "Version is null or empty");
            if (string.IsNullOrEmpty(token)) throw new ArgumentNullException("version", "Token is null or empty");
            if (string.IsNullOrEmpty(cryptKey)) throw new ArgumentNullException("CryptKey", "CryptKey is null or empty");

            this.Host = host;
            this.Version = version;
            this.Token = token;
            this.CryptKey = cryptKey;
            this.log = LogManager.GetLogger(this.GetType());
        }

        /// <summary>
        /// List Safe Boxes. For more information visit <see cref="http://docapi.d4sign.com.br/#list-safe">D4Sign API REST</see>
        /// </summary>               
        /// <returns></returns>
        public async Task<List<SafeBoxResult>> ListSafeBox()
        {
            return await SendAsync<List<SafeBoxResult>>(HttpMethod.Get, "/safes");
        }

        /// <summary>
        /// Upload Document Binary. For more information visit <see cref="http://docapi.d4sign.com.br/#upload-file-binary">D4Sign API REST</see> 
        /// </summary>
        /// <returns></returns>
        public async Task<UploadDocumentResult> UploadDocument(string safeBoxKey , string filePath, byte[] fileBytes, string fileName, string folderKey)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException("path", "File path is null or empty.");
            if (fileBytes.Length.Equals(0)) throw new ArgumentNullException("file", "File is empty.");

            var mimeType = MimeMapping.Get(System.IO.Path.GetFileName(filePath));

            var content = Convert.ToBase64String(fileBytes);

            var data = new UploadDocumentResquest
            {
                
                    Content = content
                    , Folder = folderKey
                    , MimeType = mimeType
                    , Name = fileName
                
            };

            return await SendAsync<UploadDocumentResult>(HttpMethod.Post, "documents/" + safeBoxKey + "/uploadbinary", data);
        }

        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#download-doc">D4Sign API REST</see> 
        /// </summary>        
        /// <returns></returns>
        public async Task<GetDocumentResult> GetDocument(string documentKey, DocumentDownloadType documentDownloadType = DocumentDownloadType.PDF)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");

            var data = new GetDocumentRequest
            {

                DocumentDownloadType = documentDownloadType.ToString()                
            };

            return await SendAsync<GetDocumentResult>(HttpMethod.Post, string.Format("documents/{0}/download", documentKey),data);
        }


        //Rever este método AddDocumentSignersSignersResult
        /// <summary>        
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#add-signatarios">D4Sign API REST</see>
        /// </summary>
        /// <returns></returns>
        public async Task<AddDocumentSignersResult> AddDocumentSigners(string documentKey, AddDocumentSignersRequest request)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");
            if (request == null || request.Signers == null || request.Signers.Count == 0) throw new ArgumentNullException("signers", "Signers is null or empty.");


            return await SendAsync<AddDocumentSignersResult>(HttpMethod.Post, string.Format("documents/{0}/createlist", documentKey), request);
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#list-signatarios">D4Sign API REST</see> 
        /// </summary>
        /// <returns></returns>
        public async Task<DocumentListSignersResult> DocumentListSigners(string documentKey)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");

            var result = await SendAsync<IEnumerable<DocumentListSignersResult>>(HttpMethod.Get, string.Format("documents/{0}/list", documentKey));
            
            return new List<DocumentListSignersResult>(result).FirstOrDefault();
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#cancel-doc">D4Sign API REST</see> 
        /// </summary>
        /// <returns></returns>
        public async Task<DocumentCancelResult> CancelDocument(string documentKey)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");

            var result = await SendAsync<IEnumerable<DocumentCancelResult>>(HttpMethod.Post, string.Format("documents/{0}/cancel", documentKey));

            return result.FirstOrDefault();
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#remove-signatario">D4Sign API REST</see>  
        /// </summary>        
        /// <returns></returns>
        public async Task<MessageResult> RemoveDocumentSigner(string documentKey, string documentSignerKey, string signerEmail)
        {

            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");
            if (string.IsNullOrEmpty(documentSignerKey)) throw new ArgumentNullException("documentSignerKey", "Document Signer key is null or empty.");
            if (string.IsNullOrEmpty(signerEmail)) throw new ArgumentNullException("signerEmail", "Document Signer email is null or empty.");

            var data = new RemoveDocumentSignerResquest
            {

                DocumentSignerEmail = signerEmail,
                DocumentSignerKey = documentSignerKey
            };

            return await SendAsync<MessageResult>(HttpMethod.Post, string.Format("documents/{0}/removeemaillist", documentKey), data);
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#change-signatario">D4Sign API REST</see> 
        /// </summary>
        /// <returns></returns>
        public async Task<MessageResult> ReplaceDocumentSignerEmail(string documentKey, string currentDocumentSignerEmail, string currentDocumentSignerKey, string newDocumentSignerEmail)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");
            if (string.IsNullOrEmpty(currentDocumentSignerEmail)) throw new ArgumentNullException("currentDocumentSignerEmail", "Current Document Signer email is null or empty.");
            if (string.IsNullOrEmpty(currentDocumentSignerKey)) throw new ArgumentNullException("currentDocumentSignerKey", "Current Document Signer key is null or empty.");
            if (string.IsNullOrEmpty(newDocumentSignerEmail)) throw new ArgumentNullException("newDocumentSignerEmail", "New Document Signer email is null or empty.");

            var data = new ReplaceDocumentSignerResquest
            {
                CurrentDocumentSignerEmail = currentDocumentSignerEmail,
                CurrentDocumentSignerKey = currentDocumentSignerKey,
                NewDocumentSignerEmail = newDocumentSignerEmail
            };

            return await SendAsync<MessageResult>(HttpMethod.Post, string.Format("documents/{0}/changeemail", documentKey), data);
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#send-signer">D4Sign API REST</see>  
        /// </summary>
        /// <returns></returns>
        public async Task<MessageResult> SendDocumentToSign(string documentKey,string message, SkipEmailType skipEmail, WorkFlowType workFlow)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");

            var data = new DocumentToSignResquest
            {
                Message = message,
                SkipEmail = skipEmail.GetHashCode(),
                Workflow = workFlow.GetHashCode()
                
            };

            return await SendAsync<MessageResult>(HttpMethod.Post, string.Format("documents/{0}/sendtosigner", documentKey, data));

            
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#criar-lote">D4Sign API REST</see> 
        /// </summary>        
        /// <returns></returns>
        public async Task<CreateDocumentBatchResult> CreateDocumentBatch(string[] documentKeys)
        {
            if (documentKeys == null || documentKeys.Count() == 0) throw new ArgumentNullException("documentKey", "Document key is null or empty.");

            var data = new CreateDocumentBatch
            {
                DocumentKeys = documentKeys
            };

            return await SendAsync<CreateDocumentBatchResult>(HttpMethod.Post, "/batches", data);
        }


        /// <summary>
        /// Get Document. For more information visit <see cref="http://docapi.d4sign.com.br/#resend-link">D4Sign API REST</see>  
        /// </summary>
        /// <returns></returns>
        public async Task<MessageResult> ResendSignatureLink(string documentKey, string documentSigneremail, string documentSignerKey)
        {
            if (string.IsNullOrEmpty(documentKey)) throw new ArgumentNullException("documentKey", "Document key is null or empty.");
            if (string.IsNullOrEmpty(documentSigneremail)) throw new ArgumentNullException("documentSigneremail", "Document Signer email is null or empty.");
            if (string.IsNullOrEmpty(documentSignerKey)) throw new ArgumentNullException("documentSignerKey", "Document Signer key is null or empty.");
            
            var data = new ResendSignatureLinkRequest
            {
                DocumentSignerEmail = documentSigneremail,
                DocumentSignerKey = documentSignerKey
            };

            return await SendAsync<MessageResult>(HttpMethod.Post, string.Format("documents/{0}/resend", documentKey), data);
        }

        #region{Util}
        private async Task<T> SendAsync<T>(HttpMethod method, string path, object content = null)
        {
            string url = GetUrl(path);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(method, url))
            {
                try
                {
                    if (content != null)
                    {
                        var json = JsonConvert.SerializeObject(content, new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        });
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                        //application/json
                        
                    }

                    using (var response = await client.SendAsync(request))
                    {
                        var stream = await response.Content.ReadAsStreamAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            return DeserializeJsonFromStream<T>(stream);                        }
                        else
                        {
                            throw CreateException(stream, (int)response.StatusCode);
                        }
                    }
                }
                finally
                {
                    if (request.Content != null) request.Dispose();
                }
            }
        }       

        public string GetUrl(string path)
        {
            string uri1 = Host.TrimEnd('/');
            path = path.TrimStart('/');

            var url = string.Format("{0}/{1}/{2}", uri1, Version, path);
            url += url.IndexOf('?') >= 0 ? "&" : "?";
            url += "tokenAPI=" + Token;
            url += "&cryptKey=" + CryptKey;
            return url;

        }

        private T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var jr = new JsonSerializer();
                jr.ContractResolver = new CamelCasePropertyNamesContractResolver();                
                var searchResult = jr.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        private D4SignException CreateException(Stream stream, int statusCode)
        {
            string message = "An error occurred while executing api.";
            IList<string> errors = null;

            var result = DeserializeJsonFromStream<ErrorResult>(stream);
            if (result != null)
            {
                errors = result.Errors;

                //Verifique se é nesecessário
                if (errors != null && errors.Count > 0)
                    message = string.Join(", ", result.Errors);

                if (!string.IsNullOrEmpty(result.Message))
                    message = result.Message;
            }


            return new D4SignException(message, statusCode);
        }
        #endregion
    }
}

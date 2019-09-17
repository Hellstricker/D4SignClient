using D4Sign.Client;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace D4Sign.Tests
{
    public class Program
    {
        private static string documentKey = "3c3abc2b-0c0f-4432-a656-1a4b80e735de";
        private static string host = "http://demo.d4sign.com.br/api";
        private static string version = "v1";
        private static string token = "live_38df29b0a6b76a0455d075b8fb1115cbb59b5d5b4bc5184fd6cd3e70dce06e76";
        private static string cryptKey = "live_crypt_P2Cq09MwumPh8evL1BrMgIBw0c88pyyL";
        private static string safeBoxKey = "403b434c-d1eb-4d3d-aa43-ecaed3f02b96";

        static async Task Main(string[] args)
        {
        
            var signerApp = new D4SignClient(host,version, token, cryptKey);
            
            try
            {
                ConsoleKeyInfo consoleKey; ;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Documento atual: {0}", documentKey);
                    Console.WriteLine("Cofre atual: {0}", safeBoxKey);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("1-Upload de documento");
                    Console.WriteLine("0-Sair");
                    consoleKey = Console.ReadKey();                    
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.NumPad1:
                            Console.WriteLine();
                            var document = await signerApp.UploadDocument("403b434c-d1eb-4d3d-aa43-ecaed3f02b96", "C:\\Users\\netob\\Desktop\\Contrato.pdf", File.ReadAllBytes("C:\\Users\\netob\\Desktop\\Contrato.pdf"), "Contrato.pdf", null);
                            Console.WriteLine("ReferenceKey = {0}", document.ReferenceId);
                            Console.WriteLine("Atualizar referência? s/n");
                            
                            do 
                            {
                                consoleKey = Console.ReadKey();
                                Console.WriteLine();
                                if (consoleKey.Key == ConsoleKey.S)
                                {
                                    documentKey = document.ReferenceId;
                                    Console.WriteLine("Referencia atualizada para {0}", documentKey);                                    
                                }                                
                            }
                            while (consoleKey.Key != ConsoleKey.S && consoleKey.Key != ConsoleKey.N) ;
                            break;
                    }
                    if (consoleKey.Key != ConsoleKey.NumPad0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para retornar;");
                        Console.ReadKey();
                    }

                }
                while (consoleKey.Key != ConsoleKey.NumPad0);
                

                //Upload document
                //var d = await signerApp.UploadDocument("403b434c-d1eb-4d3d-aa43-ecaed3f02b96", "C:\\Users\\netob\\Desktop\\Contrato.pdf", File.ReadAllBytes("C:\\Users\\netob\\Desktop\\Contrato.pdf"), "Contrato.pdf", null);
                //Console.WriteLine(d.ReferenceId);

                //Download document
                //var d = await signerApp.GetDocument(documentKey, DocumentDownloadType.PDF);
                //Console.WriteLine(d.Url);



                //Cadastrar assinantes
                //CreateDocumentSignerRequest req = new CreateDocumentSignerRequest();
                //req.Signers = new List<DocumentSignerRequest>();                 
                //req.Signers.Add(new DocumentSignerRequest("ederson.paixao@bomconsorcio.com.br", SignatureActionType.SignAsWitness, SignerNationalityType.HasCPF,SignatureType.Remote,CertificateType.D4SignDefaultSignature));
                //req.Signers.Add(new DocumentSignerRequest("ozias.costa@bomconsorcio.com.br", SignatureActionType.Sign, SignerNationalityType.HasCPF, SignatureType.Remote, CertificateType.D4SignDefaultSignature));
                //var result = await signerApp.CreateDocumentSigners(documentKey, req );


                // ListSigners
                //var d = await signerApp.DocumentListSigners(documentKey);
                //foreach (var item in d.Signers)
                //{
                //    Console.WriteLine("Email: {0} - Chave: {1} ", item.Email, item.Key);
                //}

                //Remover assinante
                //var result = await signerApp.RemoveDocumentSigner(documentKey, "NTAyMg==", "oziasmcn@gmail.com");
                //Console.WriteLine(result.Message);


                //Cancel document
                //var d = await signerApp.CancelDocument(documentKey);
                //Console.WriteLine(d.DocumentName);

                //Modificar email assinante
                //var result = await signerApp.ReplaceDocumentSignerEmail(documentKey, "oziasmcn@gmail.com", "NTAzNA==", "ozias.costa@bomconsorcio.com.br");
                //Console.WriteLine(result.Message);

                //Send to sign
                //var d = await signerApp.SendDocumentToSign(documentKey, "Está na hora de assinar", SkipEmailType.NotSendMailToSigners, WorkFlowType.NotFollow);
                //Console.WriteLine(d.Message);

                //Batch
                //var d = await signerApp.CreateDocumentBatch(new string[] { documentKey });
                //Console.WriteLine(d.BatchReferenceKey);

                //Reenviar Email
                //var result = await signerApp.ResendSignatureLink(documentKey, "ozias.costa@bomconsorcio.com.br", "NTAzNw==");
                //Console.WriteLine(result.Message);

                //Console.WriteLine(x[0].DocumentKey);
            }
            catch (D4SignException ex)
            {
                Console.WriteLine(ex.Message);

            }            
        }
    }
}

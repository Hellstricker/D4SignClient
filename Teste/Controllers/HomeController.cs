using D4Sign.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        private static string documentKey = "3c3abc2b-0c0f-4432-a656-1a4b80e735de";
        public async Task Index()
        {
            
            var signerApp = new D4SignClient("http://demo.d4sign.com.br/api", "v1", "live_38df29b0a6b76a0455d075b8fb1115cbb59b5d5b4bc5184fd6cd3e70dce06e76", "live_crypt_P2Cq09MwumPh8evL1BrMgIBw0c88pyyL");
            var d = await signerApp.GetDocument(documentKey, DocumentDownloadType.PDF);

            WebClient myWebClient = new WebClient();

            byte[] myDataBuffer = myWebClient.DownloadData(d.Url);

            Response.ClearContent();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline; filename=" + d.Name);
            Response.AddHeader("Content-Length", myDataBuffer.Length.ToString());
            Response.BinaryWrite(myDataBuffer);
            Response.End();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
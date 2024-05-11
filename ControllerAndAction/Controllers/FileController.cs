using Microsoft.AspNetCore.Mvc;

namespace ControllerAndAction.Controllers
{
    public class FileController : Controller
    {

        [Route("/download")]
        public FileResult Download()
        {

            //return new VirtualFileResult("/Shatrudhan_Resume.pdf", "application/pdf");
            return File("/Shatrudhan_Resume.pdf", "application/pdf");
        }

        [Route("/download1")]
        public FileResult Download1()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("D:\\Code\\DotnetCoreConcept\\ControllerAndAction\\wwwroot\\Shatrudhan_Resume.pdf");
            return File(bytes, "application/pdf");
        }
    }
}

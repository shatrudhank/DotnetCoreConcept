using ControllerAndAction.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;

namespace ControllerAndAction.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        public string Index()
        {
            return "Hello from controller";
        }

        [Route("/contact/{contact:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return HttpContext.Request.RouteValues["contact"].ToString();
        }

        [Route("/content")]
        public ContentResult GetContent()
        {
            return Content("<h1>Shatrudhan</h1>", "text/html");
        }

        [Route("/person")]
        public JsonResult GetPerson()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName="Shatrudhan",
                LastName="Kumar"
            };

            return Json(person);
        }
    }
}

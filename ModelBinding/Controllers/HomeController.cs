using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return Content( "Home","text/plain");
        }

        public IActionResult About(string name,int age)
        {
            var x = Request.QueryString;
            var x1 = Request.Query;
            return Content($"I am {name}. My age is {age}");
          
        }
    }
}

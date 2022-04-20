using Microsoft.AspNetCore.Mvc;

namespace Northwind.Core.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

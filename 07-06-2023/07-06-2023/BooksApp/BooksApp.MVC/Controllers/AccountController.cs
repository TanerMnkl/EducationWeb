using Microsoft.AspNetCore.Mvc;

namespace BooksApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}

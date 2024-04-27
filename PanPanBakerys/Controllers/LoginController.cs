using Microsoft.AspNetCore.Mvc;
using PanPanBakerys.Models;

namespace PanPanBakerys.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(User userModule)
        {
            if ((userModule.username == "js@js.com") && (userModule.password == "js@js.com"))
            {
                return View("LoginSuccess", userModule);
            }
            else
            {
                return View("LoginFailure", userModule);
            }
        }
    }
}

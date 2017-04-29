using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebMvc.Models;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IUserService cityService)
        {
            this._userService = cityService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            // 测试miniprofiler.ef6
            this._userService.GetAll();
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            return Content("ok");
        }
    }
}
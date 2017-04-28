using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebMvc.Models;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private ICityService _cityService;
        public HomeController(ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            // 测试miniprofiler.ef6
            this._cityService.GetAll();
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            return Content("ok");
        }
    }
}
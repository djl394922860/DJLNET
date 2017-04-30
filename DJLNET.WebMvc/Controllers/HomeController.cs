using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebMvc.Models;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IPermissionService _permissionService;
        public HomeController(IUserService cityService, IPermissionService permissionService)
        {
            this._userService = cityService;
            this._permissionService = permissionService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
   
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
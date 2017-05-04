using DJLNET.ApplicationService.Interfaces;
using DJLNET.Core.Helper;
using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace DJLNET.WebMvc.Controllers
{
    public class HomeController : DJLNET.WebCore.Mvc.BaseController
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
            if (!this._userService.Login(model.Name, MD5Helper.GetMD5(model.Password)))
            {
                ModelState.AddModelError(string.Empty, "账号或者密码错误");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe, FormsAuthentication.FormsCookiePath);
            return RedirectToAction(nameof(Index));
        }

        [LoginAuthentication]
        public ActionResult Index()
        {
            return View();
        }

        [LoginAuthentication, HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(Login));
        }
    }
}
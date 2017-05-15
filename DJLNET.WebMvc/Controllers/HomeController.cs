using DJLNET.ApplicationService.Interfaces;
using DJLNET.Core.Helper;
using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace DJLNET.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticateProvider _authorizeProvider;
        private readonly IUserService _userService;
        public HomeController(IAuthenticateProvider authorizaProvider, IUserService userService)
        {
            this._authorizeProvider = authorizaProvider;
            _userService = userService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = _userService.Login(model.Name, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "账号或者密码错误");
                return View(model);
            }
            _authorizeProvider.Login(user, model.RememberMe);
            if (string.IsNullOrWhiteSpace(returnUrl) || !Url.IsLocalUrl(returnUrl))
                return RedirectToAction(nameof(Index));
            else
                return Redirect(returnUrl);
        }

        /// <summary>
        /// 后台主页(身份认证控制即可)
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Logout()
        {
            _authorizeProvider.LoginOut();
            return RedirectToAction(nameof(Login));
        }
    }
}
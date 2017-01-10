using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebCore;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private ITestService _testService;
        public HomeController(ITestService testService)
        {
            this._testService = testService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            // 测试miniprofiler.ef6
            this._testService.GetAll();
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken, ModelStateValidFilter]
        public ActionResult Login(LoginViewModel model)
        {
            // login.cshtml Html.XXXX
            // this._userService 校验用户
            // FormAuthentication
            // web.config Form 配置
            return null;
        }
    }
}
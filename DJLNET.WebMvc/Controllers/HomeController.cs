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
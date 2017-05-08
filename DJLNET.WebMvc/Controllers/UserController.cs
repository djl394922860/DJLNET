using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Delete(int userId)
        {
            return null;
        }

        [HttpPost, ActionName("Auth")]
        public ActionResult SetRoles(int userId, IEnumerable<int> roles)
        {
            return null;
        }
    }
}
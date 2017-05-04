using DJLNET.WebCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    [LoginAuthentication]
    public class RoleController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
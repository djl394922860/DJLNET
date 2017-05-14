using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model.Entities;
using DJLNET.WebCore.Mvc;
using DJLNET.WebCore.Security;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DJLNET.Core.Extension;
using AutoMapper;

namespace DJLNET.WebMvc.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionAuthorization("UserIndex")]
        public ActionResult GetUserPagerData(int limit, int offset, string username)
        {
            Expression<Func<User, bool>> condition = null;
            if (!username.IsNullOrWhiteSpace())
                condition = x => x.Name.Contains(username);
            Expression<Func<User, string>> orderby = x => x.Name;
            int pagenum = offset / limit + 1;
            if (pagenum == 0) pagenum = 1;
            var data = _service.PagingQuery(condition, pagenum, limit, orderby, false);
            return Json(new { total = data.Total, rows = _mapper.Map<IEnumerable<UserViewModel>>(data.Rows) });
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
        public ActionResult SetRoles(int userId, IEnumerable<int> roleIds)
        {
            return null;
        }
    }
}
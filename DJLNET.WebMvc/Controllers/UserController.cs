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
using System.Net;

namespace DJLNET.WebMvc.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        public UserController(IUserService service, IMapper mapper, IRoleService roleService)
        {
            _service = service;
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionAuthorization("UserIndex")]
        public ActionResult GetUserPagerData(int limit, int offset, string username, string sort, string order)
        {
            Expression<Func<User, bool>> condition = null;
            if (!username.IsNullOrWhiteSpace())
                condition = x => x.Name.Contains(username);
            //Expression<Func<User, string>> orderby = x => x.Name;
            int pagenum = offset / limit + 1;
            if (pagenum == 0) pagenum = 1;
            var data = _service.PagingQuery(condition, pagenum, limit, sort, order == "desc" ? true : false);
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
        public ActionResult SetUserRoles(int userId, IEnumerable<int> roleIds)
        {
            _service.SetRoleList(userId, roleIds ?? new List<int>(), WorkConext.CurrentUser.Name);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost, ActionAuthorization("UserAuth")]
        public ActionResult GetUserRoleList(int userId)
        {
            var user = _service.Get(userId);
            user.Roles = user.Roles.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            var allRoles = _roleService.Find(x => x.IsActive && !x.IsDeleted);
            foreach (var x in allRoles)
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString(),
                    Selected = user.Roles.Any(z => z.ID == x.ID)
                };
                list.Add(item);
            }
            return PartialView("/Views/User/_UserRole.cshtml", list);
        }
    }
}
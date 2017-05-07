using DJLNET.ApplicationService.Interfaces;
using DJLNET.Core.Paging;
using DJLNET.Model.Entities;
using DJLNET.Repository.Interfaces;
using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Extensions;
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
using DJLNET.WebCore.Security;
using LinqKit;

namespace DJLNET.WebMvc.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        private readonly IPermissionService _permissionService;
        private IMapper _mapper;
        public RoleController(IRoleService service, IPermissionService permissionService, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _permissionService = permissionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ActionAuthorization("RoleIndex")]
        public JsonResult GetPagingData(RoleQuery query)
        {
            Expression<Func<Role, bool>> condition = x => !x.IsDeleted;
            Expression<Func<Role, bool>> merge = null;
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                var name = query.Name;
                merge = f => condition.Invoke(f) && f.Name.Contains(name);
            }
            IPagedList<Role> data = _service.PagingQuery(merge == null ? condition : merge, (query.Start / query.Length) + 1, query.Length, query.OrderBy, query.OrderDir == DataTablesOrderDir.Desc);
            return DataTablesExtensions.DataTablesJsonResult(
                query.Draw,
                data.Total,
                data.Total,
                _mapper.Map<IReadOnlyList<Role>, IReadOnlyList<RoleViewModel>>(data.Rows)
            );
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RoleModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(RoleModel model)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Delete(int roleId)
        {
            return null;
        }

        [HttpPost]
        [ActionName("GetRolePermissions"), ActionAuthorization("RoleAuth")]
        public PartialViewResult RolePermission(int roleId)
        {
            var role = _service.Get(roleId);
            if (role.IsDeleted) throw new Exception("试图获取一个已删除角色的权限");
            var groups = _permissionService.GetAll().GroupBy(x => x.Category);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var group in groups)
            {
                SelectListGroup temp = new SelectListGroup() { Name = group.Key };
                list.AddRange(group.Select(x => new SelectListItem()
                {
                    Group = temp,
                    Text = x.Description,
                    Value = x.ID.ToString(),
                    Selected = role.Permissions.Any(z => z.ID == x.ID)
                }));
            }
            return PartialView("/Views/Role/_RolePermission.cshtml", list);
        }

        [HttpPost, ActionName("Auth")]
        public ActionResult SetRolePermissions(int roleId, IEnumerable<int> permissionIds)
        {
            _service.SetPermissions(roleId, permissionIds ?? new List<int>(), WorkConext.CurrentUser.Name);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
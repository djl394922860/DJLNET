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

        public JsonResult GetPagingData(RoleQuery query)
        {
            Expression<Func<Role, bool>> condition = null;
            if (!string.IsNullOrWhiteSpace(query.Name))
                condition = x => x.Name.Contains(query.Name);
            IPagedList<Role> data = _service.PagingQuery(condition, (query.Start / query.Length) + 1, query.Length, query.OrderBy, query.OrderDir == DataTablesOrderDir.Desc);
            return DataTablesExtensions.DataTablesJsonResult(
                query.Draw,
                data.Total,
                data.Total,
                _mapper.Map<IReadOnlyList<Role>, IReadOnlyList<RoleViewModel>>(data.Rows)
            );
        }

        [HttpPost]
        [ActionName("GetRolePermissions")]
        public PartialViewResult RolePermission(int roleId)
        {
            var role = _service.Get(roleId);
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

        [HttpPost]
        public ActionResult SetRolePermissions(int roleId, IEnumerable<int> permissionIds)
        {
            _service.SetPermissions(roleId, permissionIds ?? new List<int>());
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
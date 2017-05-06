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

namespace DJLNET.WebMvc.Controllers
{
    [LoginAuthentication]
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        private IMapper _mapper;
        public RoleController(IRoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
    }
}
using DJLNET.ApplicationService.Interfaces;
using DJLNET.Core.Paging;
using DJLNET.Model.Entities;
using DJLNET.Repository.Interfaces;
using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    [LoginAuthentication]
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
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
            int pageNum = query.Start / query.Length;
            if (pageNum == 0) pageNum = 1;
            IPagedList<Role> data = _service.PagingQuery(condition, pageNum, query.Length, query.OrderBy, query.OrderDir == DataTablesOrderDir.Desc);

            var count = data.Total;
            var result = data.Rows;

            return DataTablesJsonResult(query.Draw, count, count, result);
        }

        public JsonResult DataTablesJsonResult<TEntity>(int draw, int recordsTotal, int recordsFiltered,
           IReadOnlyList<TEntity> data, string error = null) where TEntity : class, new()
        {
            var result = new DataTablesResult<TEntity>(draw, recordsFiltered, recordsFiltered, data);
            var jsonResult = new JsonNetResult
            {
                Data = result
            };
            return jsonResult;
        }
    }
}
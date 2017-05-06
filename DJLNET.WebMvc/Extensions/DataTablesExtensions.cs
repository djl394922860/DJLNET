using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Extensions
{
    public static class DataTablesExtensions
    {
        public static JsonResult DataTablesJsonResult<TEntity>(int draw, int recordsTotal, int recordsFiltered,
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
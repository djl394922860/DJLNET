using DJLNET.WebCore.Mvc;
using System.Collections.Generic;

namespace DJLNET.WebCore.Mvc
{
    public class ExcelController : BaseController
    {
        public ExcelFileResult<TModel> Excel<TModel>(IEnumerable<TModel> models) where TModel : class, new()
        {
            return new ExcelFileResult<TModel>(models);
        }

        public ExcelFileResult<TModel> Excel<TModel>(IEnumerable<TModel> models, string fileName = null) where TModel : class, new()
        {
            return new ExcelFileResult<TModel>(models, fileName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore
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

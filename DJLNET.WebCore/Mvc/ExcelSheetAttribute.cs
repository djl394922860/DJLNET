using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.Mvc
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ExcelSheetAttribute : System.Attribute
    {
        /// <summary>
        /// 工作表名称
        /// </summary>
        public string Name { get; set; } = "Sheet1";

        /// <summary>
        /// 表格行高
        /// </summary>
        public double RowHeight { get; set; } = 28;
    }
}

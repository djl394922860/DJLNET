using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ExcelColumnAttribute : System.Attribute
    {
        /// <summary>
        /// 单引号前缀
        /// </summary>
        public bool Quote { get; set; }

        /// <summary>
        /// 水平居中
        /// </summary>
        public ExcelHorizontalAlignment HorizontalStyle { get; set; } = ExcelHorizontalAlignment.Left;

        /// <summary>
        /// 列排序号
        /// </summary>
        public int Sort { get; set; } = 0;
    }
}

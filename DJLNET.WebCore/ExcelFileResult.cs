using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OfficeOpenXml;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Globalization;

namespace DJLNET.WebCore
{
    public class ExcelFileResult<TModel> : System.Web.Mvc.FileResult
        where TModel : class, new()
    {
        private IEnumerable<TModel> _models;

        public ExcelFileResult(IEnumerable<TModel> models, string fileName = null) : base("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            this._models = models;
            fileName = string.IsNullOrWhiteSpace(fileName) ? Path.GetRandomFileName() : fileName;
            this.FileDownloadName = Path.ChangeExtension(fileName, "xlsx");
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            byte[] buffer = GenerateExcel();
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        private byte[] GenerateExcel()
        {
            PropertyInfo[] properties = typeof(TModel).GetProperties().Where(x => !x.IsDefined(typeof(ExcelIgnoreAttribute))).ToArray();

            using (var excel = new ExcelPackage())
            {
                var sheet = excel.Workbook.Worksheets.Add("sheet1");
                GeneateExcelHeader(sheet, properties);
                GeneateExcelBody(sheet, properties);
                return excel.GetAsByteArray();
            }
        }

        private void GeneateExcelBody(ExcelWorksheet sheet, PropertyInfo[] properties)
        {
            TModel[] models = this._models.ToArray();
            for (int i = 2; i <= models.Length + 1; i++)
            {
                TModel current = models[i - 2];
                for (int j = 1; j <= properties.Length; j++)
                {
                    var pro = properties[j - 1];
                    var format = pro.GetCustomAttribute<DisplayFormatAttribute>();
                    if (format != null && typeof(IFormattable).IsAssignableFrom(pro.PropertyType))
                    {
                        sheet.Cells[i, j].Value = ((IFormattable)pro.GetValue(current)).ToString(format.DataFormatString, CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        sheet.Cells[i, j].Value = pro.GetValue(current);
                    }
                }
            }
        }

        private void GeneateExcelHeader(ExcelWorksheet sheet, PropertyInfo[] properties)
        {
            for (int i = 1; i <= properties.Length; i++)
            {
                PropertyInfo current = properties[i - 1];
                DisplayAttribute display = current.GetCustomAttribute<DisplayAttribute>();
                DisplayNameAttribute displayName = current.GetCustomAttribute<DisplayNameAttribute>();
                string columnName = display?.GetName() ?? displayName?.DisplayName ?? current.Name;
                sheet.Cells[1, i].Value = columnName;
                sheet.Cells[1, i].Style.Font.Bold = true;
            }
        }
    }
}

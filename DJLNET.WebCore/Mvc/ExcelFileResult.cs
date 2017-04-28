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

namespace DJLNET.WebCore.Mvc
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

            var excelSheetAttribute = typeof(TModel).GetCustomAttribute<ExcelSheetAttribute>() ?? new ExcelSheetAttribute();

            using (var excel = new ExcelPackage())
            {
                var sheet = excel.Workbook.Worksheets.Add("sheet1");
                GeneateExcelHeader(sheet, properties, excelSheetAttribute);
                GeneateExcelBody(sheet, properties, excelSheetAttribute);
                return excel.GetAsByteArray();
            }
        }

        private void GeneateExcelBody(ExcelWorksheet sheet, PropertyInfo[] properties, ExcelSheetAttribute excelSheetAttribute)
        {
            TModel[] models = this._models.ToArray();
            for (int i = 2; i <= models.Length + 1; i++)
            {
                TModel current = models[i - 2];
                sheet.Row(i).Height = excelSheetAttribute.RowHeight;
                properties = GetSortPropertyInfos(properties);
                for (int j = 1; j <= properties.Length; j++)
                {
                    var cellRang = sheet.Cells[i, j];
                    var pro = properties[j - 1];
                    var format = pro.GetCustomAttribute<DisplayFormatAttribute>();
                    if (format != null && typeof(IFormattable).IsAssignableFrom(pro.PropertyType))
                    {
                        cellRang.Value = ((IFormattable)pro.GetValue(current)).ToString(format.DataFormatString, CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        cellRang.Value = pro.GetValue(current);
                    }
                    cellRang.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    var excelColumnAttribute = pro.GetCustomAttribute<ExcelColumnAttribute>() ?? new ExcelColumnAttribute();
                    cellRang.Style.HorizontalAlignment = excelColumnAttribute.HorizontalStyle;
                }
            }
        }

        private PropertyInfo[] GetSortPropertyInfos(PropertyInfo[] properties)
        {
            var orders = properties.Where(x => x.IsDefined(typeof(ExcelColumnAttribute))).OrderBy(x => x.GetCustomAttribute<ExcelColumnAttribute>().Sort).ToArray();
            var others = properties.Where(x => !x.IsDefined(typeof(ExcelColumnAttribute)));
            return orders.Concat(others).ToArray();
        }

        private void GeneateExcelHeader(ExcelWorksheet sheet, PropertyInfo[] properties, ExcelSheetAttribute excelSheetAttribute)
        {
            sheet.Name = excelSheetAttribute.Name;
            sheet.CustomHeight = true;
            sheet.DefaultRowHeight = excelSheetAttribute.RowHeight;
            sheet.Row(1).Height = excelSheetAttribute.RowHeight;
            properties = GetSortPropertyInfos(properties);
            for (int i = 1; i <= properties.Length; i++)
            {
                PropertyInfo current = properties[i - 1];
                DisplayAttribute display = current.GetCustomAttribute<DisplayAttribute>();
                DisplayNameAttribute displayName = current.GetCustomAttribute<DisplayNameAttribute>();
                string columnName = display?.GetName() ?? displayName?.DisplayName ?? current.Name;
                var cellRang = sheet.Cells[1, i];
                cellRang.Value = columnName;
                cellRang.Style.Font.Bold = true;
                cellRang.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                cellRang.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            }
        }
    }
}

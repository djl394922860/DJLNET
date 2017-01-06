using DJLNET.WebCore;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    [ExcelSheet(Name = "Test", RowHeight = 28)]
    public class TestViewModel
    {
        [DisplayName("编号")]
        [ExcelIgnore]
        public int Id { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("价格")]
        [DisplayFormat(DataFormatString = "C")]
        [ExcelColumn(HorizontalStyle = ExcelHorizontalAlignment.Right)]
        public decimal Money { get; set; } = 8.88M;

        [DisplayName("创建时间")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
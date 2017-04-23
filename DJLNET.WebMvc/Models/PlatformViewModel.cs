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
    public class PlatformViewModel
    {
        public int ID { get; set; }
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string DomainUrl { get; set; }
    }
}
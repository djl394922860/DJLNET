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
    public class UserViewModel
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
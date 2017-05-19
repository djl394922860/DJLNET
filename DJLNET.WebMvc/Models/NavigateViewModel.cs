using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    public class NavigateViewModel
    {
        public int ID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Name { get; set; }
        public string IconClassCode { get; set; }
        public int? ParentID { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
    }
}
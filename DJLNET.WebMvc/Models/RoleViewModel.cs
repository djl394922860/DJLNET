using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    public class RoleViewModel
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; } 
        public DateTime UpdatedTime { get; set; } 
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Models
{
    public class Platform : GenericEntity<int>
    {
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string DomainUrl { get; set; }
    }
}

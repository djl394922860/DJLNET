using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Entities
{
    public class City : GenericEntity<int>
    {
        public string Name { get; set; }
        public string JumpUrl { get; set; }
    }
}

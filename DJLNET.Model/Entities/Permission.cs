using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}

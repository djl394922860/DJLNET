using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}

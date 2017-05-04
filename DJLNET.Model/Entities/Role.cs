using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}

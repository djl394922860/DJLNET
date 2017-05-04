using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Entities
{
    public class EntityPermission : BaseEntity
    {
        public int EntityID { get; set; }
        public string EntityName { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}

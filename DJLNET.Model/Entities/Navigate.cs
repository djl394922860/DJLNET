using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Entities
{
    public class Navigate : GenericEntity<int>
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Name { get; set; }
        public string IconClassCode { get; set; }
        public int? ParentID { get; set; }
        public virtual Navigate Parent { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
        public virtual ICollection<Navigate> Children { get; set; } = new List<Navigate>();
    }
}

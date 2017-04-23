using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model
{
    public abstract class BaseEntity : GenericEntity<int>
    {
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime UpdatedTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}

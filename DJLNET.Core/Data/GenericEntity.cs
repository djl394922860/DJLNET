using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Data
{
    public abstract class GenericEntity<TPrimaryKey>
    {
        public TPrimaryKey ID { get; set; }
    }
}

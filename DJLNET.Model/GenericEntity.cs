using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model
{
    /// <summary>
    /// 实体泛型类
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体数据库主键</typeparam>
    public class GenericEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TPrimaryKey ID { get; set; }
    }
}

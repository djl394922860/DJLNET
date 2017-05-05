using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    public class DataTablesResult<TEntity>
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="draw0">请求次数计数器</param>
        /// <param name="recordsTotal0">总共记录数</param>
        /// <param name="recordsFiltered0">过滤后的记录数</param>
        /// <param name="data0">数据</param>
        public DataTablesResult(int draw0, int recordsTotal0, int recordsFiltered0, IReadOnlyList<TEntity> data0)
        {
            draw = draw0;
            recordsTotal = recordsTotal0;
            recordsFiltered = recordsFiltered0;
            data = data0;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="error0">服务器错误信息</param>
        public DataTablesResult(string error0)
        {
            error = error0;
        }

        /// <summary>
        ///     请求次数计数器
        /// </summary>
        public int draw { get; set; }

        /// <summary>
        ///     总共记录数
        /// </summary>
        public int recordsTotal { get; set; }

        /// <summary>
        ///     过滤后的记录数
        /// </summary>
        public int recordsFiltered { get; set; }

        /// <summary>
        ///     数据
        /// </summary>
        public IReadOnlyList<TEntity> data { get; set; }

        /// <summary>
        ///     错误信息
        /// </summary>
        public string error { get; set; }
    }
}
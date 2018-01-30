using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Common.Utility.Model
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 对象名称
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页面索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 查询字段
        /// </summary>
        public string SelectParameters { get; set; }
        /// <summary>
        /// 筛选条件
        /// </summary>
        public string SortParameters { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string SortOrder { get; set; }
    }
}

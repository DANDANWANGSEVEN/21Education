using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _21Education.WebSite.Models
{
    /// <summary>
    /// 分页
    /// </summary>
    public class Pagination
    {
        public Pagination()
        {
            this.PageIndex = 0;
            this.PageSize = 20;
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageCurrent { get { return PageIndex + 1; } }
        /// <summary>
        /// 当前页，索引从0开始。
        /// </summary>
        public int PageIndex { get; set; }
        public int PageIndexReal { get { return PageIndex + 1; } }
        int _pageSize = 0;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                if (_pageSize <= 0)
                {
                    _pageSize = 20;
                }
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                long num = RecordCount / (long)PageSize;
                if (RecordCount % PageSize > 0)
                {
                    num++;
                }
                return (int)num;
            }
        }
        /// <summary>
        /// 总数据量
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// 是否加载页码跳转按钮
        /// </summary>
        public bool IsLoadNumBtn { get; set; }
        /// <summary>
        /// 页码跳转按钮个数
        /// </summary>
        public int NumBtnSize { get; set; }
        public string OrderBy { get; set; }
        public string OrderByDescending { get; set; }
    }
}
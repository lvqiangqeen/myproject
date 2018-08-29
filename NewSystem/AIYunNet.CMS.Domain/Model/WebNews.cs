using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebNews")]
    public class WebNews
    {
        [Key]
        [Column("ContentID")]
        public int ContentID
        {
            set;
            get;
        }
        /// <summary>
        /// 标题
        /// </summary>
        [Column("Title")]
        public string Title
        {
            set;
            get;
        }
        /// <summary>
        /// 副标题
        /// </summary>
        [Column("SubTitle")]
        public string SubTitle
        {
            set;
            get;
        }
        /// <summary>
        /// 简介
        /// </summary>
        [Column("Summary")]
        public string Summary
        {
            set;
            get;
        }
        [Column("Description")]
        public string Description
        {
            set;
            get;
        }
        [Column("ImageUrl")]
        public string ImageUrl
        {
            set;
            get;
        }
        [Column("thumbnailImage")]
        public string thumbnailImage
        {
            set;
            get;
        }
        [Column("NormalImageUrl")]
        public string NormalImageUrl
        {
            set;
            get;
        }
        [Column("CreatedDate")]
        public DateTime CreatedDate
        {
            set;
            get;
        }
        [Column("CreatedUserID")]
        public int CreatedUserID
        {
            set;
            get;
        }
        [Column("LastEditUserID")]
        public int? LastEditUserID
        {
            set;
            get;
        }
        [Column("LastEditDate")]
        public DateTime? LastEditDate
        {
            set;
            get;
        }
        [Column("LinkUrl")]
        public string LinkUrl
        {
            set;
            get;
        }
        [Column("PvCount")]
        public int PvCount
        {
            set;
            get;
        }
        [Column("State")]
        public Int16? State
        {
            set;
            get;
        }
        [Column("ClassID")]
        public int ClassID
        {
            set;
            get;
        }
        [Column("ClassName")]
        public string ClassName
        {
            set;
            get;
        }
        [Column("Keywords")]
        public string Keywords
        {
            set;
            get;
        }
        [Column("Sequence")]
        public int Sequence
        {
            set;
            get;
        }
        [Column("IsRecomend")]
        public bool IsRecomend
        {
            set;
            get;
        }
        [Column("IsHot")]
        public bool IsHot
        {
            set;
            get;
        }
        [Column("IsColor")]
        public bool IsColor
        {
            set;
            get;
        }
        [Column("IsTop")]
        public bool IsTop
        {
            set;
            get;
        }
        [Column("Attachment")]
        public string Attachment
        {
            set;
            get;
        }
        [Column("Remary")]
        public string Remary
        {
            set;
            get;
        }
        [Column("TotalComment")]
        public int TotalComment
        {
            set;
            get;
        }
        [Column("TotalSupport")]
        public int TotalSupport
        {
            set;
            get;
        }
        [Column("TotalFav")]
        public int TotalFav
        {
            set;
            get;
        }
        [Column("TotalShare")]
        public int TotalShare
        {
            set;
            get;
        }
        [Column("BeFrom")]
        public string BeFrom
        {
            set;
            get;
        }
        [Column("FileName")]
        public string FileName
        {
            set;
            get;
        }
        [Column("Meta_Title")]
        public string Meta_Title
        {
            set;
            get;
        }
        [Column("Meta_Description")]
        public string Meta_Description
        {
            set;
            get;
        }
        [Column("Meta_Keywords")]
        public string Meta_Keywords
        {
            set;
            get;
        }

        [Column("SeoUrl")]
        public string SeoUrl
        {
            set;
            get;
        }

        [Column("SeoImageAlt")]
        public string SeoImageAlt
        {
            set;
            get;
        }

        [Column("SeoImageTitle")]
        public string SeoImageTitle
        {
            set;
            get;
        }

        [Column("StaticUrl")]
        public string StaticUrl
        {
            set;
            get;
        }

        [Column("CompanyID")]
        public int? CompanyID { get; set; }

        [Column("FlagDelete")]
        public int FlagDelete { get; set; }

        [Column("PageViewCount")]
        public int PageViewCount { get; set; }

        [Column("CollectCount")]
        public int CollectCount { get; set; }
        [Column("ParentID")]
        public int ParentID { get; set; }
        public WebNews()
        {
            CollectCount = 0;
            PageViewCount = 0;
            FlagDelete = 0;
            Sequence = 0;
            ParentID = 0;
            CreatedDate = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebImg")]
    public class WebImg
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ImgId")]
        public long ImgId { get; set; }
        /// <summary>
        /// 图库名字
        /// </summary>
        [Column("ImgTitle")]
        public string ImgTitle { get; set; }
        /// <summary>
        /// 图库简介
        /// </summary>
        [Column("ImgInfo")]
        public string ImgInfo { get; set; }
        /// <summary>
        /// 图库详情
        /// </summary>
        [Column("ImgContent")]
        public string ImgContent { get; set; }
        /// <summary>
        /// 图库属性Id
        /// </summary>
        [Column("ImgPropertyId")]
        public long ImgPropertyId { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
        /// <summary>
        /// 图库展示图标
        /// </summary>
        [Column("ImgUrl")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 软装设计
        /// </summary>
        [Column("softcoverstyle")]
        public int softcoverstyle { get; set; }
        /// <summary>
        /// 酒店设计
        /// </summary>
        [Column("hotalstyle")]
        public int hotalstyle { get; set; }
        /// <summary>
        /// 名师作品
        /// </summary>
        [Column("designerrstyle")]
        public int designerrstyle { get; set; }
        /// <summary>
        /// 商业空间
        /// </summary>
        [Column("commercialstyle")]
        public int commercialstyle { get; set; }
        /// <summary>
        /// 别墅类型
        /// </summary>
        [Column("housestyle")]
        public int housestyle { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        [Column("IsPublish")]
        public bool IsPublish { get; set; }
        /// <summary>
        /// 至首
        /// </summary>
        [Column("IsTop")]
        public bool IsTop { get; set; }
        /// <summary>
        /// 添加事件
        /// </summary>
        [Column("addon")]
        public DateTime? addon { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("editon")]
        public DateTime? editon { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("deleteon")]
        public DateTime? deleteon { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("flagdelete")]
        public int FlagDelete { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column("browsecount")]
        public long? browsecount { get; set; }

        [Column("CollectCount")]
        public int CollectCount { get; set; }

        [Column("ImgJzspce")]
        public int ImgJzspce { get; set; }

        [Column("ImgGzspace")]
        public int ImgGzspace { get; set; }

        [Column("ImgJzstyle")]
        public int ImgJzstyle { get; set; }

        [Column("CompanyID")]
        public int CompanyID { get; set; }

        [Column("PeopleID")]
        public int PeopleID { get; set; }

        [Column("DecType")]
        public int DecType { get; set; }
        public WebImg()
        {
            CollectCount = 0;
            browsecount = 0;
            addon = DateTime.Now;
            editon = DateTime.Now;
            FlagDelete = 0;
            softcoverstyle = 0;
            PeopleID = 0;
            CompanyID = 0;
            ImgJzstyle = 0;
            ImgGzspace = 0;
            ImgJzspce = 0;
            housestyle = 0;
            commercialstyle = 0;
            designerrstyle = 0;
            hotalstyle = 0;
            softcoverstyle = 0;
            DecType = 0;
        }
    }


    public class WebImgPage
    {
        public WebImg img { get; set; }
        public WebPeople people { get; set; }
        public WebCompany company { get; set; }
    }
}

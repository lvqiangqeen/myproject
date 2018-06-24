using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuiding")]
    public class WebBuiding
    {
        /// <summary>
        /// BuidingID
        /// </summary>
        [Key]
        [Column("BuidingID")]
        public int BuidingID { get; set; }
        /// <summary>
        /// BuidingTitle
        /// </summary>
        [Column("BuidingTitle")]
        public string BuidingTitle { get; set; }
        /// <summary>
        /// BuidingBrief
        /// </summary>
        [Column("BuidingBrief")]
        public string BuidingBrief { get; set; }
        /// <summary>
        /// BuidingInfo
        /// </summary>
        [Column("BuidingInfo")]
        public string BuidingInfo { get; set; }
        /// <summary>
        /// CompanyID
        /// </summary>
        [Column("CompanyID")]
        public int CompanyID { get; set; }
        /// <summary>
        /// WorkerID
        /// </summary>
        [Column("WorkerID")]
        public int WorkerID { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
        /// <summary>
        /// BuidingImage
        /// </summary>
        [Column("BuidingImage")]
        public string BuidingImage { get; set; }
        /// <summary>
        /// ShowOrder
        /// </summary>
        [Column("ShowOrder")]
        public int ShowOrder { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        [Column("AddOn")]
        public DateTime AddOn { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        [Column("EditOn")]
        public DateTime EditOn { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        [Column("FlagDelete")]
        public int FlagDelete { get; set; }
        /// <summary>
        /// PageViewCount
        /// </summary>
        [Column("PageViewCount")]
        public int PageViewCount { get; set; }
        /// <summary>
        /// CollectCount
        /// </summary>
        [Column("CollectCount")]
        public int CollectCount { get; set; }
        /// <summary>
        /// ZanCount
        /// </summary>
        [Column("ZanCount")]
        public int ZanCount { get; set; }
        /// <summary>
        /// CommentCount
        /// </summary>
        [Column("CommentCount")]
        public int CommentCount { get; set; }
        /// <summary>
        /// IsHot
        /// </summary>
        [Column("IsHot")]
        public bool IsHot { get; set; }
        /// <summary>
        /// IsTop
        /// </summary>
        [Column("IsTop")]
        public bool IsTop { get; set; }

        [Column("Price")]
        public double Price { get; set; }

        [Column("Space")]
        public double Space { get; set; }

        [Column("constructionstageID")]
        public string constructionstageID { get; set; }

        [Column("constructionstage")]
        public string constructionstage { get; set; }

        [Column("ResultID")]
        public int ResultID { get; set; }

        [Column("StartTime")]
        public string StartTime { get; set; }

        [Column("StageNow")]
        public int StageNow { get; set; }

        [Column("EndTime")]
        public string EndTime { get; set; }

        [Column("superviseName")]
        public string superviseName { get; set; }

        [Column("UserID")]
        public int UserID { get; set; }
        [Column("DemandID")]
        public int DemandID { get; set; }
        /// <summary>
        /// 工人确定完成（0没完成，1完成）
        /// </summary>
        [Column("IsWorkerEnd")]
        public int IsWorkerEnd { get; set; }
        /// <summary>
        /// 业主确定是否完工（0没有确定，1确认完工，2延时）
        /// </summary>
        [Column("IsUserEnd")]
        public int IsUserEnd { get; set; }
        [Column("Guid")]
        public string Guid { get; set; }
        /// <summary>
        /// 质保到期时间
        /// </summary>
        [Column("QualityTime")]
        public string QualityTime { get; set; }
        /// <summary>
        /// 是否已评价0没有1一次2两次
        /// </summary>
        [Column("IsComment")]
        public int IsComment { get; set; }
        

        [NotMapped]
        public string StageNowDesc { get; set; }
        public WebBuiding()
        {
            Guid = "";
            CompanyID = 0;
            WorkerID = 0;
            ShowOrder = 0;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            //EndTime=
            FlagDelete = 0;
            PageViewCount = 0;
            CollectCount = 0;
            ZanCount = 0;
            CommentCount = 0;
            IsHot = false;
            IsTop = false;
            Price = 0;
            Space = 0;
            ResultID = 0;
            StageNow = 0;
            UserID = 0;
            DemandID = 0;
            constructionstageID = "";
            constructionstage = "";
            IsWorkerEnd = 0;
            IsUserEnd = 0;
            IsComment = 0;
        }


    }

    public class BuidingDetail
    {
        public WebWorker woker { get; set; }
        public WebBuiding buiding { get; set; }
        public List<WebBuidingStagesAndWorker> stagelist { get; set; }
        public DecDemand demand { get; set; }
        public WebBuidingCaseComment comment { get; set; }
    }
}

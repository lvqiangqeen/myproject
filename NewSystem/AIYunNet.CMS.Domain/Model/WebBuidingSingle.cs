using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidingSingle")]
    public class WebBuidingSingle
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// 工序阶段ID 没有用了
        /// </summary>
        [Column("WebBuidingStageID")]
        public int WebBuidingStageID { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [Column("Title")]
        public string Title { get; set; }
        /// <summary>
        /// TimeStageInfo
        /// </summary>
        [Column("TimeStageInfo")]
        public string TimeStageInfo { get; set; }
        /// <summary>
        /// TimeStageContent
        /// </summary>
        [Column("TimeStageContent")]
        public string TimeStageContent { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        [Column("AddTime")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// sortID
        /// </summary>
        [Column("sortID")]
        public int sortID { get; set; }
        /// <summary>
        /// endtime
        /// </summary>
        [Column("endtime")]
        public string endtime { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        [Column("FlagDelete")]
        public bool FlagDelete { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// TimeStageThumContent
        /// </summary>
        [Column("TimeStageThumContent")]
        public string TimeStageThumContent { get; set; }
        /// <summary>
        /// WorkerID
        /// </summary>
        [Column("WorkerID")]
        public int WorkerID { get; set; }
        /// <summary>
        /// DemandID
        /// </summary>
        [Column("DemandID")]
        public int DemandID { get; set; }
        /// <summary>
        /// IsUserEnd
        /// </summary>
        [Column("IsUserEnd")]
        public int IsUserEnd { get; set; }
        /// <summary>
        /// IsWorkerEnd
        /// </summary>
        [Column("IsWorkerEnd")]
        public int IsWorkerEnd { get; set; }
        /// <summary>
        /// 业主
        /// </summary>
        [Column("UserID")]
        public int UserID { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        [Column("Guid")]
        public string Guid { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Column("Price")]
        public double Price { get; set; }
        /// <summary>
        /// Space
        /// </summary>
        [Column("Space")]
        public double Space { get; set; }
        /// <summary>
        /// BuidingSingleImage
        /// </summary>
        [Column("BuidingSingleImage")]
        public string BuidingSingleImage { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        [Column("EditOn")]
        public string EditOn { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        [Column("AddOn")]
        public DateTime AddOn { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        [Column("Info")]
        public string Info { get; set; }
        public WebBuidingSingle()
        {
            FlagDelete = false;
            AddTime = DateTime.Now;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now.ToString();
            WebBuidingStageID = 0;
            Price = 0;
            Space = 0;
            UserID = 0;
            WorkerID = 0;
            DemandID = 0;
            IsUserEnd = 0;
            IsWorkerEnd = 0;
            Info = "";
        }
    }
}

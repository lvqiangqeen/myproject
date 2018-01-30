using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidingTimeStages")]
    public class WebBuidingTimeStages
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// 工序阶段ID
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

        [Column("TimeStageThumContent")]
        public string TimeStageThumContent { get; set; }
        public WebBuidingTimeStages()
        {
            FlagDelete = false;
            AddTime = DateTime.Now;
            WebBuidingStageID = 0;
        }
    }
}

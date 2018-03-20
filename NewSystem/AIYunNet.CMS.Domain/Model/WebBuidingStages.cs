using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidingStages")]
    public class WebBuidingStages
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// WebBuidingID
        /// </summary>
        [Column("WebBuidingID")]
        public int WebBuidingID { get; set; }
        /// <summary>
        /// WebLookup中的ID
        /// </summary>
        [Column("StageID")]
        public int StageID { get; set; }
        /// <summary>
        /// StageName
        /// </summary>
        [Column("StageName")]
        public string StageName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("sortID")]
        public int sortID { get; set; }
        /// <summary>
        /// StageContent
        /// </summary>
        [Column("StageContent")]
        public string StageContent { get; set; }
        /// <summary>
        /// 完工时间
        /// </summary>
        [Column("CompleteTime")]
        public string CompleteTime { get; set; }
        /// <summary>
        ///是否完工
        /// </summary>
        [Column("IsComplete")]
        public bool IsComplete { get; set; }
        /// <summary>
        ///是否审核通过（0没有审核，1通过，2没通过）
        /// </summary>
        [Column("IsUserEnd")]
        public int IsUserEnd { get; set; }
        /// <summary>
        ///工长id
        /// </summary>
        [Column("Workerleaderid")]
        public int Workerleaderid { get; set; }
        /// <summary>
        ///工人id
        /// </summary>
        [Column("Workerid")]
        public int Workerid { get; set; }
        /// <summary>
        ///图组
        /// </summary>
        [Column("ImgContent")]
        public string ImgContent { get; set; }
        /// <summary>
        ///缩略图组
        /// </summary>
        [Column("thumContent")]
        public string thumContent { get; set; }
        public WebBuidingStages()
        {
            WebBuidingID = 0;
            StageID = 0;
            IsComplete = false;
            StageContent = "";
            IsUserEnd = 0;
            Workerleaderid = 0;
            Workerid = 0;
        }
    }

    public class WebBuidingStagesAndWorker
    {
        public WebBuidingStages stage { get; set; }
        public WebWorker worker { get; set; }

        public WebBuidingStagesAndWorker()
        {
            stage = new WebBuidingStages();
            worker = new WebWorker();
        }
    }
}

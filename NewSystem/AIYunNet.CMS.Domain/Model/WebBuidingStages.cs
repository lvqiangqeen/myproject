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

        public WebBuidingStages()
        {
            WebBuidingID = 0;
            StageID = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidTogether")]
    public class WebBuidTogether
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// PublishWorkerid
        /// </summary>
        [Column("PublishWorkerid")]
        public int PublishWorkerid { get; set; }
        /// <summary>
        /// GetWorkerid
        /// </summary>
        [Column("GetWorkerid")]
        public int GetWorkerid { get; set; }
        /// <summary>
        /// buidingID
        /// </summary>
        [Column("buidingID")]
        public int buidingID { get; set; }
        /// <summary>
        /// StageID
        /// </summary>
        [Column("StageID")]
        public int StageID { get; set; }
        /// <summary>
        /// 0没有查看,1接受,2拒绝
        /// </summary>
        [Column("IsAccept")]
        public int IsAccept { get; set; }

        public WebBuidTogether()
        {
            IsAccept = 0;
        }
    }
}

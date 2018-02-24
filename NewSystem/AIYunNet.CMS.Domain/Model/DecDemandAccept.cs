using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("DecDemandAccept")]
    public class DecDemandAccept
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// GetUserID
        /// </summary>
        [Column("GetUserID")]
        public int GetUserID { get; set; }
        /// <summary>
        /// DemandGuid
        /// </summary>
        [Column("DemandGuid")]
        public string DemandGuid { get; set; }
        /// <summary>
        /// PublicUserID
        /// </summary>
        [Column("PublicUserID")]
        public int PublicUserID { get; set; }
        /// <summary>
        /// 是否接受需求
        /// </summary>
        [Column("IsAccept")]
        public int IsAccept { get; set; }
    }
}

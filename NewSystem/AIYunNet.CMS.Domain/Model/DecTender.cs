using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("DecTender")]
    public class DecTender
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        [Column("Guid")]
        public string Guid { get; set; }
        /// <summary>
        /// 投标者ID
        /// </summary>
        [Column("UserID")]
        public int UserID { get; set; }
        /// <summary>
        /// 投标者姓名
        /// </summary>
        [Column("perName")]
        public string perName { get; set; }
        /// <summary>
        /// perPhone
        /// </summary>
        [Column("perPhone")]
        public string perPhone { get; set; }
        /// <summary>
        /// perInfo
        /// </summary>
        [Column("perInfo")]
        public string perInfo { get; set; }
        /// <summary>
        /// 是否被业主接受0未看1接受2未接受
        /// </summary>
        [Column("IsAccept")]
        public int IsAccept { get; set; }
        /// <summary>
        /// Addon
        /// </summary>
        [Column("Addon")]
        public DateTime Addon { get; set; }
        public DecTender()
        {
            Addon = DateTime.Now;
            IsAccept = 0;
            perInfo = "";
            perPhone = "";
            perName = "";
            UserID = 0;
            Guid = "";
        }
    }
}

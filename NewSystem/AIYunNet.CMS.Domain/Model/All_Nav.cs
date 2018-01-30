using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("All_Nav")]
    public class All_Nav
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// navtitle
        /// </summary>
        [Column("navtitle")]
        public string navtitle { get; set; }
        /// <summary>
        /// url
        /// </summary>
        [Column("url")]
        public string url { get; set; }
        /// <summary>
        /// orderid
        /// </summary>
        [Column("orderid")]
        public int orderid { get; set; }
        /// <summary>
        /// fatherid
        /// </summary>
        [Column("fatherid")]
        public int fatherid { get; set; }
        /// <summary>
        /// isdelete
        /// </summary>
        [Column("isdelete")]
        public bool isdelete { get; set; }
    }
}

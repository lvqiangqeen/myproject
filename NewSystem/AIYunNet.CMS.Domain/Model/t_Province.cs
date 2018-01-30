using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("t_Province")]
    public class t_Province
    {
        /// <summary>
        /// id
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// otherid
        /// </summary>
        [Column("otherid")]
        public int otherid { get; set; }
        /// <summary>
        /// provinceID
        /// </summary>
        [Key]
        [Column("provinceID")]
        public string provinceID { get; set; }
        /// <summary>
        /// province
        /// </summary>
        [Column("province")]
        public string province { get; set; }
    }
}

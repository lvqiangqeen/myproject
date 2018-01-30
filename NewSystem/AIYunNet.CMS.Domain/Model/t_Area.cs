using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("t_Area")]
    public class t_Area
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
        /// areaID
        /// </summary>
        [Key]
        [Column("areaID")]
        public string areaID { get; set; }
        /// <summary>
        /// area
        /// </summary>
        [Column("area")]
        public string area { get; set; }
        /// <summary>
        /// father
        /// </summary>
        [Column("father")]
        public string father { get; set; }
        /// <summary>
        /// flagdelete
        /// </summary>
        [Column("flagdelete")]
        public int flagdelete { get; set; }

    }
}

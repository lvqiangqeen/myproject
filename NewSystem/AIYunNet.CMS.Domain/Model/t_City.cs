using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("t_City")]
    public class t_City
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
        /// cityID
        /// </summary>
        [Key]
        [Column("cityID")]
        public string cityID { get; set; }
        /// <summary>
        /// city
        /// </summary>
        [Column("city")] 
        public string city { get; set; }
        /// <summary>
        /// father
        /// </summary>
        [Column("father")]
        public string father { get; set; }
        /// <summary>
        /// hotcity
        /// </summary>
        [Column("hotcity")]
        public int hotcity { get; set; }

        [Column("orderid")]
        public int orderid { get; set; }
        
    }
}

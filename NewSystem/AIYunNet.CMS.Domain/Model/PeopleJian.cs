using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("PeopleJian")]
    public class PeopleJian
    {
        /// <summary>
        /// peopleid
        /// </summary>
        [Key]
        [Column("peopleid")]
        public int peopleid { get; set; }
        /// <summary>
        /// peoplename
        /// </summary>
        [Column("peoplename")]
        public string peoplename { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        [Column("Sex")]
        public string Sex { get; set; }
        /// <summary>
        /// age
        /// </summary>
        [Column("age")]
        public string age { get; set; }
        /// <summary>
        /// weight
        /// </summary>
        [Column("weight")]
        public string weight { get; set; }
        /// <summary>
        /// height
        /// </summary>
        [Column("height")]
        public string height { get; set; }

        [Column("AddOn")]
        public DateTime AddOn { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        [Column("EditOn")]
        public DateTime EditOn { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        [Column("FlagDelete")]
        public int FlagDelete { get; set; }

        public PeopleJian()
        {
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            FlagDelete = 0;
        }
    }
}

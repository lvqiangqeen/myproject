using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("DownLoadType")]
    public class DownLoadType
    {
        public DownLoadType()
        {
            typeid = 0;
            Isdelete = 0;
        }
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("Isdelete")]
        public int Isdelete { get; set; }
        /// <summary>
        /// name
        /// </summary>
        [Column("name")]
        public string name { get; set; }
        /// <summary>
        /// fatherID
        /// </summary>
        [Column("fatherID")]
        public int fatherID { get; set; }
        /// <summary>
        /// typeid
        /// </summary>
        [Column("typeid")]
        public int typeid { get; set; }
        /// <summary>
        /// LookupID
        /// </summary>
        [Column("LookupID")]
        public int LookupID { get; set; }
    }

    public class DownloadTypeList
    {
        public int typeid { get; set; }
        public string typename { get; set; }
        public List<DownLoadType> list { get; set; }

    }

}

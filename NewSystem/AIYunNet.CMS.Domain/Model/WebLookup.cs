using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{

    [Table("WebLookup")]
    public class WebLookup
    {
        [Key]
        [Column("lookup_id")]
        public int LookupID { get; set; }

        [Column("lookup_key")]
        public string LookupKey { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("Englishname")]
        public string EnglishName { get; set; }

        [Column("col2")]
        public string Col2 { get; set; }

        [Column("display")]
        public int Display { get; set; }

        public WebLookup()
        {
            Display = 1;
        }
    }
}

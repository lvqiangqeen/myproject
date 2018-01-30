using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCaseRelationship")]
    public class WebCaseRelationship
    {
        [Key]
        [Column("case_relationship_id")]
        public int CaseRelationshiID { get; set; }
     
        [Column("type")]
        public string Type { get; set; }

        [Column("original_id")]
        public string OriginalID { get; set; }

        [Column("lookup_id")]
        public string LookupID { get; set; }

        [Column("lookup_code")]
        public string LookupCode { get; set; }

        [Column("flag_delete")]
        public int FlagDelete { get; set; }
    }
}

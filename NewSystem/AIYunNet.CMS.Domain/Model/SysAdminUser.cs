using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("SysAdminUser")]
    public class SysAdminUser
    {
        [Key]
        [Column("UserID")]
        public int UserID { get; set; }

        [Column("UserAccount")]
        public string UserAccount { get; set; }

        [Column("UserPassword")]
        public string UserPassword { get; set; }

        [Column("CompanyID")]
        public int? CompanyID { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("RoleType")]
        public int RoleType { get; set; }

        [Column("IsUse")]
        public bool IsUse { get; set; }

        [Column("addon")]
        public DateTime AddOn { get; set; }

        [Column("editon")]
        public DateTime? EditOn { get; set; }

        [Column("deleteon")]
        public DateTime? DeleteOn { get; set; }

        [Column("flag_delete")]
        public Int32 FlagDelete { get; set; }

        public SysAdminUser()
        {
            AddOn = DateTime.Now;
        }
    }
}

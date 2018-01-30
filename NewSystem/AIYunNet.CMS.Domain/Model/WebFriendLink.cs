using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebFriendLink")]
    public class WebFriendLink
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("ImgUrl")]
        public string ImgUrl { get; set; }

        [Column("LinkUrl")]
        public string LinkUrl { get; set; }

        [Column("LinkDesc")]
        public string LinkDesc { get; set; }

        [Column("State")]
        public Int16 State { get; set; }

        [Column("ShowOrder")]
        public int ShowOrder { get; set; }

        [Column("IsDisplay")]
        public bool IsDisplay { get; set; }

        [Column("addon")]
        public DateTime? AddOn { get; set; }

        [Column("editon")]
        public DateTime? EditOn { get; set; }

        [Column("deleteon")]
        public DateTime? DeleteOn { get; set; }

        [Column("FlagDelete")]
        public Int16 FlagDelete { get; set; }

        public WebFriendLink()
        {
            AddOn = DateTime.Now;
            FlagDelete = 0;
            ShowOrder = 0;
        }

    }
}

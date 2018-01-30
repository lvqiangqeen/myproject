using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebFile")]
    public class WebFile
    {
        [Key]
        [Column("FileID")]
        public int FileID { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("InUser")]
        public int InUser { get; set; }

        [Column("InTime")]
        public DateTime? InTime { get; set; }

        [Column("Sequence")]
        public int Sequence { get; set; }

        [Column("ClassID")]
        public int ClassID { get; set; }

        [Column("ClassName")]
        public string ClassName { get; set; }

        [Column("FileName")]
        public string FileName { get; set; }

        [Column("Tags")]
        public string Tags { get; set; }

        [Column("Remark")]
        public string Remark { get; set; }

        [Column("Click")]
        public int Click { set; get; }

        [Column("FileType")]
        public string FileType { get; set; }

        [Column("company_id")]
        public string CompanyId { get; set; }

        [Column("addon")]
        public DateTime? AddOn { get; set; }

        [Column("editon")]
        public DateTime? Editon { get; set; }

        [Column("deleteon")]
        public DateTime? Deleteon { get; set; }

        [Column("flag_delete")]
        public int FlagDelete { get; set; }

        public WebFile()
        {
            AddOn = DateTime.Now;
            FlagDelete = 0;
            Sequence = 0;
        }

    }
}

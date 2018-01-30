using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebMenu")]
    public class WebMenu
    {
        
        ///<summary>
        ///WebMenuID
        ///</summary>
        [Key]
        [Column("WebMenuID")]
        public int WebMenuID { get; set; }
        ///<summary>
        ///WebMenuName
        ///</summary>
        [Column("WebMenuName")]
        public string WebMenuName { get; set; }
        ///<summary>
        ///EnglishName
        ///</summary>
        [Column("EnglishName")]
        public string EnglishName { get; set; }
        ///<summary>
        ///ParentName
        ///</summary>
        [Column("ParentName")]
        public string ParentName { get; set; }
        ///<summary>
        ///ParentID
        ///</summary>
        [Column("ParentID")]
        public int ParentID { get; set; }
        ///<summary>
        ///ShowUrl
        ///</summary>
        [Column("ShowUrl")]
        public string ShowUrl { get; set; }
        ///<summary>
        ///ImageUrl
        ///</summary>
        [Column("ImageUrl")]
        public string ImageUrl { get; set; }
        ///<summary>
        ///IsDisplay
        ///</summary>
        [Column("IsDisplay")]
        public bool IsDisplay { get; set; }
        ///<summary>
        ///ShowOrder
        ///</summary>
        [Column("ShowOrder")]
        public int ShowOrder { get; set; }
        ///<summary>
        ///Style
        ///</summary>
        [Column("Style")]
        public string Style { get; set; }
        ///<summary>
        ///addon
        ///</summary>
        [Column("addon")]
        public DateTime? AddOn { get; set; }
        ///<summary>
        ///editon
        ///</summary>
        [Column("editon")]
        public DateTime? EditOn { get; set; }
        ///<summary>
        ///deleteon
        ///</summary>
        [Column("deleteon")]
        public DateTime? DeleteOn { get; set; }
        ///<summary>
        ///flag_delete
        ///</summary>
        [Column("flag_delete")]
        public int FlagDelete { get; set; }

        public WebMenu()
        {
            FlagDelete = 0;
            AddOn = DateTime.Now;
            ShowOrder = 0;
        }
    }
}

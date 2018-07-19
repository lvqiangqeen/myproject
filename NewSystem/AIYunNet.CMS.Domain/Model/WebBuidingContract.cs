using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidingContract")]
    public class WebBuidingContract
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        [Column("Guid")]
        public string Guid { get; set; }
        /// <summary>
        /// filename
        /// </summary>
        [Column("filename")]
        public string filename { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
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
        /// IsDelete
        /// </summary>
        [Column("IsDelete")]
        public int IsDelete { get; set; }
        /// <summary>
        /// 合同是否合格1合格2不合格0没有检查
        /// </summary>
        [Column("IsPass")]
        public int IsPass { get; set; }
        /// <summary>
        /// imgcontract
        /// </summary>
        [Column("imgcontract")]
        public string imgcontract { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }

        public WebBuidingContract()
        {
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            thumbnailImage = "";
            IsDelete = 0;
            IsPass = 0;
        }
    }
}

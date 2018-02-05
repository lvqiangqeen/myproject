using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCaseImg")]
    public class WebCaseImg
    {
        /// <summary>
        /// imgID
        /// </summary>
        [Key]
        [Column("imgID")]
        public int imgID { get; set; }
        /// <summary>
        /// imgName
        /// </summary>
        [Column("imgName")]
        public string imgName { get; set; }
        /// <summary>
        /// Img
        /// </summary>
        [Column("Img")]
        public string Img { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
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
        /// FlagDelete
        /// </summary>
        [Column("FlagDelete")]
        public int FlagDelete { get; set; }
        /// <summary>
        /// WebCaseID
        /// </summary>
        [Column("WebCaseID")]
        public int WebCaseID { get; set; }
        /// <summary>
        /// 装修类型1是家装2是工装
        /// </summary>
        [Column("DecType")]
        public int DecType { get; set; }
        /// <summary>
        /// 工装类型Case_gz_style
        /// </summary>
        [Column("GzStyle")]
        public int GzStyle { get; set; }
        /// <summary>
        /// 家装Case_Style
        /// </summary>
        [Column("JzStyle")]
        public int JzStyle { get; set; }
        /// <summary>
        /// 家装空间(厨房,客厅)
        /// </summary>
        [Column("JzSpace")]
        public int JzSpace { get; set; }
        /// <summary>
        /// PeopleID
        /// </summary>
        [Column("PeopleID")]
        public int PeopleID { get; set; }
        /// <summary>
        /// CompanyID
        /// </summary>
        [Column("CompanyID")]
        public int CompanyID { get; set; }
        [Column("PeopleName")]
        public string PeopleName { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }

        public WebCaseImg()
        {
            CompanyID = 0;
            PeopleID = 0;
            JzSpace = 0;
            JzStyle = 0;
            GzStyle = 0;
            DecType = 0;
            WebCaseID = 0;
            FlagDelete = 0;
            EditOn = DateTime.Now;
            AddOn = DateTime.Now;
        }
    }
}

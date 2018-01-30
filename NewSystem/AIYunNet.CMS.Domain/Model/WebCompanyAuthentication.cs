using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCompanyAuthentication")]
    public class WebCompanyAuthentication
    {
        /// <summary>
        /// AuID
        /// </summary>
        [Key]
        [Column("AuID")]
        public int AuID { get; set; }
        /// <summary>
        /// PeopleName
        /// </summary>
        [Column("PeopleName")]
        public string PeopleName { get; set; }
        /// <summary>
        /// PeopleIdentity
        /// </summary>
        [Column("PeopleIdentity")]
        public string PeopleIdentity { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        /// <summary>
        /// CompanyUserID
        /// </summary>
        [Column("CompanyUserID")]
        public int CompanyUserID { get; set; }
        /// <summary>
        /// CompanyID
        /// </summary>
        [Column("CompanyID")]
        public int CompanyID { get; set; }
        /// <summary>
        /// ShenfenZ
        /// </summary>
        [Column("ShengfenZ")]
        public string ShengfenZ { get; set; }
        /// <summary>
        /// ShenfenF
        /// </summary>
        [Column("ShengfenF")]
        public string ShengfenF { get; set; }
        /// <summary>
        /// ZthumbnailImage
        /// </summary>
        [Column("ZthumbnailImage")]
        public string ZthumbnailImage { get; set; }
        /// <summary>
        /// FthumbnailImage
        /// </summary>
        [Column("FthumbnailImage")]
        public string FthumbnailImage { get; set; }
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
        /// IsAuthentication
        /// </summary>
        [Column("IsAuthentication")]
        public int IsAuthentication { get; set; }
        /// <summary>
        /// UploadFile
        /// </summary>
        [Column("UploadFile")]
        public string UploadFile { get; set; }

        public WebCompanyAuthentication()
        {
            IsDelete = 0;
            IsAuthentication = 0;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
        }
    }
}

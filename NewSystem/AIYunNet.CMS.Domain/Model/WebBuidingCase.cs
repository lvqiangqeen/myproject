using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Configuration;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidingCase")]
    public class WebBuidingCase
    {
        public static string BuidingCaseHearder = ConfigurationManager.AppSettings["BuidingCaseHearder"];
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// title
        /// </summary>
        [Column("title")]
        public string title { get; set; }
        /// <summary>
        /// textimg
        /// </summary>
        [Column("textimg")]
        public string textimg { get; set; }
        /// <summary>
        /// textthumbnailImage
        /// </summary>
        [Column("textthumbnailImage")]
        public string textthumbnailImage { get; set; }
        /// <summary>
        /// headimg
        /// </summary>
        [Column("headimg")]
        public string headimg { get; set; }
        /// <summary>
        /// headthum
        /// </summary>
        [Column("headthum")]
        public string thumbnailImage { get; set; }
        /// <summary>
        /// info
        /// </summary>
        [Column("info")]
        public string info { get; set; }
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
        /// WorkerID
        /// </summary>
        [Column("WorkerID")]
        public int WorkerID { get; set; }
        /// <summary>
        /// UserID
        /// </summary>
        [Column("UserID")]
        public int UserID { get; set; }
        /// <summary>
        /// sorting
        /// </summary>
        [Column("sorting")]
        public int sorting { get; set; }

        public WebBuidingCase()
        {
            WorkerID = 0;
            UserID = 0;
            sorting = 0;
            IsDelete = 0;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            headimg = BuidingCaseHearder;
            thumbnailImage = BuidingCaseHearder;
            textimg = "";
            textthumbnailImage = "";
        }
    }
}

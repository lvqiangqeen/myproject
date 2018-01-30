using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("DownLoad")]
    public class DownLoad
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// title
        /// </summary>
        [Column("title")]
        public string title { get; set; }
        /// <summary>
        /// Size
        /// </summary>
        [Column("Size")]
        public string Size { get; set; }
        /// <summary>
        /// LookupCode
        /// </summary>
        [Column("LookupCode")]
        public int LookupCode { get; set; }
        /// <summary>
        /// firstID
        /// </summary>
        [Column("firstID")]
        public int firstID { get; set; }
        /// <summary>
        /// secondID
        /// </summary>
        [Column("secondID")]
        public int secondID { get; set; }
        /// <summary>
        /// 需要积分
        /// </summary>
        [Column("score")]
        public int score { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        [Column("Info")]
        public string Info { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Column("DownLoadImage")]
        public string DownLoadImage { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
        /// <summary>
        /// 上传者
        /// </summary>
        [Column("upbody")]
        public string upbody { get; set; }
        /// <summary>
        /// 上传者id
        /// </summary>
        [Column("userid")]
        public int userid { get; set; }
        /// <summary>
        /// 上传者类别
        /// </summary>
        [Column("usertype")]
        public string usertype { get; set; }
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
        public bool IsDelete { get; set; }
        /// <summary>
        /// fileurl
        /// </summary>
        [Column("fileurl")]
        public string fileurl { get; set; }
        /// <summary>
        /// DownloadCount
        /// </summary>
        [Column("DownloadCount")]
        public int DownloadCount { get; set; }
        //格式
        [Column("form")]
        public string form { get; set; }
        public DownLoad()
        {
            DownloadCount = 0;
            IsDelete = false;
            AddOn = DateTime.Now;
            EditOn= DateTime.Now;
            usertype = "";
            userid = 0;
            score = 0;
        }
    }
}

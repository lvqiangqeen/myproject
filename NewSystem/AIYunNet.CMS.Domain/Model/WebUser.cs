using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebUser")]
    public class WebUser
    {
        /// <summary>
        /// UserID
        /// </summary>
        [Key]
        [Column("UserID")]
        public int UserID { get; set; }
        /// <summary>
        /// 登录账号（Account）全部用手机
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Column("NickName")]
        public string NickName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Column("TrueName")]
        public string TrueName { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        [Column("Sex")]
        public string Sex { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }
        /// <summary>
        /// IsActivity
        /// </summary>
        [Column("IsActivity")]
        public bool IsActivity { get; set; }
        /// <summary>
        /// UserType
        /// </summary>
        [Column("UserType")]
        public string UserType { get; set; }
        /// <summary>
        /// InTime
        /// </summary>
        [Column("InTime")]
        public DateTime? InTime { get; set; }
        /// <summary>
        /// InIp
        /// </summary>
        [Column("InIp")]
        public string InIp { get; set; }
        /// <summary>
        /// InUser
        /// </summary>
        [Column("InUser")]
        public int InUser { get; set; }
        /// <summary>
        /// IsLock
        /// </summary>
        [Column("IsLock")]
        public bool IsLock { get; set; }
        /// <summary>
        /// 登录手机号
        /// </summary>
        [Column("Telephone")]
        public string Telephone { get; set; }
        /// <summary>
        /// Cellphone
        /// </summary>
        [Column("Cellphone")]
        public string Cellphone { get; set; }
        /// <summary>
        /// ZipCode
        /// </summary>
        [Column("ZipCode")]
        public string ZipCode { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        [Column("Fax")]
        public string Fax { get; set; }
        /// <summary>
        /// Score
        /// </summary>
        [Column("Score")]
        public int Score { get; set; }
        /// <summary>
        /// Position
        /// </summary>
        [Column("Position")]
        public string Position { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        [Column("Company")]
        public string Company { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        [Column("Address")]
        public string Address { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        [Column("EditOn")]
        public DateTime EditOn { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        [Column("AddOn")]
        public DateTime AddOn { get; set; }
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
        /// 职位类别ID
        /// </summary>
        [Column("PositionID")]
        public int PositionID { get; set; }
        /// <summary>
        /// 职位区分
        /// </summary>
        [Column("PositionCode")]
        public string PositionCode { get; set; }
        /// <summary>
        /// 职位类别
        /// </summary>
        [Column("PositionType")]
        public int PositionType { get; set; }

        public WebUser()
        {
            IsDelete = false;
            IsLock = false;
            IsActivity = false;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            PositionID = 0;
            PositionType = 0;
        }

    }
}

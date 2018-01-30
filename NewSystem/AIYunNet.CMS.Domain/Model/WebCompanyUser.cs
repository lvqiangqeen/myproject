using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCompanyUser")]
    public class WebCompanyUser
    {
        /// <summary>
		/// CompanyUserID
        /// </summary>	
        [Key]
        [Column("CompanyUserID")]
        public int CompanyUserID
        {
            get;
            set;
        }
        /// <summary>
        /// ComUserName
        /// </summary>	
        [Column("ComUserName")]
        public string ComUserName
        {
            get;
            set;
        }
        /// <summary>
        /// Password
        /// </summary>	
        [Column("Password")]
        public string Password
        {
            get;
            set;
        }
        /// <summary>
        /// CompanyName
        /// </summary>	
        [Column("CompanyName")]
        public string CompanyName
        {
            get;
            set;
        }
        /// <summary>
        /// 绑定手机同公司列表里的CompanyMoble
        /// </summary>	
        [Column("CompanyPhone")]
        public string CompanyPhone
        {
            get;
            set;
        }
        /// <summary>
        /// IsLock
        /// </summary>	
        [Column("IsLock")]
        public bool IsLock
        {
            get;
            set;
        }
        /// <summary>
        /// EditOn
        /// </summary>	
        [Column("EditOn")]
        public DateTime EditOn
        {
            get;
            set;
        }
        /// <summary>
        /// AddOn
        /// </summary>	
        [Column("AddOn")]
        public DateTime AddOn
        {
            get;
            set;
        }
        /// <summary>
        /// DeleteOn
        /// </summary>	
        [Column("DeleteOn")]
        public DateTime? DeleteOn
        {
            get;
            set;
        }
        /// <summary>
        /// IsDelete
        /// </summary>	
        [Column("IsDelete")]
        public bool IsDelete
        {
            get;
            set;
        }

        public WebCompanyUser()
        {
            IsDelete = false;
            EditOn= DateTime.Now;
            AddOn = DateTime.Now;
            IsLock = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCompanyGuarantMoney")]
    public class WebCompanyGuarantMoney
    {
        /// <summary>
		/// GmID
        /// </summary>	
        [Key]
        [Column("GmID")]
        public int GmID
        {
            get;
            set;
        }
        /// <summary>
        /// CompanyUserID
        /// </summary>	
        [Column("CompanyUserID")]
        public int CompanyUserID
        {
            get;
            set;
        }
        /// <summary>
        /// CompanyID
        /// </summary>	
        [Column("CompanyID")]
        public int CompanyID
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
        /// CompanyPhone
        /// </summary>	
        [Column("CompanyPhone")]
        public string CompanyPhone
        {
            get;
            set;
        }
        /// <summary>
        /// IsGuarantMoney
        /// </summary>	
        [Column("IsGuarantMoney")]
        public int IsGuarantMoney
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
        /// EditOn
        /// </summary>	
        [Column("EditOn")]
        public DateTime EditOn
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
        public int IsDelete
        {
            get;
            set;
        }
        public WebCompanyGuarantMoney()
        {
            IsGuarantMoney = 0;
            IsDelete = 0;
            EditOn = DateTime.Now;
            AddOn = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebPeopleGuarantMoney")]
    public class WebPeopleGuarantMoney
    {
        /// <summary>
		/// id
        /// </summary>	
        [Key]
        [Column("id")]
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// UserID
        /// </summary>	
        [Column("UserID")]
        public int UserID
        {
            get;
            set;
        }
        [Column("UserType")]
        public string UserType
        {
            get;
            set;
        }
        /// <summary>
        /// UserName
        /// </summary>	
        [Column("UserName")]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// UserPhone
        /// </summary>	
        [Column("UserPhone")]
        public string UserPhone
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

        public WebPeopleGuarantMoney()
        {
            IsGuarantMoney = 0;
            IsDelete = 0;
            EditOn = DateTime.Now;
            AddOn = DateTime.Now;
        }
    }
}

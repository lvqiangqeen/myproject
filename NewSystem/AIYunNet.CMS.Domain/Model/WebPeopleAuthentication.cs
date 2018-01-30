using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebPeopleAuthentication")]
    public class WebPeopleAuthentication
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
        /// <summary>
        /// UserTrueName
        /// </summary>	
        [Column("UserTrueName")]
        public string UserTrueName
        {
            get;
            set;
        }
        /// <summary>
        /// UserType
        /// </summary>	
        [Column("UserType")]
        public string UserType
        {
            get;
            set;
        }
        /// <summary>
        /// TrueName
        /// </summary>	
        [Column("TrueName")]
        public string TrueName
        {
            get;
            set;
        }
        /// <summary>
        /// UserIdentity
        /// </summary>	
        [Column("UserIdentity")]
        public string UserIdentity
        {
            get;
            set;
        }
        /// <summary>
        /// ShengfenZ
        /// </summary>	
        [Column("ShengfenZ")]
        public string ShengfenZ
        {
            get;
            set;
        }
        /// <summary>
        /// ShengfenF
        /// </summary>	
        [Column("ShengfenF")]
        public string ShengfenF
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
        /// <summary>
        /// 是否通过审核
        /// </summary>
        [Column("IsAuthentication")]
        public int IsAuthentication
        {
            get;
            set;
        }
        [Column("ZthumbnailImage")]
        public string ZthumbnailImage
        {
            get;
            set;
        }
        [Column("FthumbnailImage")]
        public string FthumbnailImage
        {
            get;
            set;
        }
        public WebPeopleAuthentication()
        {
            IsAuthentication = 0;
            IsDelete = 0;
            EditOn= DateTime.Now;
            AddOn= DateTime.Now;
        }
    }
}

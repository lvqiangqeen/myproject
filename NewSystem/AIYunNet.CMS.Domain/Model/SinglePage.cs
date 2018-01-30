using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("SinglePage")]
    public class SinglePage
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
        /// Title
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Abstract
        /// </summary>	
        [Column("Abstract")]
        public string Abstract
        {
            get;
            set;
        }
        /// <summary>
        /// Info
        /// </summary>	
        [Column("Info")]
        public string Info
        {
            get;
            set;
        }
        /// <summary>
        /// SingleImg
        /// </summary>	
        [Column("SingleImg")]
        public string SingleImg
        {
            get;
            set;
        }
        /// <summary>
        /// thumbnailImage
        /// </summary>	
        [Column("thumbnailImage")]
        public string thumbnailImage
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
        public bool IsDelete
        {
            get;
            set;
        }
        /// <summary>
        /// SingleUrl
        /// </summary>	
        [Column("SingleUrl")]
        public string SingleUrl
        {
            get;
            set;
        }
        /// <summary>
        /// WeChatUrl
        /// </summary>	
        [Column("WeChatUrl")]
        public string WeChatUrl
        {
            get;
            set;
        }
        /// <summary>
        /// SingleType
        /// </summary>	
        [Column("SingleType")]
        public int SingleType
        {
            get;
            set;
        }

        public SinglePage()
        {
            IsDelete = false;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
        }
    }
}

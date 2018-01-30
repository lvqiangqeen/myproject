using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebRecommend")]
    public class WebRecommend
    {
        /// <summary>
        /// ID
        /// </summary>	
        [Key]
        [Column("RecommendId")]
        public int RecommendId
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐内容名称
        /// </summary>	
        [Column("RecommendName")]
        public string RecommendName
        {
            get;
            set;
        }
        /// <summary>
        /// RecommendInfo
        /// </summary>	
        [Column("RecommendInfo")]
        public string RecommendInfo
        {
            get;
            set;
        }
        [Column("RecommendContent")]
        public string RecommendContent
        {
            get;
            set;
        }
       
        /// <summary>
        /// RecommendImg
        /// </summary>	
        [Column("RecommendImg")]
        public string RecommendImg
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
        /// RecommendUrl
        /// </summary>	
        [Column("RecommendUrl")]
        public string RecommendUrl
        {
            get;
            set;
        }
        /// <summary>
        /// RecWechartUrl
        /// </summary>	
        [Column("RecWechartUrl")]
        public string RecWechartUrl
        {
            get;
            set;
        }
        /// <summary>
        /// RecommendType
        /// </summary>	
        [Column("RecommendType")]
        public int RecommendType
        {
            get;
            set;
        }
        /// <summary>
        /// ShowOrder
        /// </summary>	
        [Column("ShowOrder")]
        public string ShowOrder
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
        /// FlagDelete
        /// </summary>	
        [Column("FlagDelete")]
        public int FlagDelete
        {
            get;
            set;
        }

        [Column("WechatOn")]
        public bool WechatOn { get; set; }

        [Column("PcOn")]
        public bool PcOn { get; set; }

        [Column("BigOrSmall")]
        public bool BigOrSmall { get; set; }

        [Column("CompanyID")]
        public string CompanyID { get; set; }

        [Column("IsRed")]
        public bool IsRed { get; set; }

        public WebRecommend()
        {
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            FlagDelete = 0;
            ShowOrder = "0";
            IsRed = false;
        }
    }

    public class indexList
    {
        public string name { get; set; }
        public List<WebRecommend> list { get; set; }
    }
}

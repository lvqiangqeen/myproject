using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebGoods")]
    public class WebGoods
    {
        /// <summary>
		/// GoodsID
        /// </summary>	
        [Key]
        [Column("GoodsID")]
        public int GoodsID
        {
            get;
            set;
        }
        /// <summary>
        /// goods_name
        /// </summary>	
        [Column("goods_name")]
        public string goods_name
        {
            get;
            set;
        }
        /// <summary>
        /// logo
        /// </summary>	
        [Column("logo")]
        public string logo
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
        /// price
        /// </summary>	
        [Column("price")]
        public decimal price
        {
            get;
            set;
        }
        /// <summary>
        ///详情
        /// </summary>	
        [Column("goods_desc")]
        public string goods_desc
        {
            get;
            set;
        }
        /// <summary>
        /// is_on_sale
        /// </summary>	
        [Column("is_on_sale")]
        public bool is_on_sale
        {
            get;
            set;
        }
        /// <summary>
        /// IsTop
        /// </summary>	
        [Column("IsTop")]
        public bool IsTop
        {
            get;
            set;
        }
        /// <summary>
        /// AddOn
        /// </summary>	
        [Column("AddOn")]
        public DateTime? AddOn
        {
            get;
            set;
        }
        /// <summary>
        /// EditOn
        /// </summary>	
        [Column("EditOn")]
        public DateTime? EditOn
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
        /// <summary>
        ///库存
        /// </summary>	
        [Column("Goodstock")]
        public int Goodstock
        {
            get;
            set;
        }
        /// <summary>
        /// 销量
        /// </summary>	
        [Column("Salesnum")]
        public int Salesnum
        {
            get;
            set;
        }
        /// <summary>
        /// 现价
        /// </summary>	
        [Column("Newprice")]
        public decimal Newprice
        {
            get;
            set;
        }
        /// <summary>
        /// 隶属品牌
        /// </summary>	
        [Column("Belongs")]
        public int Belongs
        {
            get;
            set;
        }
        /// <summary>
        /// 简介
        /// </summary>	
        [Column("goods_Info")]
        public string goods_Info
        {
            get;
            set;
        }
        
        public WebGoods()
        {
            EditOn= DateTime.Now;
            AddOn = DateTime.Now;
            FlagDelete = 0;
        }

    }
}

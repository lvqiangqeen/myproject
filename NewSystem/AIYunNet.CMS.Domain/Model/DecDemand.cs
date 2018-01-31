using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("DecDemand")]
    public class DecDemand
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// ownername
        /// </summary>
        [Column("ownername")]
        public string ownername { get; set; }
        /// <summary>
        /// ownertel
        /// </summary>
        [Column("ownertel")]
        public string ownertel { get; set; }
        /// <summary>
        /// ProvinceID
        /// </summary>
        [Column("ProvinceID")]
        public int ProvinceID { get; set; }
        /// <summary>
        /// ProvinceName
        /// </summary>
        [Column("ProvinceName")]
        public string ProvinceName { get; set; }
        /// <summary>
        /// CityID
        /// </summary>
        [Column("CityID")]
        public int CityID { get; set; }
        /// <summary>
        /// CityName
        /// </summary>
        [Column("CityName")]
        public string CityName { get; set; }
        /// <summary>
        /// 装修的时间段
        /// </summary>
        [Column("workTime")]
        public int workTime { get; set; }
        /// <summary>
        /// buidingSpace
        /// </summary>
        [Column("buidingSpace")]
        public decimal buidingSpace { get; set; }
        /// <summary>
        /// buidingtype
        /// </summary>
        [Column("buidingtype")]
        public int buidingtype { get; set; }
        /// <summary>
        /// buidingname
        /// </summary>
        [Column("buidingname")]
        public string buidingname { get; set; }
        /// <summary>
        /// PublishuserID
        /// </summary>
        [Column("PublishuserID")]
        public int PublishuserID { get; set; }
        /// <summary>
        /// GetUserID
        /// </summary>
        [Column("GetUserID")]
        public int GetUserID { get; set; }
        /// <summary>
        /// GetUserType
        /// </summary>
        [Column("GetUserType")]
        public string GetUserType { get; set; }
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
        public DateTime DeleteOn { get; set; }
        /// <summary>
        /// IsDelete
        /// </summary>
        [Column("IsDelete")]
        public bool IsDelete { get; set; }
        /// <summary>
        /// 是否审核通过（0位没有审核，1为通过，-1位没有通过）
        /// </summary>
        [Column("IsVerrify")]
        public int IsVerrify { get; set; }
    }
}

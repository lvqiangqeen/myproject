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
        /// WorkTimeName
        /// </summary>
        [Column("WorkTimeName")]
        public string WorkTimeName { get; set; }
        /// <summary>
        /// buidingSpace
        /// </summary>
        [Column("buidingSpace")]
        public double buidingSpace { get; set; }
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
        /// EndOn
        /// </summary>
        [Column("EndOn")]
        public DateTime EndOn { get; set; }
        /// <summary>
        /// IsEnd
        /// </summary>
        [Column("IsEnd")]
        public bool IsEnd { get; set; }
        
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
        /// 是否审核通过（0位没有审核，1为通过，-1位没有通过）
        /// </summary>
        [Column("IsVerrify")]
        public int IsVerrify { get; set; }
        /// <summary>
        /// 一句话描述需求
        /// </summary>
        [Column("OneSentence")]
        public string OneSentence { get; set; }
        /// <summary>
        /// 参与要求
        /// </summary>
        [Column("Demandneed")]
        public string Demandneed { get; set; }
        /// <summary>
        /// 需求说明
        /// </summary>
        [Column("Info")]
        public string Info { get; set; }
        /// <summary>
        /// DemandType
        /// </summary>
        [Column("DemandType")]
        public int DemandType { get; set; }
        /// <summary>
        /// 需求类型
        /// </summary>
        [Column("DemandTypeName")]
        public string DemandTypeName { get; set; }
        /// <summary>
        /// 需求状态
        /// </summary>
        [Column("DemandState")]
        public int DemandState { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Column("PageViewCount")]
        public int PageViewCount { get; set; }
        /// <summary>
        /// 投标量
        /// </summary>
        [Column("bidCount")]
        public int bidCount { get; set; }
        /// <summary>
        /// 是否发布了计划
        /// </summary>
        [Column("IsPlan")]
        public bool IsPlan { get; set; }
        public DecDemand()
        {
            ProvinceID = 0;
            CityID = 0;
            workTime = 0;
            buidingSpace = 0;
            buidingtype = 0;
            PublishuserID = 0;
            GetUserID = 0;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            EndOn = DateTime.Now.AddDays(7);
            IsDelete = false;
            IsVerrify = 0;
            DemandType = 0;
            DemandState = 0;
            PageViewCount = 0;
            bidCount = 0;
            IsEnd = false;
            IsPlan = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebWorker")]
    public class WebWorker
    {
        /// <summary>
        /// WorkerID
        /// </summary>
        [Key]
        [Column("WorkerID")]
        public int WorkerID { get; set; }
        /// <summary>
        /// WorkerName
        /// </summary>
        [Column("WorkerName")]
        public string WorkerName { get; set; }
        /// <summary>
        /// WorkerCategory
        /// </summary>
        [Column("WorkerCategory")]
        public string WorkerCategory { get; set; }
        /// <summary>
        /// WorkerPhone
        /// </summary>
        [Column("WorkerPhone")]
        public string WorkerPhone { get; set; }
        /// <summary>
        /// WorkerMail
        /// </summary>
        [Column("WorkerMail")]
        public string WorkerMail { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        [Column("Address")]
        public string Address { get; set; }
        /// <summary>
        /// WorkerInfo
        /// </summary>
        [Column("WorkerInfo")]
        public string WorkerInfo { get; set; }
        /// <summary>
        /// WorkerLevel
        /// </summary>
        [Column("WorkerLevel")]
        public int WorkerLevel { get; set; }
        /// <summary>
        /// WorkerMotto
        /// </summary>
        [Column("WorkerMotto")]
        public string WorkerMotto { get; set; }
        /// <summary>
        /// IsBond
        /// </summary>
        [Column("IsBond")]
        public bool IsBond { get; set; }
        /// <summary>
        /// BondMoney
        /// </summary>
        [Column("BondMoney")]
        public double BondMoney { get; set; }
        /// <summary>
        /// IsAuthentication
        /// </summary>
        [Column("IsAuthentication")]
        public bool IsAuthentication { get; set; }
        /// <summary>
        /// IsHot
        /// </summary>
        [Column("IsHot")]
        public bool IsHot { get; set; }
        /// <summary>
        /// IsTop
        /// </summary>
        [Column("IsTop")]
        public bool IsTop { get; set; }
        /// <summary>
        /// ShowOrder
        /// </summary>
        [Column("ShowOrder")]
        public int ShowOrder { get; set; }
        /// <summary>
        /// WorkerImage
        /// </summary>
        [Column("WorkerImage")]
        public string WorkerImage { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
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
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        [Column("FlagDelete")]
        public int FlagDelete { get; set; }
        /// <summary>
        /// ProvinceID
        /// </summary>
        [Column("ProvinceID")]
        public string ProvinceID { get; set; }
        /// <summary>
        /// ProvinceName
        /// </summary>
        [Column("ProvinceName")]
        public string ProvinceName { get; set; }
        /// <summary>
        /// CityID
        /// </summary>
        [Column("CityID")]
        public string CityID { get; set; }
        /// <summary>
        /// CityName
        /// </summary>
        [Column("CityName")]
        public string CityName { get; set; }
        /// <summary>
        /// AreasID
        /// </summary>
        [Column("AreasID")]
        public string AreasID { get; set; }
        /// <summary>
        /// AreasName
        /// </summary>
        [Column("AreasName")]
        public string AreasName { get; set; }
        /// <summary>
        /// UserID
        /// </summary>
        [Column("UserID")]
        public int UserID { get; set; }
        /// <summary>
        /// PriceID
        /// </summary>
        [Column("PriceID")]
        public int PriceID { get; set; }
        /// <summary>
        /// PriceName
        /// </summary>
        [Column("PriceName")]
        public string PriceName { get; set; }
        /// <summary>
        /// WorkYearsID
        /// </summary>
        [Column("WorkYearsID")]
        public int WorkYearsID { get; set; }
        /// <summary>
        /// WorkYears
        /// </summary>
        [Column("WorkYears")]
        public string WorkYears { get; set; }
        /// <summary>
        /// WorkerPositionID
        /// </summary>
        [Column("WorkerPositionID")]
        public string WorkerPositionID { get; set; }
        /// <summary>
        /// WorkerPosition
        /// </summary>
        [Column("WorkerPosition")]
        public string WorkerPosition { get; set; }
        /// <summary>
        /// GoodAtStyleID
        /// </summary>
        [Column("GoodAtStyleID")]
        public string GoodAtStyleID { get; set; }
        /// <summary>
        /// GoodAtStyle
        /// </summary>
        [Column("GoodAtStyle")]
        public string GoodAtStyle { get; set; }
        /// <summary>
        /// PageViewCount
        /// </summary>
        [Column("PageViewCount")]
        public int PageViewCount { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        [Column("CollectCount")]
        public int CollectCount { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        [Column("CommentCount")]
        public int CommentCount { get; set; }
        /// <summary>
        /// 工程数
        /// </summary>
        [Column("BuildingCount")]
        public int BuildingCount { get; set; }
        /// <summary>
        /// 在建工程数
        /// </summary>
        [Column("IsBuildingCount")]
        public int IsBuildingCount { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        [Column("IsApproved")]
        public bool IsApproved { get; set; }
        public WebWorker()
        {
            PageViewCount = 0;
            CollectCount = 0;
            BuildingCount = 0;
            WorkerLevel = 0;
            CommentCount = 0;
            IsBuildingCount = 0;
            IsApproved = false;
            WorkYearsID = 0;
            PriceID = 0;
            UserID = 0;
            FlagDelete = 0;
            AddOn = DateTime.Now;
            EditOn= DateTime.Now;
            ShowOrder = 0;
            WorkerLevel = 0;
            IsTop = false;
            IsHot = false;
            IsAuthentication = false;
            IsBond = false;
            BondMoney = 0;
        }
    }


    public class WorkerAndBuidingList
    {
        public WebWorker worker { get; set; }
        public List<WebBuiding> biuding { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebPeople")]
    public class WebPeople
    {
        [Key]
        [Column("PeopleID")]
        public int PeopleID { get; set; }

        [Column("PeopleName")]
        public string PeopleName { get; set; }

        [Column("PeopleCategory")]
        public string PeopleCategory { get; set; }

        [Column("PeoplePositionID")]
        public string PeoplePositionID { get; set; }

        [Column("PeoplePosition")]
        public string PeoplePosition { get; set; }

        [Column("PeoplePhone")]
        public string PeoplePhone { get; set; }

        /// <summary>
        /// 个人邮箱
        /// </summary>
        [Column("PeopleMail")]
        public string PeopleMail { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("WorkYearsID")]
        public int? WorkYearsID { get; set; }
        
        [Column("WorkYears")]
        public string WorkYears { get; set; }

        [Column("PeopleInfo")]
        public string PeopleInfo { get; set; }

        [Column("PeopleLevel")]
        public int PeopleLevel { get; set; }

        [Column("GoodAtStyleID")]
        public string GoodAtStyleID { get; set; }

        [Column("GoodAtStyle")]
        public string GoodAtStyle { get; set; }

        /// <summary>
        /// 格言
        /// </summary>
        [Column("PeopleMotto")]
        public string PeopleMotto { get; set; }

        [Column("CaseCount")]
        public int CaseCount { get; set; }

        [Column("IsBuildingCount")]
        public int IsBuildingCount { get; set; }

        /// <summary>
        /// 是否缴纳质保金
        /// </summary>
        [Column("IsBond")]
        public bool IsBond { get; set; }
        /// <summary>
        /// 是否通过认证
        /// </summary>
        [Column("IsAuthentication")]
        public bool IsAuthentication { get; set; }

        [Column("IsApproved")]
        public bool IsApproved { get; set; }

        [Column("IsTop")]
        public bool IsTop { get; set; }
        /// <summary>
        /// 负责区域
        /// </summary>
        [Column("BelongArea")]
        public string BelongArea { get; set; }

        [Column("ShowOrder")]
        public int ShowOrder { get; set; }

        [Column("PeopleImage")]
        public string PeopleImage { get; set; }

        [Column("DesignerImage")]
        public string DesignerImage { get; set; }

        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }

        [Column("CompanyID")]
        public int CompanyID { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("AddOn")]
        public DateTime? AddOn { get; set; }

        [Column("EditOn")]
        public DateTime? EditOn { get; set; }

        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }

        [Column("FlagDelete")]
        public int FlagDelete { get; set; }

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
        /// 用户ID
        /// </summary>
        [Column("UserID")]
        public int? UserID { get; set; }

        [Column("PageViewCount")]
        public int PageViewCount { get; set; }

        [Column("CollectCount")]
        public int CollectCount { get; set; }

        [Column("PriceID")]
        public int PriceID { get; set; }

        [Column("CommentCount")]
        public int CommentCount { get; set; }

        [Column("ProvinceID")]
        public string ProvinceID { get; set; }

        [Column("ProvinceName")]
        public string ProvinceName { get; set; }
        public WebPeople()
        {
            CollectCount = 0;
            AddOn = DateTime.Now;
            FlagDelete = 0;
            ShowOrder = 0;
            CaseCount = 0;
            IsBuildingCount = 0;
            PageViewCount = 0;
            CommentCount = 0;
        }
    }

    public class WebPeoplePage
    {
        public int PeopleID { get; set; }

        public string PeopleName { get; set; }

        public string PeopleCategory { get; set; }

        public string PeoplePositionID { get; set; }

        public string PeoplePosition { get; set; }

        public string PeoplePhone { get; set; }

        /// <summary>
        /// 个人邮箱
        /// </summary>
        public string PeopleMail { get; set; }

        public string Address { get; set; }

        public int? WorkYearsID { get; set; }

        public string WorkYears { get; set; }

        public string PeopleInfo { get; set; }

        public int PeopleLevel { get; set; }

        public string GoodAtStyleID { get; set; }

        public string GoodAtStyle { get; set; }

        /// <summary>
        /// 格言
        /// </summary>
        public string PeopleMotto { get; set; }

        public int CaseCount { get; set; }

        public int IsBuildingCount { get; set; }

        /// <summary>
        /// 是否缴纳质保金
        /// </summary>
        public bool IsBond { get; set; }
        /// <summary>
        /// 是否通过认证
        /// </summary>
        public bool IsAuthentication { get; set; }

        public bool IsApproved { get; set; }

        public bool IsTop { get; set; }
        /// <summary>
        /// 负责区域
        /// </summary>
        public string BelongArea { get; set; }

        public int ShowOrder { get; set; }

        public string PeopleImage { get; set; }

        public string DesignerImage { get; set; }

        public string thumbnailImage { get; set; }

        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public DateTime? AddOn { get; set; }
        public DateTime? EditOn { get; set; }

        public DateTime? DeleteOn { get; set; }

        public int FlagDelete { get; set; }

        /// <summary>
        /// CityID
        /// </summary>
        public string CityID { get; set; }
        /// <summary>
        /// CityName
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// AreasID
        /// </summary>
        public string AreasID { get; set; }
        /// <summary>
        /// AreasName
        /// </summary>
        public string AreasName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }

        public int PageViewCount { get; set; }

        public int CollectCount { get; set; }
        public int PriceID { get; set; }
        public string PriceName { get; set; }
        public int CommentCount { get; set; }

        public string ProvinceID { get; set; }


        public string ProvinceName { get; set; }

        public List<WebCase> caselist { get; set; }
        public WebPeoplePage()
        {
            CollectCount = 0;
            AddOn = DateTime.Now;
            FlagDelete = 0;
            ShowOrder = 0;
            CaseCount = 0;
            IsBuildingCount = 0;
            PageViewCount = 0;
            caselist =new List<WebCase>();
        }
    }
}

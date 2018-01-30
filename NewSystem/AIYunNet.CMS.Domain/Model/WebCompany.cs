using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCompany")]
    public class WebCompany
    {
        [Key]
        [Column("CompanyID")]
        public int CompanyID { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("CompanyPeople")]
        public string CompanyPeople { get; set; }

        [Column("CompanyPhone")]
        public string CompanyPhone { get; set; }

        [Column("CompanyMoble")]
        public string CompanyMoble { get; set; }

        [Column("CompanyMail")]
        public string CompanyMail { get; set; }

        [Column("CompanyAddress")]
        public string CompanyAddress { get; set; }

        [Column("CompanyNet")]
        public string CompanyNet { get; set; }

        [Column("CompanyInfo")]
        public string CompanyInfo { get; set; }

        [Column("CaseCount")]
        public int CaseCount { get; set; }

        [Column("InBuildingCount")]
        public int InBuildingCount { get; set; }

        [Column("IsBond")]
        public bool IsBond { get; set; }

        [Column("IsAuthentication")]
        public bool IsAuthentication { get; set; }

        [Column("IsPreferentialActivity")]
        public bool IsPreferentialActivity { get; set; }

        [Column("IsFamousEnterprise")]
        public bool IsFamousEnterprise { get; set; }

        [Column("IsApproved")]
        public bool IsApproved { get; set; }

        [Column("IsTop")]
        public bool IsTop { get; set; }

        [Column("ForwardNetAddress")]
        public string ForwardNetAddress { get; set; }

        [Column("BelongArea")]
        public string BelongArea { get; set; }

        [Column("ShowOrder")]
        public int ShowOrder { get; set; }

        [Column("CompanyImage")]
        public string CompanyImage { get; set; }

        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }

        [Column("AddOn")]
        public DateTime? AddOn { get; set; }

        [Column("EditOn")]
        public DateTime EditOn { get; set; }

        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }

        [Column("FlagDelete")]
        public int FlagDelete { get; set; }
        /// <summary>
        /// 公司规模
        /// </summary>
        [Column("CompanySize")]
        public string CompanySize { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        [Column("CompanyLicence")]
        public string CompanyLicence { get; set; }
        /// <summary>
        /// 资质证书
        /// </summary>
        [Column("Certification")]
        public string Certification { get; set; }
        /// <summary>
        /// 荣誉证书
        /// </summary>
        [Column("Honor")]
        public string Honor { get; set; }
        /// <summary>
        /// 公司性质
        /// </summary>
        [Column("CompanyType")]
        public string CompanyType { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        [Column("RegistAddress")]
        public string RegistAddress { get; set; }
        /// <summary>
        /// 注册资金
        /// </summary>
        [Column("RegistMoney")]
        public string RegistMoney { get; set; }
        /// <summary>
        /// 成立日期
        /// </summary>
        [Column("CompanyAddOn")]
        public DateTime CompanyAddOn { get; set; }
        /// <summary>
        /// 登记机关
        /// </summary>
        [Column("RegistAuthority")]
        public string RegistAuthority { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        [Column("BusinessScope")]
        public string BusinessScope { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        [Column("RegistMark")]
        public string RegistMark { get; set; }
        /// <summary>
        /// 法定代表人
        /// </summary>
        [Column("RepresentPerson")]
        public string RepresentPerson { get; set; }

        [Column("GoodAtStyleID")]
        public string GoodAtStyleID { get; set; }
        [Column("GoodAtStyle")]
        public string GoodAtStyle { get; set; }

        [Column("WebCompanyUserID")]
        public int? WebCompanyUserID { get; set; }

        [Column("PageViewCount")]
        public int PageViewCount { get; set; }

        [Column("CollectCount")]
        public int CollectCount { get; set; }

        [Column("CityID")]
        public string CityID { get; set; }

        [Column("CityName")]
        public string CityName { get; set; }

        [Column("GoodAtTypeID")]
        public string GoodAtTypeID { get; set; }

        [Column("GoodAtType")]
        public string GoodAtType { get; set; }

        [Column("PriceID")]
        public string PriceID { get; set; }

        [Column("PriceName")]
        public string PriceName { get; set; }

        [Column("CommentCount")]
        public int CommentCount { get; set; }

        [Column("ProvinceID")]
        public string ProvinceID { get; set; }

        [Column("ProvinceName")]
        public string ProvinceName { get; set; }

        [Column("AreasID")]
        public string AreasID { get; set; }

        [Column("AreasName")]
        public string AreasName { get; set; }
        public WebCompany()
        {
            CollectCount = 0;
            PageViewCount = 0;
            FlagDelete = 0;
            AddOn = DateTime.Now;
            EditOn= DateTime.Now;
            CompanyAddOn = DateTime.Now;
            ShowOrder = 0;
            CommentCount = 0;
        }
    }

    public class WebCompanyPage
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPeople { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyMoble { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNet { get; set; }
        public string CompanyInfo { get; set; }
        public int CaseCount { get; set; }
        public int InBuildingCount { get; set; }
        public bool IsBond { get; set; }
        public bool IsAuthentication { get; set; }
        public bool IsPreferentialActivity { get; set; }
        public bool IsFamousEnterprise { get; set; }
        public bool IsApproved { get; set; }
        public bool IsTop { get; set; }
        public string ForwardNetAddress { get; set; }
        public string BelongArea { get; set; }
        public int ShowOrder { get; set; }
        public string CompanyImage { get; set; }
        public string thumbnailImage { get; set; }
        public DateTime? AddOn { get; set; }
        public DateTime EditOn { get; set; }

        public DateTime? DeleteOn { get; set; }

        public int FlagDelete { get; set; }
        /// <summary>
        /// 公司规模
        /// </summary>
        public string CompanySize { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string CompanyLicence { get; set; }
        /// <summary>
        /// 资质证书
        /// </summary>
        public string Certification { get; set; }
        /// <summary>
        /// 荣誉证书
        /// </summary>
        public string Honor { get; set; }
        /// <summary>
        /// 公司性质
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegistAddress { get; set; }
        /// <summary>
        /// 注册资金
        /// </summary>
        public string RegistMoney { get; set; }
        /// <summary>
        /// 成立日期
        /// </summary>
        public DateTime CompanyAddOn { get; set; }
        /// <summary>
        /// 登记机关
        /// </summary>
        public string RegistAuthority { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string BusinessScope { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string RegistMark { get; set; }
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string RepresentPerson { get; set; }
        public string GoodAtStyleID { get; set; }
        public string GoodAtStyle { get; set; }
        public int? WebCompanyUserID { get; set; }
        public int PageViewCount { get; set; }
        public int CollectCount { get; set; }
        public string CityID { get; set; }
        public string CityName { get; set; }
        public string GoodAtTypeID { get; set; }
        public string GoodAtType { get; set; }
        public string PriceID { get; set; }
        public string PriceName { get; set; }
        public int CommentCount { get; set; }
        public string ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public string AreasID { get; set; }
        public string AreasName { get; set; }

    }
}

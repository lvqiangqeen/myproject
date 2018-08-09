using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AIYunNet.CMS.Domain.OccaModel
{
    public class UserAndWorkerModel
    {
        public static string Hearder = ConfigurationManager.AppSettings["Hearder"];
        /// <summary>
        /// UserID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 登录账号（Account）全部用手机
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// IsActivity
        /// </summary>
        public bool IsActivity { get; set; }
        /// <summary>
        /// UserType
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// InTime
        /// </summary>
        public DateTime? InTime { get; set; }
        /// <summary>
        /// InIp
        /// </summary>
        public string InIp { get; set; }
        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool InUser { get; set; }
        /// <summary>
        /// IsLock
        /// </summary>
        public bool IsLock { get; set; }
        /// <summary>
        /// 登录手机号
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// Cellphone
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// ZipCode
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        public DateTime EditOn { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        public DateTime AddOn { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// Img
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        public string thumbnailImage { get; set; }
        /// <summary>
        /// 职位类别ID
        /// </summary>
        public int PositionID { get; set; }
        /// <summary>
        /// 职位区分
        /// </summary>
        public string PositionCode { get; set; }
        /// <summary>
        /// 职位类别
        /// </summary>
        public int PositionType { get; set; }
        public string ProvinceID { get; set; }
        public string ProvinceName { get; set; }

        public string CityID { get; set; }

        public string CityName { get; set; }

        public string AreasID { get; set; }

        public string AreasName { get; set; }



        public int WorkerID { get; set; }
        /// <summary>
        /// WorkerName
        /// </summary>
        public string WorkerName { get; set; }
        /// <summary>
        /// WorkerCategory
        /// </summary>
        public string WorkerCategory { get; set; }
        /// <summary>
        /// WorkerPhone
        /// </summary>
        public string WorkerPhone { get; set; }
        /// <summary>
        /// WorkerMail
        /// </summary>
        public string WorkerMail { get; set; }

        /// <summary>
        /// WorkerInfo
        /// </summary>
        public string WorkerInfo { get; set; }
        /// <summary>
        /// WorkerLevel
        /// </summary>
        public int WorkerLevel { get; set; }
        /// <summary>
        ///评价自己
        /// </summary>
        public string WorkerMotto { get; set; }
        /// <summary>
        /// IsBond
        /// </summary>
        public bool IsBond { get; set; }
        /// <summary>
        /// BondMoney
        /// </summary>
        public double BondMoney { get; set; }
        /// <summary>
        /// IsAuthentication
        /// </summary>
        public bool IsAuthentication { get; set; }
        /// <summary>
        /// IsHot
        /// </summary>

        public bool IsHot { get; set; }
        /// <summary>
        /// IsTop
        /// </summary>

        public bool IsTop { get; set; }
        /// <summary>
        /// ShowOrder
        /// </summary>

        public int ShowOrder { get; set; }
        /// <summary>
        /// WorkerImage
        /// </summary>

        public string WorkerImage { get; set; }

        public int FlagDelete { get; set; }



        /// <summary>
        /// PriceID
        /// </summary>

        public int PriceID { get; set; }
        /// <summary>
        /// PriceName
        /// </summary>

        public string PriceName { get; set; }
        /// <summary>
        /// WorkYearsID
        /// </summary>

        public int WorkYearsID { get; set; }
        /// <summary>
        /// WorkYears
        /// </summary>

        public string WorkYears { get; set; }
        /// <summary>
        /// WorkerPositionID
        /// </summary>

        public string WorkerPositionID { get; set; }
        /// <summary>
        /// WorkerPosition
        /// </summary>

        public string WorkerPosition { get; set; }
        /// <summary>
        /// GoodAtStyleID
        /// </summary>

        public string GoodAtStyleID { get; set; }
        /// <summary>
        /// 擅长领域
        /// </summary>

        public string GoodAtStyle { get; set; }
        /// <summary>
        /// PageViewCount
        /// </summary>

        public int PageViewCount { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>

        public int CollectCount { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>

        public int CommentCount { get; set; }
        /// <summary>
        /// 工程数
        /// </summary>

        public int BuildingCount { get; set; }
        /// <summary>
        /// 在建工程数
        /// </summary>

        public int IsBuildingCount { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsApproved { get; set; }
        public UserAndWorkerModel()
        {
            IsDelete = false;
            IsLock = false;
            IsActivity = false;
            AddOn = DateTime.Now;
            EditOn = DateTime.Now;
            NickName = "AU装修宝";
            PositionID = 0;
            PositionType = 0;
            ProvinceID = "";
            CityID = "";
            AreasID = "";
            Img = Hearder;
            thumbnailImage = Hearder;


            PageViewCount = 0;
            CollectCount = 0;
            BuildingCount = 0;
            WorkerLevel = 0;
            CommentCount = 0;
            IsBuildingCount = 0;
            IsApproved = false;
            WorkYearsID = 0;
            WorkYears = "";
            PriceID = 0;

            FlagDelete = 0;

            ShowOrder = 0;
            WorkerLevel = 0;
            IsTop = false;
            IsHot = false;
            IsAuthentication = false;
            IsBond = false;
            BondMoney = 0;
        }
    }
}

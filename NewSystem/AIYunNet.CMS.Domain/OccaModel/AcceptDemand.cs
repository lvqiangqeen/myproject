using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Domain.OccaModel
{
    public class AcceptDemand
    {
        public int id { get; set; }
        /// <summary>
        /// ownername
        /// </summary>
        public string ownername { get; set; }
        /// <summary>
        /// ownertel
        /// </summary>
        public string ownertel { get; set; }
        /// <summary>
        /// ProvinceID
        /// </summary>
        public string ProvinceID { get; set; }
        /// <summary>
        /// ProvinceName
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// CityID
        /// </summary>
        public string CityID { get; set; }
        /// <summary>
        /// CityName
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 装修的时间段
        /// </summary>
        public int workTime { get; set; }
        /// <summary>
        /// WorkTimeName
        /// </summary>
        public string WorkTimeName { get; set; }
        /// <summary>
        /// buidingSpace
        /// </summary>
        public double buidingSpace { get; set; }
        /// <summary>
        /// buidingtype
        /// </summary>
        public int buidingtype { get; set; }
        /// <summary>
        /// buidingname
        /// </summary>
        public string buidingname { get; set; }
        /// <summary>
        /// PublishuserID
        /// </summary>
        public int PublishuserID { get; set; }
        /// <summary>
        /// GetUserID
        /// </summary>
        public int GetUserID { get; set; }
        /// <summary>
        /// GetUserType
        /// </summary>
        public string GetUserType { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        public DateTime AddOn { get; set; }
        /// <summary>
        /// EndOn
        /// </summary>
        public DateTime EndOn { get; set; }
        /// <summary>
        /// IsEnd
        /// </summary>
        public bool IsEnd { get; set; }

        /// <summary>
        /// EditOn
        /// </summary>
        public DateTime EditOn { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 是否审核通过（0位没有审核，1为通过，-1位没有通过）
        /// </summary>
        public int IsVerrify { get; set; }
        /// <summary>
        /// 一句话描述需求
        /// </summary>
        public string OneSentence { get; set; }
        /// <summary>
        /// 参与要求
        /// </summary>
        public string Demandneed { get; set; }
        /// <summary>
        /// 需求说明
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// DemandType
        /// </summary>
        public int DemandType { get; set; }
        /// <summary>
        /// 需求类型
        /// </summary>
        public string DemandTypeName { get; set; }
        /// <summary>
        /// 需求状态
        /// </summary>
        public int DemandState { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int PageViewCount { get; set; }
        /// <summary>
        /// 投标量
        /// </summary>
        public int bidCount { get; set; }
        /// <summary>
        /// 是否发布了计划
        /// </summary>
        public bool IsPlan { get; set; }
        /// <summary>
        /// 是否完工
        /// </summary>
        public bool IsOver { get; set; }
        /// <summary>
        /// 是否发布到需求大厅
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 户型
        /// </summary>
        public string HouseType { get; set; }
        /// <summary>
        /// 预接受用户ID
        /// </summary>
        public int AcceptUserID { get; set; }
        /// <summary>
        /// 是否接受
        /// </summary>
        public int IsAccept { get; set; }
        public AcceptDemand()
        {
            ProvinceID = "";
            CityID = "";
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
            IsOver = false;
            IsPublish = false;
            HouseType = "";
            Guid = System.Guid.NewGuid().ToString();
            AcceptUserID = 0;
            IsAccept = 0;
        }
    }
}

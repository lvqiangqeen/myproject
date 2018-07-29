using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Domain.OccaModel
{
    public class Tender
    {
        public int id { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 投标者ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 投标者姓名
        /// </summary>
        public string perName { get; set; }
        /// <summary>
        /// perPhone
        /// </summary>
        public string perPhone { get; set; }
        /// <summary>
        /// perInfo
        /// </summary>
        public string perInfo { get; set; }
        /// <summary>
        /// 是否被业主接受0未看1接受2未接受
        /// </summary>
        public int IsAccept { get; set; }
        /// <summary>
        /// Addon
        /// </summary>
        public DateTime Addon { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        public DateTime EditOn { get; set; }
        /// <summary>
        /// DelOn
        public DateTime? DelOn { get; set; }
        public int IsDelete { get; set; }
        public double Price { get; set; }
        public string Buidingname { get; set; }
        public double Buidingspace { get; set; }
        public Tender()
        {
            Addon = DateTime.Now;
            IsAccept = 0;
            perInfo = "";
            perPhone = "";
            perName = "";
            UserID = 0;
            Guid = "";
            EditOn = DateTime.Now;
            IsDelete = 0;
            Price = 0;
            Buidingname = "";
            Buidingspace = 0;
        }
    }
}

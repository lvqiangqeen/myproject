using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebCase")]
    public class WebCase
    {
        [Key]
        [Column("CaseID")]
        public int CaseID { get; set; }

        [Column("CaseTitle")]
        public string CaseTitle { get; set; }

        [Column("CaseBrief")]
        public string CaseBrief { get; set; }

        [Column("CaseInfo")]
        public string CaseInfo { get; set; }

        [Column("CompanyID")]
        public int CompanyID { get; set; }

        [Column("PeopleID")]
        public int PeopleID { get; set; }

        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }

        [Column("CaseImageBig")]
        public string CaseImageBig { get; set; }

        [Column("ShowOrder")]
        public int ShowOrder { get; set; }

        [Column("IsTop")]
        public bool IsTop { get; set; }

        [Column("CostArea")]
        public int CostArea { get; set; }

        [Column("Style")]
        public int Style { get; set; }

        [Column("HouseType")]
        public int HouseType { get; set; }

        [Column("HouseArea")]
        public int HouseArea { get; set; }

        [Column("AddOn")]
        public DateTime AddOn { get; set; }

        [Column("EditOn")]
        public DateTime EditOn { get; set; }

        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }

        [Column("FlagDelete")]
        public int FlagDelete { get; set; }

        [Column("PageViewCount")]
        public int PageViewCount { get; set; }

        [Column("CollectCount")]
        public int CollectCount { get; set; }

        [Column("ZanCount")]
        public int ZanCount { get; set; }

        [Column("CommentCount")]
        public int CommentCount { get; set; }

        [Column("Jobschedule")]
        public int Jobschedule { get; set; }

        [Column("DecType")]
        public int DecType { get; set; }

        [Column("GzStyle")]
        public int GzStyle { get; set; }

        [Column("IsHot")]
        public bool IsHot { get; set; }
        public WebCase()
        {
            IsTop = false;
            IsHot = false;
            CostArea = 0;
            Style = 0;
            HouseType = 0;
            HouseArea = 0;
            GzStyle = 0;
            CommentCount = 0;
            ZanCount = 0;
            CollectCount = 0;
            PageViewCount = 0;
            AddOn = DateTime.Now;
            EditOn= DateTime.Now;
            FlagDelete = 0;
            ShowOrder = 0;
            Jobschedule = 0;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Domain.Model
{
    public class WebCasePage
    {
        public int CaseID { get; set; }

        public string CaseTitle { get; set; }

        public string CaseBrief { get; set; }

        public string CaseInfo { get; set; }

        public int CompanyID { get; set; }


        public int PeopleID { get; set; }

        public string thumbnailImage { get; set; }

        public string CaseImageBig { get; set; }


        public int ShowOrder { get; set; }


        public bool IsTop { get; set; }

        public int CostArea { get; set; }


        public int Style { get; set; }


        public int HouseType { get; set; }


        public int HouseArea { get; set; }


        public DateTime? AddOn { get; set; }


        public DateTime? EditOn { get; set; }


        public DateTime? DeleteOn { get; set; }

        public int FlagDelete { get; set; }

        public int PageViewCount { get; set; }

        public int CollectCount { get; set; }

        public int ZanCount { get; set; }

        public int CommentCount { get; set; }
        public string HouseTypeName { get; set; }

        public string StyleName { get; set; }

        public string HouseAreaName { get; set; }

        public string CostAreaName { get; set; }

        public int DecType { get; set; }
        public string GzStyleName { get; set; }

        public bool IsHot { get; set; }
    }

    public class WebCaseAndDesigner
    {
        public WebCasePage webcase { get; set; }
        public WebPeople designer { get; set; }
        public WebCompany company { get; set; }
    }
}

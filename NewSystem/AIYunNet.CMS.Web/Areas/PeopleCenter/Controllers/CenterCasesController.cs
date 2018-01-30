using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Areas.PeopleCenter.Controllers
{
    [AuthorityFilter]
    public class CenterCasesController : Controller
    {
        // GET: PeopleCenter/CenterCases
        WebCaseService webcaseservice = new WebCaseService();
        public ActionResult CenterCaselist()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddandUpdateCenterCase(int CaseID)
        {
            WebCase webcase = webcaseservice.GetWebCaseByID(CaseID);
            if (webcase == null)
            {
                webcase = new WebCase();
            }
            return View(webcase);
        }
        [HttpPost]
        [ValidateInput(false)]
        public int AddandUpdateCenterCase(WebCase webcase)
        {
            if (webcase.CaseID != 0)
            {
                webcaseservice.UpdateWebCasefromCenter(webcase);
            }
            else {
                //WebCase webcase = new WebCase()
                //{  
                //    CaseTitle = Request["CaseTitle"],
                //    HouseArea = Convert.ToInt32(Request["HouseArea"]),
                //    HouseType = Convert.ToInt32(Request["HouseType"]),
                //    Style = Convert.ToInt32(Request["Style"]),
                //    CostArea = Convert.ToInt32(Request["CostArea"]),
                //    CaseBrief = Request["CaseBrief"],
                //    CaseInfo = Request["CaseInfo"]
                //};
                webcaseservice.AddWebCase(webcase);
            }
            return 1;
            //WebCase webcase = webcaseservice.GetWebCaseByID(CaseID);
        }
    }
}
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
    public class CenterDemandController : Controller
    {
        DemandService DeSer = new DemandService();
        // GET: PeopleCenter/CenterDemand
        public ActionResult PeopleDemandList()
        {
            int PublishUserID= Convert.ToInt32(SessionHelper.Get("UserID"));
            List<DecDemand> list = DeSer.GetMyDecDemandList(PublishUserID);
            return View(list);
        }
        [HttpGet]
        public ActionResult updateAndAddDemand(int id=0)
        {
            DecDemand demand= DeSer.GetDecDemandByID(id);
            return View(demand);
        }
        [HttpPost]
        public ActionResult updateAndAddDemand(DecDemand demand)
        {
            int ret = 0;
            if (demand.id > 0)
            {
                ret = DeSer.UpdateDecDemand(demand);
            }
            else
            {
                ret = DeSer.AddDecDemand(demand);
            }
            return Json(new { RetCode = 1 });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Controllers
{
    [AllSessionFilter]
    public class DemandController : Controller
    {
        WebCommonService comser = new WebCommonService();
        DemandService demandSer = new DemandService();
        WebUserService UserSer = new WebUserService();
        // GET: Demand
        public ActionResult DemandList()
        {
            List<WebLookup> list = comser.GetLookupList("Demand_type");
            ViewBag.Typelist = list;
            return View();
        }

        public ActionResult DemandIndex(int id=0)
        {
            DecDemand demand = demandSer.GetDecDemandByID(id);
            if (demand.PublishuserID != 0)
            {
                WebUser user = UserSer.GetWebUserByID(demand.PublishuserID);
                ViewBag.user = user;
            }
            return View(demand);
        }


        public ActionResult peoplecenter(int id = 0)
        {
            return View();
        }

    }
}
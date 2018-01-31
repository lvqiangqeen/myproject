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
        // GET: Demand
        public ActionResult DemandList()
        {
            List<WebLookup> list = comser.GetLookupList("Demand_type");
            ViewBag.Typelist = list;
            return View();
        }
    }
}
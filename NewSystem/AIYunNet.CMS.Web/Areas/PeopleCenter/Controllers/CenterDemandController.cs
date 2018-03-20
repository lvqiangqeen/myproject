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
        DecDemandAcceptService Deacc = new DecDemandAcceptService();
        // GET: PeopleCenter/CenterDemand
        //我给我发的需求
        public ActionResult DemandListToMe()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Demanddetail(int id)
        {
            DecDemand demand = DeSer.GetDecDemandByID(id);
            return View(demand);
        }
        [HttpPost]
        public ActionResult updateIsAccept(DecDemandAccept acc)
        {
            int ret = 0;
            ret = Deacc.UpdateIsAccept(acc);
            return Json(new { RetCode = ret });
        }
        //我给别人发的需求
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
            return Json(new { RetCode = ret });
        }
        [HttpPost]
        public ActionResult AddDemandAccept(DecDemandAccept Accept)
        {
            int ret = 0;

            ret = Deacc.AddDecDemandAccept(Accept);
            
            return Json(new { RetCode = ret });
        }
        [HttpPost]
        public JsonResult DeleteDemand(int id)
        {
            int ret = 0;
            DecDemand dec = DeSer.GetDecDemandByID(id);
            if (dec.IsPlan)
            {
                ret = 2;
            }
            else
            {
                ret = DeSer.DeleteDecDemand(id);
            }
            return Json(new { RetCode = ret });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [MobileUserFilter]
    public class MobileUserController : Controller
    {
        WebBuidingService buidSer = new WebBuidingService();
        WebBuidingStagesService stageSer = new WebBuidingStagesService();
        DemandService deSer = new DemandService();
        #region 装修进度（用户）
        // GET: MobileApp/MobileUser
        public ActionResult BuidinglistUser()
        {
            return View();
        }
        public ActionResult BuidingDetailUser(int BuidingID = 0, string Guid = "")
        {
            WebBuiding buiding = new WebBuiding();
            if (BuidingID != 0)
            {
                buiding = buidSer.GetWebBuidingByID(BuidingID);
            }
            if (Guid != "")
            {
                buiding = buidSer.GetWebBuidingByGuID(Guid);
            }
            List<WebBuidingStages> stageslist = stageSer.GetWebBuidingStagesListByBuiding(buiding.BuidingID);
            DecDemand demand = deSer.GetDecDemandByGuID(buiding.Guid);
            ViewBag.stageslist = stageslist;
            ViewBag.demand = demand;
            return View(buiding);
        }
        [HttpPost]
        public ActionResult GetBuidinglist(int PageSize, int IsWorkerEnd, int IsUserEnd, int CurPage)
        {
            int userid = Convert.ToInt32(SessionHelper.Get("UserID"));
            List<WebBuiding> list = buidSer.mGetBListByUser(userid, IsWorkerEnd, IsUserEnd, PageSize, CurPage);
            return Json(list);
        }
        #endregion
        #region 需求列表
        public ActionResult DemandList()
        {
            return View();
        }
        public ActionResult DemandDetail()
        {
            return View();
        }
        #endregion
    }
}
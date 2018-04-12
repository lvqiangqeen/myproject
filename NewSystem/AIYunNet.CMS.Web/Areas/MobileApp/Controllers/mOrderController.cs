using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.OccaModel;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [MobileUserFilter]
    public class mOrderController : Controller
    {
        DecDemandAcceptService AcSer = new DecDemandAcceptService();
        DemandService deSer = new DemandService();
        WebBuidingService buidSer = new WebBuidingService();
        #region 订单
        // GET: MobileApp/mOrder
        public ActionResult Orderlist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetOrderlist(int isall, int IsAccept, int IsPlan,int PageSize, int CurPage)
        {
            int count = 0;
            int userid = Convert.ToInt32(SessionHelper.Get("UserID"));
            List<AcceptDemand> list =  AcSer.mGetDemandListByUserID(isall,IsAccept,IsPlan, userid, PageSize, CurPage, out count);
            return Json(list);
        }

        public ActionResult OrderDetail(string guid)
        {
            DecDemand demand = deSer.GetDecDemandByGuID(guid);
            return View(demand);
        }

        [HttpPost]
        public ActionResult updateIsAccept(DecDemandAccept acc)
        {
            int ret = 0;
            ret = AcSer.UpdateIsAccept(acc);
            return Json(new { RetCode = ret });
        }
        #endregion

        #region 工程
        public ActionResult mobileBuidingList()
        {
            return View();
        }
        //根据UserID获取装修进度列表信息

        [HttpPost]
        public ActionResult GetBuidinglist(int PageSize, int IsWorkerEnd, int IsUserEnd, int CurPage)
        {
            int workerid = Convert.ToInt32(SessionHelper.Get("PositionID"));
            List<WebBuiding> list = buidSer.mGetBListByWorker(workerid, IsWorkerEnd, IsUserEnd, PageSize, CurPage);
            return Json(list);
        }

        public ActionResult mobileBuidingDetail(int BuidingID)
        {
            return View();
        }
        #endregion
    }
}
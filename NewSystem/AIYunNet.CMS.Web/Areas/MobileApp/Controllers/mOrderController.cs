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
    [AllSessionFilter]
    [MobileUserFilter]
    public class mOrderController : Controller
    {
        DecDemandAcceptService AcSer = new DecDemandAcceptService();
        DemandService deSer = new DemandService();
        WebBuidingService buidSer = new WebBuidingService();
        WebBuidingStagesService stageSer = new WebBuidingStagesService();
        WebWorkerService workSer = new WebWorkerService();
        WebBuidTogetherService TogSer = new WebBuidTogetherService();
        #region 订单
        //放弃订单
        [HttpPost]
        public ActionResult IsOut(string guid)
        {
            int ret = 0;
            int GetUserID= Convert.ToInt32(SessionHelper.Get("UserID"));
            ret = deSer.IsOutByGuID(GetUserID, guid);
            return Json(new { RetCode = ret });
        }
        // GET: MobileApp/mOrder
        public ActionResult Orderlist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetOrderlist(int IsOut, int IsAccept, int IsPlan,int PageSize, int CurPage)
        {
            int count = 0;
            int userid = Convert.ToInt32(SessionHelper.Get("UserID"));
            List<AcceptDemand> list =  AcSer.mGetDemandListByUserID(IsOut, IsAccept,IsPlan, userid, PageSize, CurPage, out count);
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

        public ActionResult mobileBuidingDetail(int BuidingID=0,string Guid="")
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

        public ActionResult mobileStageDetail(int BuidingID,int StageID)
        {
            
            WebBuiding buiding = buidSer.GetWebBuidingByID(BuidingID);
            WebBuidingStages stage = stageSer.GetBuidingStageByBuidingIDAndStageID(BuidingID, StageID);
            ViewBag.stage = stage;
            return View(buiding);
        }
        //手机端修改阶段详情
        [HttpPost]
        public JsonResult mUpdateBuidingStagesInfo(WebBuidingStages stage)
        {
            int ret = stageSer.mUpdateBuidingStagesInfo(stage);
            return Json(new { RetCode = ret });
        }
        //选择工人页面
        public ActionResult SelectWorker()
        {
            return View();
        }
        //获取合作工人信息
        [HttpPost]
        public ActionResult mGetWorkerExceptSelflist(string WorkerName, int CurPage, int PageSize, string WorkerCategory, string WorkerPositionID)
        {
            int workerid = Convert.ToInt32(SessionHelper.Get("PositionID"));
            List<WebWorker> list = workSer.mGetWorkerExceptSelf(workerid, WorkerName, CurPage, PageSize, WorkerCategory, WorkerPositionID);
            return Json(list);
        }
        //选择合作工人
        [HttpPost]
        public JsonResult SendWorkTogether(WebBuidTogether tog)
        {
            int ret = 0;
            int ishave = TogSer.IsHaveTogther(tog.buidingID, tog.StageID);
            if (ishave == 0)
            {
                ret = TogSer.AddBuidTogether(tog);
            }
            return Json(new { RetCode = ret });
        }
        #endregion

        #region 合作项目
        public ActionResult mTogetherBuidingDetail(int BuidingID = 0,int StageID = 0,int togetherid=0)
        {
            WebBuiding buiding = buidSer.GetWebBuidingByID(BuidingID);
            WebBuidingStages stage = stageSer.GetBuidingStageByBuidingIDAndStageID(BuidingID, StageID);
            DecDemand demand = deSer.GetDecDemandByGuID(buiding.Guid);
            ViewBag.stage = stage;
            ViewBag.demand = demand;
            return View(buiding);
        }
        [HttpPost]
        public ActionResult IsAccept(int id, int IsAccept)
        {
            int ret = 0;
            ret = TogSer.IsAccept(id, IsAccept);
            return Json(new { RetCode = ret });
        }
        public ActionResult mTogetherBuidingList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetmTogetherList(int IsAccept, int IsComplete, int PageSize, int CurPage)
        {
            int count = 0;
            int workerid = Convert.ToInt32(SessionHelper.Get("PositionID"));
            List<BuidTogether> list = TogSer.GetmTogetherList(IsAccept, IsComplete, workerid, PageSize, CurPage,out count);
            return Json(list);
        }
        #endregion
    }
}
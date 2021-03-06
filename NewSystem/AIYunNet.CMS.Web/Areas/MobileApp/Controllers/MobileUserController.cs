﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.OccaModel;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [AllSessionFilter]
    [MobileUserFilter]
    public class MobileUserController : Controller
    {
        WebBuidingService buidSer = new WebBuidingService();
        WebBuidingStagesService stageSer = new WebBuidingStagesService();
        DemandService deSer = new DemandService();
        WebCommonService wCSer = new WebCommonService();
        WebWorkerService workSer = new WebWorkerService();
        WebBuidTogetherService TogSer = new WebBuidTogetherService();
        DecTenderService tenSer = new DecTenderService();

        #region 装修进度（用户）
        // GET: MobileApp/MobileUser
        //阶段审核
        public JsonResult IsUserEndStage(int buidingID, int stageID, int IsUserend)
        {
            int ret = 0;
            ret = stageSer.IsUserEnd(buidingID, stageID, IsUserend);
            return Json(new { RetCode = ret });
        }
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
        #region 投标列表
        public ActionResult TenderPersonList(string guid)
        {
            DecDemand demand = deSer.GetDecDemandByGuID(guid);
            List<DecTender> list = tenSer.GetDecTenderList(guid);
            ViewBag.list = list;
            return View(demand);
        }

        public ActionResult TenderDetailByUser(string guid, int userid, int workerid)
        {
            DecTender tender = tenSer.GetTender(guid, userid);
            ViewBag.tender = tender;
            return View();
        }
        #endregion

        #region 需求列表
        public ActionResult DemandList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetDemandlist(int PageSize, int IsAccept, int IsPlan,int IsOut, int CurPage)
        {
            int count = 0;
            int PublicUserID = Convert.ToInt32(SessionHelper.Get("UserID"));
            List<Demand> list = deSer.GetPublishDemandList(PublicUserID, PageSize, IsAccept, IsPlan, IsOut, CurPage,out count);
            return Json(list);
        }
        public ActionResult DemandDetail(int id=0,string Guid="")
        {
            DecDemand dec = new DecDemand();
            if (id != 0 && Guid == "")
            {
                dec = deSer.GetDecDemandByID(id);
            } else if(Guid!="" && id==0)
            {
                dec = deSer.GetDecDemandByGuID(Guid);
            }
            
            return View(dec);
        }
        [HttpPost]
        public ActionResult updateDemandDetail(DecDemand dec)
        {
            int ret = 0;
            if (dec.id == 0)
            {
                ret=deSer.AddDecDemand(dec);
            }
            else
            {
                ret=deSer.UpdateDecDemand(dec);
            }
            return Json(new { RetCode = ret });
        }
        [HttpPost]
        public ActionResult GetDemandType()
        {
            List<lookupJson> list= wCSer.GetJson();
            return Json(list);
        }
        #endregion

        #region 选择需求发送人列表
        public ActionResult SelectWorkerforDemand()
        {
            return View();
        }
        //获取工人信息
        [HttpPost]
        public ActionResult mGetWorkerlist(string WorkerName, int CurPage, int PageSize, string WorkerCategory, string WorkerPositionID)
        {
            List<WebWorker> list = workSer.mGetWorker(WorkerName, CurPage, PageSize, WorkerCategory, WorkerPositionID);
            return Json(list);
        }
        public ActionResult decDemandDetail(int id = 0, string Guid = "")
        {
            DecDemand dec = new DecDemand();
            if (id != 0 && Guid == "")
            {
                dec = deSer.GetDecDemandByID(id);
            }
            else if (Guid != "" && id == 0)
            {
                dec = deSer.GetDecDemandByGuID(Guid);
            }
            return View(dec);
        }
        #endregion

    }
}
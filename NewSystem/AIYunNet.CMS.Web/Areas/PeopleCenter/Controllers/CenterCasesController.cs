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
        DemandService demandSer = new DemandService();
        WebBuidingService buidingSer = new WebBuidingService();
        #region 设计
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
			else
			{
				webcaseservice.AddWebCase(webcase);
			}
			return 1;
			//WebCase webcase = webcaseservice.GetWebCaseByID(CaseID);
		}
        #endregion

        WebBuidingStagesService stageSer = new WebBuidingStagesService();
        #region 装修接单
        public ActionResult WorkerDemandList(int UserID)
        {
            List<DecDemand> list = demandSer.GetDecDemandListByUserIDAndType(UserID, "WebUser");
            return View(list);
        }
        #endregion


        #region 装修
        public ActionResult WorkerBuidingList()
        {
            WebBuidingService service = new WebBuidingService();
            int Workerid = Convert.ToInt32(SessionHelper.Get("PositionID"));
            List<WebBuiding> buidingList = service.GetWebBuidingListByWorkerID(Workerid,false);
            return View(buidingList);
        }
        public ActionResult BuidingStagesList()
		{
            WebBuidingService service = new WebBuidingService();
            int Workerid = Convert.ToInt32(SessionHelper.Get("PositionID"));
            List<WebBuiding> buidingList = service.GetWebBuidingListByWorkerID(Workerid, true);
            return View(buidingList);
		}

		[HttpGet]
		public ActionResult AddOrEditBuidingStages(int DemandID = 0, int BuidingID = 0)
		{
			IWebCommon commonService = new WebCommonService();
			List<WebLookup> commonworkPosition = commonService.GetLookupList("workers_position");
			IEnumerable<SelectListItem> workPositionList = commonworkPosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
			ViewBag.workPositionList = workPositionList;

			WebBuiding buidling = buidingSer.GetWebBuidingByDemandID(DemandID);
            if (BuidingID != 0 && DemandID==0)
            {
                buidling = buidingSer.GetWebuidingByID(BuidingID);
            }
            if (BuidingID == 0 && DemandID == 0)
            {
                buidling = new WebBuiding();
            }

            if (buidling == null)
			{
				buidling = new WebBuiding();
			}
			return View(buidling);
		}

		[HttpPost]
        [ValidateInput(false)]
        public JsonResult AddOrEditBuidingStages(WebBuiding webBuiding)
		{
			WebBuidingService service = new WebBuidingService();
			if (webBuiding.BuidingID > 0)
			{
				service.UpdateWebBuiding(webBuiding);
			}
			else
			{
				webBuiding.WorkerID = Convert.ToInt32(SessionHelper.Get("PositionID"));
				service.AddWebBuiding(webBuiding);
			}

			return Json(new { RetCode = 1 });
		}

		[HttpPost]
		public JsonResult DeleteWebBuiding(int buidingID)
		{
			WebBuidingService service = new WebBuidingService();
			service.DeleteWebBuiding(buidingID);
			return Json(new { RetCode = 1 });
		}


        [HttpGet]
        public ActionResult UpdateBuidingStagesInfo(int buidingID, int StageID)
        {          
            WebBuidingStages stage = stageSer.GetBuidingStageByBuidingIDAndStageID(buidingID, StageID);
            return View(stage);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateBuidingStagesInfo(WebBuidingStages buidingStage)
        {
            int ret = 0;
            ret = stageSer.UpdateBuidingStagesInfo(buidingStage);
            return Json(new { RetCode = 1 });
        }

        [HttpGet]
		public ActionResult UpdateBuidingStageInfo(int buidingID,int StageID)
		{
            WebBuidingService service = new WebBuidingService();
            WebBuiding buiding = service.GetWebuidingByID(buidingID);
            string stageID = buiding.constructionstageID;
            string stageText = buiding.constructionstage;
            string[] stageIDArr = null;
            string[] stageTextArr = null;
            if (!string.IsNullOrWhiteSpace(stageID))
            {
                stageID = stageID.TrimEnd(',');
                stageIDArr = stageID.Split(',');
                stageText = stageText.TrimEnd(',');
                stageTextArr = stageText.Split(',');
            }
            ViewBag.StagesIDs = stageIDArr;
            ViewBag.StagesTexts = stageTextArr;
            ViewBag.BuidingID = buidingID;
            //ViewBag.WorkerType = "工长";
            ViewBag.WorkerType = "工人";
            //WebBuidingStages stage= buidingSer.GetBuidingStageByBuidingIDAndStageID(buidingID, buidingID);



            return View();
		}

		[HttpGet]
		public JsonResult GetBuidingStageInfo(int buidingID, int stageID)
		{
			WebBuidingService service = new WebBuidingService();
			string content = service.GetBuidingStageInfo(buidingID, stageID);
			return Json(new { Content = content }, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult UpdateBuidingStageInfo(WebBuidingStages buidingStage)
		{
			WebBuidingService service = new WebBuidingService();
			service.AddUpdateBuidingStages(buidingStage);
			return Json(new { RetCode = 1 });
		}

		[HttpPost]
		public JsonResult UpdateBuidingStageTimeInfo(WebBuidingTimeStages timeStages)
		{
			WebBuidingService service = new WebBuidingService();
			timeStages.AddTime = DateTime.Now;
			timeStages.FlagDelete = false;
			service.AddBuidingTimeStages(timeStages);
			return Json(new { RetCode = 1 });
		}
        #endregion

        #region 我的装修
        public ActionResult BuidingStagesListByUser()
        {
            WebBuidingService service = new WebBuidingService();
            int UserID = Convert.ToInt32(SessionHelper.Get("UserID"));
            List<WebBuiding> buidingList = service.GetWebBuidingListByUserID(UserID);
            return View(buidingList);
        }
        //没有用
        public ActionResult BuidingStagesDetailByUser(int buidingID=0, int StageID=0)
        {
            WebBuidingStages stage = stageSer.GetBuidingStageByBuidingIDAndStageID(buidingID, StageID);
            return View(stage);
        }
        [HttpPost]
        public JsonResult IsUserEnd(int buidingID,int IsUserend)
        {
            int ret = 0;
            ret=buidingSer.IsUserEnd(buidingID, IsUserend);
            return Json(new { RetCode = ret });
        }
        [HttpPost]
        public JsonResult IsWorkerEnd(int buidingID)
        {
            int ret = 0;
            ret = buidingSer.IsWorkerEnd(buidingID);
            return Json(new { RetCode = ret });
        }
        #endregion

        #region 装修评论
        WebBuidingCaseCommentService commerSer = new WebBuidingCaseCommentService();
        public ActionResult BuidingCommentScore(int CaseID = 0)
        {
            WebBuidingCaseComment comm = new WebBuidingCaseComment();
            comm = commerSer.GetCommentByTypeAndID("WebBuiding", CaseID);
            if (comm == null)
            {
                comm= new WebBuidingCaseComment();
            }           
            return View(comm);
        }
        [HttpPost]
        public JsonResult AddOrEditComment(WebBuidingCaseComment comm)
        {
            int ret = 0;
            if (comm.id == 0)
            {
                ret = commerSer.AddWebBuidingCaseComment(comm);
            }
            else
            {
                ret = commerSer.updateWebBuidingCaseComment(comm);
            }            
            return Json(new { RetCode = ret });
        }
        #endregion
    }
}
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
			else
			{
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

		public ActionResult BuidingStagesList()
		{
			WebBuidingService service = new WebBuidingService();
			int workerID = Convert.ToInt32(SessionHelper.Get("UserID"));
			List<WebBuiding> buidingList = service.GetWebBuidingList(workerID);
			return View(buidingList);
		}

		[HttpGet]
		public ActionResult AddOrEditBuidingStages(int buidingID)
		{
			IWebCommon commonService = new WebCommonService();
			List<WebLookup> commonworkPosition = commonService.GetLookupList("workers_position");
			IEnumerable<SelectListItem> workPositionList = commonworkPosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
			ViewBag.workPositionList = workPositionList;

			WebBuiding buidling = null;
			if (buidingID == 0)
			{
				buidling = new WebBuiding();
			}
			else
			{
				WebBuidingService service = new WebBuidingService();
				buidling = service.GetWebuidingByID(buidingID);
			}
			return View(buidling);
		}

		[HttpPost]
		public JsonResult AddOrEditBuidingStages(WebBuiding webBuiding)
		{
			WebBuidingService service = new WebBuidingService();
			if (webBuiding.BuidingID > 0)
			{
				service.UpdateWebBuiding(webBuiding);
			}
			else
			{
				webBuiding.WorkerID = Convert.ToInt32(SessionHelper.Get("UserID"));
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
		public ActionResult UpdateBuidingStageInfo(int buidingID)
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
	}
}
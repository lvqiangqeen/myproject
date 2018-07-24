using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
	public class AppController : Controller
	{
        WebRecommendService reSer = new WebRecommendService();
        WebCommonService comSer = new WebCommonService();
        t_AreaService areaSer = new t_AreaService();

        // GET: MobileApp/App
        public ActionResult Index()
		{
            return View();
		}

        public ActionResult AreaList()
        {
            List<t_City> list = areaSer.GetHotCityList();
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult setSession(string mkjcitycode, string mkjcityname)
        {
            int ret= 1;
            SessionHelper.SetSession("mkjcitycode", mkjcitycode);
            SessionHelper.SetSession("mkjcityname", mkjcityname);
            return Json(new { RetCode = ret });
        }
        public ActionResult WorkerList()
		{
			WebPeopleService peopleService = new WebPeopleService();
            WebWorkerService WorkerService = new WebWorkerService();
            List<WebWorker> workerList = WorkerService.GetWebWorkerList();

            List<WebPeople> workers = peopleService.GetWebPeopleList("装修工人");
			ViewBag.Workers = workers;
			return View();
		}

		public ActionResult WorkerDetail(int peopleID)
		{
			WebPeopleService peopleService = new WebPeopleService();
			WebPeople worker = peopleService.GetWebPeopleByID(peopleID);
            WebBuidingService buidingService = new WebBuidingService();
            List<WebBuiding> caseList = buidingService.GetWebBuidingList(1);
            ViewBag.CaseList = caseList;
            return View(worker);
		}

		public ActionResult PeopleCenter(int peopleID)
		{
			WebPeopleService peopleService = new WebPeopleService();
			WebPeople worker = peopleService.GetWebPeopleByID(peopleID);
			ViewBag.Name = worker.PeopleName;
			ViewBag.Img = worker.thumbnailImage;
			return View();
		}

		public ActionResult WorkerCaseList(int peopleID)
		{
			WebBuidingService buidingService = new WebBuidingService();
			List<WebBuiding> caseList = buidingService.GetWebBuidingList(peopleID);
			ViewBag.CaseList = caseList;
			return View();
		}

		public ActionResult CaseProgressInfo(int buidingID)
		{		
            WebBuidingStagesService StageSer = new WebBuidingStagesService();
            //WebBuidingStages
            ViewBag.BuidingStages = StageSer.GetWebBuidingStagesListByBuiding(buidingID);
			return View();
		}

		public ActionResult BuidingStageInfo(int buidingID, int stageID)
		{
			WebBuidingStages buidingStage = new WebBuidingStages();
			return View(buidingStage);
		}
		
		public ActionResult DesignCaseList(int peopleID)
		{
			WebBuidingService buidingService = new WebBuidingService();
			List<WebBuiding> caseList = buidingService.GetWebBuidingList(peopleID);
			ViewBag.CaseList = caseList;
			return View();
		}

		public ActionResult WorkerDemandList(int UserID)
		{
			DemandService demandSer = new DemandService();
			List<DecDemand> list = demandSer.GetDecDemandListByUserIDAndType(UserID, "WebUser");
			return View(list);
		}

		public ActionResult BuidingStagesList()
		{
			WebBuidingService service = new WebBuidingService();
			int Workerid = Convert.ToInt32(SessionHelper.Get("PositionID"));
			List<WebBuiding> buidingList = service.GetWebBuidingListByWorkerID(Workerid, true);
			return View(buidingList);
		}
	}
}

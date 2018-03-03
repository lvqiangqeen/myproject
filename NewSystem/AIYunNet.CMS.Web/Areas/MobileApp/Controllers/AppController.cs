﻿using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
	public class AppController : Controller
	{
		// GET: MobileApp/App
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult WorkerList()
		{
			WebPeopleService peopleService = new WebPeopleService();
            WebWorkerService WorkerService = new WebWorkerService();
            List<WebWorker> workerList= WorkerService.

            List<WebPeople> workers = peopleService.GetWebPeopleList("装修工人");
			ViewBag.Workers = workers;
			return View();
		}

		public ActionResult WorkerDetail(int peopleID)
		{
			WebPeopleService peopleService = new WebPeopleService();
			WebPeople worker = peopleService.GetWebPeopleByID(peopleID);
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
	}
}
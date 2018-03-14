using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Controllers
{
    [AllSessionFilter]
    public class WorkersController : Controller
    {
        //
        // GET: /Workers/
        WebPeopleService webPeopleService = new WebPeopleService();
        WebWorkerService webworkerService = new WebWorkerService();
        WebBuidingService webbuidingSer = new WebBuidingService();
        WebBuidingStagesService WebBuidingStagesSer = new WebBuidingStagesService();
        WebBuidingSingleService WebBuidingSingleSer = new WebBuidingSingleService();
        DemandService DemandSer = new DemandService();
        IWebCase webCaseService = new WebCaseService();
        IWebCommon webCommonService = new WebCommonService();//获取参数接口（包括各项分类）
        It_Area t_AreaService = new t_AreaService();

        [Description("设计师列表")]
        public ActionResult DecDesignerList()
        {
            
            string mkjcitycode = SessionHelper.GetSession("mkjcitycode").ToString();
            List<WebPeople> peoplelist = webPeopleService.IndexGetWebDesignerList(mkjcitycode);
            List<t_Area> t_Arealist = t_AreaService.GetAreaListByfather(mkjcitycode);
            List<WebLookup> goodatlist = webCommonService.GetLookupList("People_good_at_style");
            List<WebLookup> pricelist = webCommonService.GetLookupList("People_Dec_price");
            //List<WebLookup> worktimelist = webCommonService.GetLookupList("people_workyear");
            ViewBag.t_Arealist = t_Arealist;
            ViewBag.goodatlist = goodatlist;
            ViewBag.pricelist = pricelist;
            ViewBag.peoplelist = peoplelist;
            return View();
        }
        [Description("设计师主页")]
        public ActionResult DecDesignerIndex(int peopleID)
        {
            webPeopleService.PageViewAdd(peopleID);
            WebPeople worker = webPeopleService.GetWebPeopleByID(peopleID);
            return View(worker);
        }

        [Description("工长列表")]
        public ActionResult DecWorkLeaderList()
        {

            string mkjcitycode = SessionHelper.GetSession("mkjcitycode").ToString();
            List<t_Area> t_Arealist = t_AreaService.GetAreaListByfather(mkjcitycode);
            ViewBag.t_Arealist = t_Arealist;
            return View();
        }

        [Description("工长详情")]
        public ActionResult DecWorkLeaderDetail(int WorkerID=0)
        {
            WebWorker worker=webworkerService.GetWebWorkerByID(WorkerID);

            return View(worker);
        }
        [Description("工长详情")]
        public ActionResult _DecWorkLeader(int WorkerID = 0)
        {
            WebWorker worker = webworkerService.GetWebWorkerByID(WorkerID);
            return View(worker);
        }
        [Description("在建工地详情")]
        public ActionResult DecBuidingDetail(int WorkerID = 0,int BuidingID = 0)
        {
            WebBuiding buiding = webbuidingSer.GetWebBuidingByID(BuidingID);
            WebWorker worker = webworkerService.GetWebWorkerByID(WorkerID);
            ViewBag.buiding = buiding;
            return View(worker);
        }
        /// <summary>
        /// 获得工长阶段信息
        /// </summary>
        public ActionResult GetStageByID(int BuidingID,int StageID)
        {
            WebBuidingStages stage= WebBuidingStagesSer.GetWebBuidingStagesByID(BuidingID, StageID);
            return Json(stage);
        }

        [Description("工人列表")]
        public ActionResult DecWorkerList()
        {
            string mkjcitycode = SessionHelper.GetSession("mkjcitycode").ToString();
            List<t_Area> t_Arealist = t_AreaService.GetAreaListByfather(mkjcitycode);
            ViewBag.t_Arealist = t_Arealist;

            List<WebLookup> positionlist = webCommonService.GetLookupList("workers_position");
            ViewBag.positionlist = positionlist;
            return View();
        }
        [Description("工人详情")]
        public ActionResult DecWorkerDetail(int WorkerID = 0)
        {
            WebWorker worker = webworkerService.GetWebWorkerByID(WorkerID);
            return View(worker);
        }

        [Description("工人buiding详情")]
        public ActionResult DecWorkerBuidingDetail(int WorkerID = 0, int BuidingSingleID = 0)
        {
            WebWorker worker = webworkerService.GetWebWorkerByID(WorkerID);
            WebBuidingSingle buidingSingle = WebBuidingSingleSer.GetWebBuidingSingleByID(BuidingSingleID);
            DecDemand demand = DemandSer.GetDecDemandByID(buidingSingle.DemandID);
            //工人在constructionstageID中只有单个id
            //WebBuidingStages buidingstage = WebBuidingStagesSer.GetWebBuidingStagesByID(BuidingID, Convert.ToInt32(buiding.constructionstageID));
            ViewBag.buidingSingle = buidingSingle;
            ViewBag.demand = demand;
            ViewBag.worker = worker;
            return View(worker);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [AllSessionFilter]
    public class MobileWorkerController : Controller
    {
        WebWorkerService workerSer = new WebWorkerService();
        WebBuidingService buidSer = new WebBuidingService();
        WebBuidingCaseService buidcaseSer = new WebBuidingCaseService();
        WebCommonService wCSer = new WebCommonService();
        t_AreaService t_AreaService = new t_AreaService();
        // GET: MobileApp/MobileWorker
        public ActionResult mWorkerList()
        {
            string mkjcitycode = SessionHelper.GetSession("mkjcitycode").ToString();
          
            List<t_Area> t_Arealist = t_AreaService.GetAreaListByfather(mkjcitycode);
            List<WebLookup> workerlist = wCSer.GetLookupList("workers_position");
            ViewBag.workerlist = workerlist;
            ViewBag.t_Arealist = t_Arealist;
            return View();
        }
        public ActionResult mWorkerLeaderList()
        {
            string mkjcitycode = SessionHelper.GetSession("mkjcitycode").ToString();

            List<t_Area> t_Arealist = t_AreaService.GetAreaListByfather(mkjcitycode);
            ViewBag.t_Arealist = t_Arealist;
            return View();
        }
        public ActionResult mWorkerDetail(int workerid=1)
        {
            WebWorker worker = workerSer.GetWebWorkerByID(workerid);
            List<WebBuiding> list = buidSer.moblieGetWebBuidingList(workerid, 4);
            List<WebBuidingCase> caselist = buidcaseSer.GetBuidingCaseListByWorkerID(workerid, 4);
            ViewBag.caselist = caselist;
            ViewBag.list = list;
            return View(worker);
        }
        #region 修改工人信息
        [HttpPost]
        public int updateWorkerData(string data, string type)
        {
            int ret = 0;
            ret = workerSer.UpdateWebWorkerFromMobile(Convert.ToInt32(SessionHelper.Get("PositionID")), data, type);
            return ret;
        }

        public ActionResult mupdateWebWorker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWorkerPositionType()
        {
            List<lookupJson> list = wCSer.GetJson("workers_position");
            return Json(list);
        }
        #endregion


        public ActionResult mBuidingCaseDetail(int id = 0)
        {
            WebBuidingCase buidingcase = buidcaseSer.GetBuidingCaseByID(id);
            List<WebBuidingCase> buidingcaselist = buidcaseSer.GetBuidingCaseListByWorkerID(buidingcase.WorkerID);
            ViewBag.buidingcaselist = buidingcaselist;
            return View(buidingcase);
        }
    }
}
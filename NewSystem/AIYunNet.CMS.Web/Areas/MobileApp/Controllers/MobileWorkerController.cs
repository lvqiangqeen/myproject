using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [AllSessionFilter]
    public class MobileWorkerController : Controller
    {
        WebWorkerService workerSer = new WebWorkerService();
        WebBuidingService buidSer = new WebBuidingService();
        // GET: MobileApp/MobileWorker
        public ActionResult mWorkerList()
        {
            return View();
        }
        public ActionResult mWorkerDetail(int workerid=1)
        {
            WebWorker worker = workerSer.GetWebWorkerByID(workerid);
            List<WebBuiding> list = buidSer.moblieGetWebBuidingList(workerid, 4);
            ViewBag.list = list;
            return View(worker);
        }
    }
}
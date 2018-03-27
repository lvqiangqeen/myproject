using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [AllSessionFilter]
    public class MobileWorkerController : Controller
    {
        // GET: MobileApp/MobileWorker
        public ActionResult mWorkerList()
        {
            return View();
        }
    }
}
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
    public class CenterWorkerController : Controller
    {
        WebWorkerService worSer = new WebWorkerService();
        // GET: PeopleCenter/CenterWorker
        //选择合作工人
        [HttpGet]
        public ActionResult SelectWorker()
        {
            return View();
        }
        [HttpPost]
        public JsonResult WorkerListExceptSelf(int wokerid = 0,string WorkerName="")
        {
            List<WebWorker> list = new List<WebWorker>();
            list = worSer.GetWorkerExceptSelf(wokerid, WorkerName);
            if (list == null)
            {
                list= new List<WebWorker>();
            }
            return Json(new { code=0, msg="", count= list.Count(), data = list });
        }
    }
}
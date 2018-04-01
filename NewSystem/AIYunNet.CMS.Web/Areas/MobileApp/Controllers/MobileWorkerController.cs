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
        #endregion
    }
}
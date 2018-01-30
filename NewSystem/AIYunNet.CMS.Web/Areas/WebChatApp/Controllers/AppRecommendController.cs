using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Areas.WebChatApp.Controllers
{
    public class AppRecommendController : Controller
    {
        IWebRecommend WebRecommendService = new WebRecommendService();
        // GET: Recommend
        public ActionResult NewsRecommend()
        {
            return View();
        }

        public ActionResult CaseRecommend()
        {
            return View();
        }

        public ActionResult CompanyRecommend()
        {
            return View();
        }
        public ActionResult DesignerRecommend()
        {
            return View();
        }
        public ActionResult WorkerLeaderRecommend()
        {
            return View();
        }
        public ActionResult WokersRecommend()
        {
            return View();
        }
        public ActionResult GetRecommendList(int RecommendType, int num)
        {
            List<WebRecommend> RecommendList = WebRecommendService.GetWebRecommendList(RecommendType, num);
            //ViewBag.RecommendList = RecommendList;
            return Json(RecommendList, JsonRequestBehavior.AllowGet);
        }
    }
}
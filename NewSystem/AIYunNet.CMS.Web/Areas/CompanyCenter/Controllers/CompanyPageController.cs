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

namespace AIYunNet.CMS.Web.Areas.CompanyCenter.Controllers
{
    [CompanyFilter]
    public class CompanyPageController : Controller
    {
        // GET: CompanyCenter/CompanyPage
        WebRecommendService webreser = new WebRecommendService();

        public ActionResult CompanyIndexList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddandEditCompanyLunbo(int webreid)
        {
            WebRecommend webre = webreser.GetWebRecommendByID(webreid);
            if (webre == null)
            {
                webre = new WebRecommend();
            }
            return View(webre);
        }
        [HttpPost]
        public ActionResult AddandEditCompanyLunbo(WebRecommend Recommend)
        {
            int result = 0;
            if (Recommend != null && Recommend.RecommendId > 0)
            {
                result = webreser.UpdateWebRecommend(Recommend);
            }
            else
            {
                result = webreser.AddWebRecommend(Recommend);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteWebRec(int webrID)
        {
            int result = webreser.DeleteWebRecommend(webrID);
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
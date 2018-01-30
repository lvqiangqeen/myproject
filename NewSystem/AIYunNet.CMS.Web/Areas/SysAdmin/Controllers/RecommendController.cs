using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;


namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class RecommendController : BaseController
    {
        IWebRecommend webRecommendService = new WebRecommendService();
        IWebCommon commonService = new WebCommonService();
        // GET: SysAdmin/Recommend
        [HttpGet]
        public ActionResult WebRecommendList(int RecommendType)
        {
            List<WebRecommend> RecommendList = webRecommendService.GetWebRecommendListAllByRecommendType(RecommendType);
            ViewBag.RecommendName = commonService.GetLookupDesc("Recommend_Wechart", RecommendType.ToString());
            ViewBag.RecommendList = RecommendList;
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEditWebRecommend(int WebRecommendID)
        {
            WebRecommend Recommend = webRecommendService.GetWebRecommendByID(WebRecommendID);
            if (Recommend == null)
            {
                Recommend = new WebRecommend();
            }

            //获取推送类别
            IEnumerable<SelectListItem> commonList = null;
            List<WebLookup> common = commonService.GetLookupList("Recommend_Wechart");
            commonList= common.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });

            ViewBag.commonList = commonList;

            return View(Recommend);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrEditWebRecommend(WebRecommend Recommend)
        {
            int result = 0;
            if (Recommend != null && Recommend.RecommendId > 0)
            {
                result = webRecommendService.UpdateWebRecommend(Recommend);
            }
            else
            {
                result = webRecommendService.AddWebRecommend(Recommend);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebRecommend(int WebRecommendID)
        {
            webRecommendService.DeleteWebRecommend(WebRecommendID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Controllers
{
    public class AboutUsController : Controller
    {
        WebRecommendService webreser = new WebRecommendService();
        IWebCommon webCommonService = new WebCommonService();
        // GET: AboutUs
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult AboutUsDetail()
        {
            return View();
        }

        public ActionResult SinglePageDetail(int rid)
        {
            WebRecommend webre = webreser.GetWebRecommendByID(rid);
            return View(webre);
        }
        public ActionResult HelpCenterList(int pageIndex, int PageSize)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format("RecommendType=15 and FlagDelete=0");

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebRecommend";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = "ShowOrder desc,EditOn desc";
            var result = PageList.GetPageListBySQL<WebRecommend>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DecAboutus(int typeid = 13)
        {    
            List<WebRecommend> webre = webreser.GetWebRecommendListPc(typeid);
            if (webre.Count() > 1)
            {
                return RedirectToAction("DecAboutusList", "AboutUs", new { typeid = typeid});
            }
            else
            {
                return RedirectToAction("DecAboutusDetail", "AboutUs", new { typeid = typeid });
            }
            
        }
        public ActionResult DecAboutusDetail(int typeid = 13)
        {
            string title = webCommonService.GetLookupDesc("Recommend_Wechart", typeid.ToString());
            List<WebRecommend> webre = webreser.GetWebRecommendListPc(typeid);
            WebRecommend model = webre[0];
            ViewBag.Abouttitle = title;
            return View(model);
        }
        public ActionResult DecAboutusList(int typeid = 13)
        {
            string title = webCommonService.GetLookupDesc("Recommend_Wechart", typeid.ToString());
            List<WebRecommend> webre = webreser.GetWebRecommendListPc(typeid);
            ViewBag.Abouttitle = title;
            ViewBag.list = webre;
            return View();
        }

    }
}
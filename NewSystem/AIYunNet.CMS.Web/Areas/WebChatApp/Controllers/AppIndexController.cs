using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.WebChatApp.Controllers
{
    public class AppIndexController : Controller
    {
        IWebRecommend WebRecommendService = new WebRecommendService();
        // GET: Index
        public ActionResult Index()
        {
            //首页轮播推送
            List<WebRecommend> webtui = WebRecommendService.GetWebRecommendList(7, 3);
            ViewBag.Weblunbo = webtui;

            //首页装修公司
            List<WebRecommend> webCompanys = WebRecommendService.GetWebRecommendList(6,4);
            ViewBag.WebCompanys = webCompanys;          

            //首页设计师
            List<WebRecommend> webDesigners = WebRecommendService.GetWebRecommendList(3, 4);
            ViewBag.WebDesigners = webDesigners;           

            //首页案例
            List<WebRecommend> webCases = WebRecommendService.GetWebRecommendList(2, 4);
            ViewBag.WebCases = webCases;
            
            //首页工人推送
            List<WebRecommend> webWorkLeaders = WebRecommendService.GetWebRecommendList(5, 4);
            ViewBag.webWorkLeaders = webWorkLeaders;            

            return View();
        }
    }
}
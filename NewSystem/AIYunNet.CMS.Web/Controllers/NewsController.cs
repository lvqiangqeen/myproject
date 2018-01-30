using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Controllers
{
    public class NewsController : Controller
    {
        WebNewsService webnewsservice = new WebNewsService();
        public ActionResult NewsList()
        {
            return View();
        }
        public ActionResult DecorateNewsIndex()
        {
            return View();
        }
        public ActionResult DecorateNewsDetail(int newsID)
        {
            webnewsservice.PageViewAdd(newsID);
            WebNews webnew = webnewsservice.GetWebNewsByID(newsID);
            return View(webnew);
        }

    }
}

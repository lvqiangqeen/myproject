using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    public class mAticleController : Controller
    {
        WebCaseService caseSer = new WebCaseService();

        // GET: MobileApp/mAticle
        public ActionResult AticleIndex(int id=68)
        {
            WebCase webcase = caseSer.GetWebCaseByID(id);
            List<WebCase> caselist = caseSer.GetHotWebCaseList(3, webcase.DecType);
            ViewBag.caselist = caselist;
            return View(webcase);
        }
    }
}
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
    [AllSessionFilter]
    [MobileUserFilter]
    public class MobileTendersController : Controller
    {
        // GET: MobileApp/MobileTenders
        public ActionResult TenderList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TenderDetail(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult TenderDetail(DecTender tender)
        {
            return View();
        }
    }
}
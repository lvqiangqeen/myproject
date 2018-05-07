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
    [MobileUserFilter]
    public class MobileCommentController : Controller
    {
        // GET: MobileApp/MobileComment
        public ActionResult CommentDetail()
        {
            return View();
        }
    }
}
﻿using System;
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
    public class MobileCenterController : Controller
    {
        WebUserService webUserservice = new WebUserService();
        WebPeopleService webpeopleservice = new WebPeopleService();
        WebWorkerService webWorkerService = new WebWorkerService();
        t_AreaService areaService = new t_AreaService();
        #region 主页
        // GET: MobileApp/MobileCenter
        public ActionResult mPCenter()
        {
            WebUser user = webUserservice.GetWebUserByID(Convert.ToInt32(SessionHelper.Get("UserID")));
            return View(user);
        }
        #endregion

        

        #region 个人资料
        public ActionResult PersonData()
        {
            return View();
        }
        #endregion
    }
}
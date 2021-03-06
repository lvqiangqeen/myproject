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
    [AllSessionFilter]
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

        #region 工人工长资料
        public ActionResult PersonData()
        {
            WebUser user = webUserservice.GetWebUserByID(Convert.ToInt32(SessionHelper.Get("UserID")));
            return View(user);
        }
        //直接修改
        public ActionResult EditPersonDataText()
        {
            return View();
        }
        public ActionResult EditPersonDataAreas()
        {

            return View();
        }
        public ActionResult EditPersonDataShengFen()
        {
            return View();
        }
        [HttpPost]
        public int updatePersonData(string data, string type)
        {
            int ret = 0;
            ret = webUserservice.UpdateWebUserFromMobileBywoker(Convert.ToInt32(SessionHelper.Get("UserID")), data, type);
            return ret;
        }
        //上传身份证件
        [HttpPost]
        public int uploadShengfen(string data, string type)
        {
            int ret = 0;
            ret = webUserservice.UpdateWebUserFromMobileBywoker(Convert.ToInt32(SessionHelper.Get("UserID")), data, type);
            return ret;
        }
        #endregion


        #region 普通用户资料
        public ActionResult UserData()
        {
            WebUser user = webUserservice.GetWebUserByID(Convert.ToInt32(SessionHelper.Get("UserID")));
            return View(user);
        }
        [HttpPost]
        public int updateUserData(string data, string type)
        {
            int ret = 0;
            ret = webUserservice.UpdateWebUserFromMobile(Convert.ToInt32(SessionHelper.Get("UserID")), data, type);
            return ret;
        }
        public ActionResult EditUserDataText()
        {
            return View();
        }
        #endregion
    }
}
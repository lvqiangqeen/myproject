using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class UsersCenterController : BaseController
    {
        WebUserService webuserservice = new WebUserService();
        WebPeopleAuthenticationService AuthenticationService = new WebPeopleAuthenticationService();
        WebPeopleGuarantMoneyService GuarantMoneyService = new WebPeopleGuarantMoneyService();
        WebCommonService webcommonser = new WebCommonService();
        // GET: SysAdmin/UsersCenter
        public ActionResult Userlist()
        {
            List<WebUser> userlist = webuserservice.GetWebUserList();
            ViewBag.userlist = userlist;
            return View();
        }
        [HttpGet]
        public ActionResult AddAndUpdateUser(int userid)
        {
            WebUser webuser = webuserservice.GetWebUserByID(userid);
            List<WebLookup> weblooktypelist = webcommonser.GetLookupList("people_category");
            IEnumerable<SelectListItem> typelist = weblooktypelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.typelist = typelist;
            return View(webuser);
        }
        [HttpPost]
        public ActionResult AddAndUpdateUser(WebUser webuser)
        {
            int result = 0;
            if (webuser != null && webuser.UserID > 0)
            {
                result = webuserservice.UpdateWebUser(webuser);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebUser(int UserID)
        {
            webuserservice.deleteWebUser(UserID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
        //身份认证
        public ActionResult Authenticationlist()
        {
            List<WebPeopleAuthentication> aulist = AuthenticationService.GetWebPeopleAuthenticationList();
            ViewBag.aulist = aulist;
            return View();
        }
        public ActionResult DeleteAu(int AUID)
        {
            AuthenticationService.DeleteWebPeopleAuthentication(AUID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddAndUpdateAu(int auid)
        {
            WebPeopleAuthentication authen = AuthenticationService.GetWebPeopleAuthenticationByID(auid);
            return View(authen);
        }
        [HttpPost]
        public int AddAndUpdateAu(int AUID,int IsIsAuthentication)
        {
            if (IsIsAuthentication == 1)
            {
                AuthenticationService.IsAuthentication(AUID);
            }
            else
            {
                AuthenticationService.IsNotAuthentication(AUID);
            }
            return 1;
        }
        //保证金申请
        public ActionResult GuarantMoneylist()
        {
            List<WebPeopleGuarantMoney> gulist = GuarantMoneyService.GetWebPeopleGuarantMoneyList();
            ViewBag.gulist = gulist;
            return View();
        }
        public ActionResult DeleteGu(int GUID)
        {
            GuarantMoneyService.DeleteWebPeopleGuarantMoney(GUID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddAndUpdateGu(int guid)
        {
            WebPeopleGuarantMoney Gu = GuarantMoneyService.GetWebPeopleGuarantMoneyByID(guid);
            return View(Gu);
        }
        [HttpPost]
        public int AddAndUpdateGu(int GUID,int IsGuarantMoney)
        {
            if (IsGuarantMoney == 1)
            {
                GuarantMoneyService.IsGuarantMoney(GUID);
            }
            else
            {
                GuarantMoneyService.IsNotGuarantMoney(GUID);
            }
            return 1;
        }
    }
}
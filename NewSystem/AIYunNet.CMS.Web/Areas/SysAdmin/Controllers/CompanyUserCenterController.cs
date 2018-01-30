using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class CompanyUserCenterController : BaseController
    {
        // GET: SysAdmin/CompanyUserCenter
        WebCompanyUserService webcomUserSer = new WebCompanyUserService();
        WebCompanyService webcomser = new WebCompanyService();
        WebCompanyAuthenticationService AuthenticationService = new WebCompanyAuthenticationService();
        WebCompanyGuarantMoneyService GuarantMoneyService = new WebCompanyGuarantMoneyService();
        public ActionResult CompanyUserList()
        {
            List<WebCompanyUser> webcomUlist = webcomUserSer.GetWebCompanyUserList();
            ViewBag.webcomUlist = webcomUlist;
            return View();
        }
        [HttpGet]
        public ActionResult AddAndEditCompanyUser(int UserID)
        {
            WebCompanyUser webcomuser = webcomUserSer.GetWebCompanyUserByID(UserID);
            return View(webcomuser);
        }
        [HttpPost]
        public ActionResult AddAndEditCompanyUser(WebCompanyUser webcomuser)
        {
            int result = 0;
            if (webcomuser != null && webcomuser.CompanyUserID > 0)
            {
                result = webcomUserSer.UpdateWebCompanyUser(webcomuser);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebComUser(int ComUserID)
        {
            webcomUserSer.deleteWebCompanyUser(ComUserID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

        //公司认证
        public ActionResult Authenticationlist()
        {
            List<WebCompanyAuthentication> aulist = AuthenticationService.GetWebCompanyAuthenticationList();
            ViewBag.aulist = aulist;
            return View();
        }
        public ActionResult DeleteAu(int AUID)
        {
            AuthenticationService.DeleteWebCompanyAuthentication(AUID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddAndUpdateAu(int auid)
        {
            WebCompanyAuthentication authen = AuthenticationService.GetWebCompanyAuthenticationByID(auid);
            return View(authen);
        }
        [HttpPost]
        public int AddAndUpdateAu(int AUID, int IsIsAuthentication)
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
            List<WebCompanyGuarantMoney> gulist = GuarantMoneyService.GetWebCompanyGuarantMoneyList();
            ViewBag.gulist = gulist;
            return View();
        }
        public ActionResult DeleteGu(int GUID)
        {
            GuarantMoneyService.DeleteWebCompanyGuarantMoney(GUID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddAndUpdateGu(int guid)
        {
            WebCompanyGuarantMoney Gu = GuarantMoneyService.GetWebCompanyGuarantMoneyByID(guid);
            return View(Gu);
        }
        [HttpPost]
        public int AddAndUpdateGu(int GUID, int IsGuarantMoney)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Areas.CompanyCenter.Controllers
{
    [CompanyFilter]
    public class CompanyVerifyController : Controller
    {
        // GET: CompanyCenter/CompanyVerify
        WebCompanyAuthenticationService comAuser = new WebCompanyAuthenticationService();
        WebCompanyGuarantMoneyService comGmser = new WebCompanyGuarantMoneyService();

        public ActionResult CompanyAuthentication(int UserID)
        {
            WebCompanyAuthentication comAu = comAuser.GetWebCompanyAuthenticationByUserID(UserID);
            if (comAu==null)
            {
                comAu = new WebCompanyAuthentication();
            }
            return View(comAu);
        }
        [HttpPost]
        public ActionResult addCompanyAuthentication(WebCompanyAuthentication webAuthen)
        {
            int result = 0;
            WebCompanyAuthentication webthis = comAuser.GetWebCompanyAuthenticationByUserID(webAuthen.CompanyUserID);
            if (webthis != null && webthis.IsAuthentication == 2)
            {
                result = comAuser.UpdateWebCompanyAuthentication(webAuthen);
                //申请
            }
            else if (webthis != null && webthis.IsAuthentication == 1)
            {
                //已通过
                result = 0;
            }
            else if (webthis != null && webthis.IsAuthentication == 0)
            {
                //已提交
                result= 2;
            }
            else
            {
                //申请
                result = comAuser.AddWebCompanyAuthentication(webAuthen);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompanyGuarantMoney(int UserID)
        {
            WebCompanyGuarantMoney comGm = comGmser.GetWebCompanyGuarantMoneyByUserID(UserID);
            if (comGm == null)
            {
                comGm = new WebCompanyGuarantMoney();
            }
            return View(comGm);
        }
        [HttpPost]
        public ActionResult addCompanyGuarantMoney(WebCompanyGuarantMoney GuarantMoney)
        {
            int result = 0;
            WebCompanyGuarantMoney webthis = comGmser.GetWebCompanyGuarantMoneyByUserID(GuarantMoney.CompanyUserID);
            if (webthis != null && webthis.IsGuarantMoney == 2)
            {
                result= comGmser.UpdateWebCompanyGuarantMoney(GuarantMoney);
                //申请
            }
            else if (webthis != null && webthis.IsGuarantMoney == 1)
            {
                //已通过
                result=0;
            }
            else if (webthis != null && webthis.IsGuarantMoney == 0)
            {
                //已提交
                result=2;
            }
            else
            {
                //申请
                result= comGmser.AddWebCompanyGuarantMoney(GuarantMoney);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompanyVerifyList()
        {
            return View();
        }
    }
}
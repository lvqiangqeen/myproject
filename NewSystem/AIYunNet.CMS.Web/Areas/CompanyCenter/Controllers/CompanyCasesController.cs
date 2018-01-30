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
    public class CompanyCasesController : Controller
    {
        WebCaseService webcaseser = new WebCaseService();
        string userAcount = SessionHelper.Get("companyUserName");
        string companyID = SessionHelper.Get("companyID");
        IWebCommon commonService = new WebCommonService();
        public ActionResult CompanyCaseList()
        {
            List<WebCase> caselist = webcaseser.GetWebCaseListByCompanyID(Convert.ToInt32(companyID));
            ViewBag.caselist = caselist;
            return View();
        }
        [HttpGet]
        public ActionResult AddAndUpdateCase(int CaseID)
        {
            WebCase webcase = new WebCase();
            if (CaseID != 0)
            {
                webcase = webcaseser.GetWebCaseByID(CaseID);
            }
            return View(webcase);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAndUpdateCase(WebCase webCase)
        {
            int result = 0;
            if (webCase != null && webCase.CaseID > 0)
            {
                result = webcaseser.UpdateWebCaseByCompany(webCase);
            }
            else
            {
                result = webcaseser.AddWebCase(webCase);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteWebCase(int CaseID)
        {
            int result = webcaseser.DeleteWebCase(CaseID);
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
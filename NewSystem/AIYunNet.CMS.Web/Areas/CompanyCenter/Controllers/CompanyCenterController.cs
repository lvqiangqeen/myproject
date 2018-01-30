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
    public class CompanyCenterController : Controller
    {
        WebCompanyService webcompanyser = new WebCompanyService();
        string userAcount = SessionHelper.Get("companyUserName");
        WebCompanyUserService webcomuser = new WebCompanyUserService();
        t_AreaService areaService = new t_AreaService();

        // GET: CompanyCenter/CompanyCenter
        public ActionResult CompanyCenterIndex()
        {
            return View();
        }
        public ActionResult HomeIndex()
        {
            return View();
        }
        //企业证书
        public ActionResult CompanyHonorBook()
        {
            WebCompanyUser comuer = webcomuser.GetWebCompanyUserByAccount(userAcount);
            WebCompany webcom = webcompanyser.GetWebCompanyByUserID(comuer.CompanyUserID);
            return View(webcom);
        }

        //添加证书
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrEditWebCompanyLicence(WebCompany company)
        {
            int result = 0;
            if (company != null && company.CompanyID > 0)
            {
                result = webcompanyser.UpdateWebCompanyLicence(company);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
        //公司注册信息
        [HttpGet]
        public ActionResult CompanyRegist()
        {
            WebCompanyUser comuer = webcomuser.GetWebCompanyUserByAccount(userAcount);
            WebCompany webcom = webcompanyser.GetWebCompanyByUserID(comuer.CompanyUserID);
            return View(webcom);
        }
        //添加注册信息
        [HttpPost]
        public ActionResult CompanyRegist(WebCompany company)
        {
            int result = 0;
            if (company != null && company.CompanyID > 0)
            {
                result = webcompanyser.UpdateWebCompanyRegist(company);
            }
            
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
        //公司信息
        public ActionResult CompanyDetail()
        {
            WebCompanyUser comuer = webcomuser.GetWebCompanyUserByAccount(userAcount);
            WebCompany webcom = webcompanyser.GetWebCompanyByUserID(comuer.CompanyUserID);
            //省份
            IEnumerable<SelectListItem> provinceList = null;
            List<t_Province> common = areaService.GetProvinceList();
            provinceList = common.Select(com => new SelectListItem { Value = com.provinceID.ToString(), Text = com.province });
            ViewBag.provinceList = provinceList;
            return View(webcom);
        }
        [HttpPost]
        public ActionResult updateCompanyDetail(WebCompany webcompany)
        {
            int result = 0;
            WebCompanyUser comuer = webcomuser.GetWebCompanyUserByAccount(userAcount);
            result = webcompanyser.UpdateWebCompanyByCompanyCenter(webcompany);
            WebCompanyUser comuser1 = new WebCompanyUser
            {
                CompanyUserID = comuer.CompanyUserID,
                CompanyName = webcompany.CompanyName
            };
            webcomuser.UpdateWebCompanyUserFromCenter(comuser1);
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
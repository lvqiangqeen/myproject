using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.BLL.IService;
using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.WebChatApp.Controllers
{
    public class AppCompanysController : Controller
    {
        IWebCompany webCompanyService = new WebCompanyService();      
        // GET: Companys
        public ActionResult CompanysList()
        {
            return View();
        }
        public ActionResult GetCompanysList(int pageIndex, int PageSize)
        {
            string goodatid = "";
            string areasid = "";
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 {0} {1}",
                goodatid == "0" || string.IsNullOrEmpty(goodatid) ? "" : "and GoodAtStyleID like '%" + goodatid + "%'",
                areasid == "0" || string.IsNullOrEmpty(areasid) ? "" : "and AreasID like '%" + areasid + "%'");

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebCompany";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = "AddOn desc,CompanyID desc";
            var result = PageList.GetPageListBySQL<WebCompany>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //公司详情
        public ActionResult CompanyDetail(int CompanyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(CompanyID);
            return View(company);
        }
        //公司案例
        public ActionResult CompanyCaseList(int CompanyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(CompanyID);
            return View(company);
        }
        //获取公司设计案例
        public ActionResult GetCasesListByCompanyID(int pageIndex, int PageSize,int CompanyID)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 and CompanyID={0} ", CompanyID);

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebCase";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = "AddOn desc,CaseID desc";
            var result = PageList.GetPageListBySQL<WebCase>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //公司团队
        public ActionResult CompanyDesignerList(int CompanyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(CompanyID);
            return View(company);
        }
        //获取公司团队
        public ActionResult GetDesignersListByCompanyID(int pageIndex, int PageSize,int CompanyID)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 and PeopleCategory='设计师' and CompanyID={0} ", CompanyID);

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebPeople";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = "AddOn desc";
            var result = PageList.GetPageListBySQL<WebPeople>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}
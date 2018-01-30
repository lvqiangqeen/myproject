using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;

namespace AIYunNet.CMS.Web.Areas.WebChatApp.Controllers
{
    public class AppCaseController : Controller
    {
        IWebCase webCaseService = new WebCaseService();
        // GET: Cases
        public ActionResult CaseList()
        {
            return View();
        }
        public ActionResult GetCasesList(int pageIndex, int PageSize)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 ");

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

        public ActionResult CaseDetail(int CaseID)
        {
            WebCase webcase = webCaseService.GetWebCaseByID(CaseID);
            return View(webcase);
        }
    }
}
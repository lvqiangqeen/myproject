using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Areas.WebChatApp.Controllers
{
    public class AppPeoplesController : Controller
    {
        IWebPeople webPeopleService = new WebPeopleService();
        IWebCase webCaseService = new WebCaseService();
        // GET: Peoples
        public ActionResult DesignerList()
        {
            return View();
        }
        public ActionResult DesignerDetail(int PeopleID)
        {
            List<WebCase> listcase = webCaseService.GetWebCaseListByPeopleIDAndCount(PeopleID, 6);
            WebPeople Designer = webPeopleService.GetWebPeopleByID(PeopleID);
            ViewBag.CaseList = listcase;
            return View(Designer);
        }
        //设计师列表
        public ActionResult GetDesignersList(int pageIndex, int PageSize)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 and PeopleCategory='设计师'");

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


        public ActionResult WorkleaderList()
        {
            return View();
        }
        //工人详情页
        public ActionResult WorkerDetail(int PeopleID)
        {
            WebPeople Worker = webPeopleService.GetWebPeopleByID(PeopleID);
            return View(Worker);
        }
        //工长列表
        public ActionResult GetWorkleaderList(int pageIndex, int PageSize)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 and PeopleCategory='装修工长'");

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



        public ActionResult WorkerList()
        {
            return View();
        }
        //工人列表
        public ActionResult GetWorkerList(int pageIndex, int PageSize)
        {
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 and PeopleCategory!='设计师'");

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
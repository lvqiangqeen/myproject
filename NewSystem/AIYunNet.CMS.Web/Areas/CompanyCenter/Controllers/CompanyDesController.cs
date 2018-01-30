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
    public class CompanyDesController : Controller
    {
        WebPeopleService webpeoser = new WebPeopleService();
        string userAcount = SessionHelper.Get("companyUserName");
        string companyID= SessionHelper.Get("companyID");
        IWebCommon commonService = new WebCommonService();
        //人员列表
        public ActionResult DesignerList(string peopleCategory)
        {

            List<WebPeople> peoplelist = webpeoser.GetAllWebPeopleListByCompanyAndPeopleCategory(peopleCategory, Convert.ToInt32(companyID));
            ViewBag.peoplelist = peoplelist;
            return View();
        }
        [HttpGet]
        public ActionResult AddAndUpdatePeople(int PeopleID)
        {
            List<WebLookup> commonPeoplePosition = commonService.GetLookupList("people_position");
            IEnumerable<SelectListItem> PeoplePositionList = commonPeoplePosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.PeoplePositionList = PeoplePositionList;

            List<WebLookup> commonworkPosition = commonService.GetLookupList("People_workers_position");
            IEnumerable<SelectListItem> workPositionList = commonworkPosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.workPositionList = workPositionList;

            //工作年限
            List<WebLookup> workyearlist = commonService.GetLookupList("people_workyear");
            IEnumerable<SelectListItem> workyearslist = workyearlist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.workyearslist = workyearslist;

            WebPeople people = webpeoser.GetWebPeopleByID(PeopleID);
            if (people == null)
            {
                people = new WebPeople();
            }
            return View(people);
        }
        [HttpPost]
        public ActionResult AddAndUpdatePeople(WebPeople webpeople)
        {

            int result = 0;
            if (webpeople != null && webpeople.PeopleID > 0)
            {
                result = webpeoser.UpdateWebPeopleByCompanyDes(webpeople);
            }
            else
            {
                result = webpeoser.AddWebPeople(webpeople);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteWebPeople(int peopleID)
        {
            int result = webpeoser.DeleteWebPeople(peopleID);
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
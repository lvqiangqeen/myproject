using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Common.Utility.Tools;
using AIYunNet.CMS.Domain.DataHelper;

namespace AIYunNet.CMS.Web.Controllers
{
    public class CaseController : Controller
    {
        IWebCompany webCompanyService = new WebCompanyService();
        IWebPeople webPeopleService = new WebPeopleService();
        WebCaseService webCaseService = new WebCaseService();
        IWebNews webNewsService = new WebNewsService();
        It_Area t_AreaService = new t_AreaService();
        IWebCommon webCommonService = new WebCommonService();//获取参数接口（包括各项分类）
        Z_CommentService commentService = new Z_CommentService();
        /// <summary>
        /// 案例列表页
        /// </summary>
        public ActionResult DecCaseList()
        {
            int DecType = string.IsNullOrEmpty(Request["DecType"]) ? 1 : Convert.ToInt32(Request["DecType"]);
            List<WebCase> hotlist = webCaseService.GetHotWebCaseList(4, DecType);
            ViewBag.hotlist = hotlist;
            return View();
        }
        public ActionResult DecCaseDetail(int CaseID)
        {
            webCaseService.PageViewAdd(CaseID);
            WebCase casse = webCaseService.GetWebCaseByID(CaseID);
            List<WebCase> caselist = webCaseService.GetWebCaseListByPeopleIDAndCount(casse.PeopleID, 2);
            ViewBag.caselist = caselist;
            if (casse.CompanyID != 0)
            {
                WebCompany com = webCompanyService.GetWebCompanyByID(casse.CompanyID);
                ViewBag.com = com;
            }
            else
            {
                WebPeople peo = webPeopleService.GetWebPeopleByID(casse.PeopleID);
                ViewBag.peo = peo;
            }

            List<PeopleComments> commentList = commentService.GetCommentListByID(CaseID, "WebCase", 100);
            ViewBag.commentList = commentList;
            return View(casse);
        }
    }
}
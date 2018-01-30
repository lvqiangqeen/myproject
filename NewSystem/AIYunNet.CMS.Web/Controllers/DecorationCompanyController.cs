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
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Controllers
{
    [AllSessionFilter]
    public class DecorationCompanyController : Controller
    {
        //
        // GET: /Company/
        WebCompanyService webCompanyService = new WebCompanyService();
        IWebPeople webPeopleService = new WebPeopleService();
        IWebCase webCaseService = new WebCaseService();
        IWebNews webNewsService = new WebNewsService();
        It_Area t_AreaService = new t_AreaService();
        IWebCommon webCommonService = new WebCommonService();//获取参数接口（包括各项分类）
        WebRecommendService webRecommend = new WebRecommendService();
        [Description("装修公司土巴菜单栏")]
        public ActionResult _CompanyTuBaHead(int companyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            return View(company);
        }

        [Description("装修公司土巴主页")]
        public ActionResult CompanyTuBa(int companyID)
        {
            webCompanyService.PageViewAdd(companyID);
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            List<WebCase> caselist = webCaseService.GetWebCaseListByCompanyIDAndCount(companyID, 3);
            List<WebPeople> peoplelist = webPeopleService.GetWebPeopleListByCompanyIDAndCount(companyID, 6);
            List<WebRecommend> recommodlist = webRecommend.GetWebRecommendByCompany(12, 8, companyID);
            //List<WebNews> newsList = webNewsService.IndexGetWebNewsListByCompanyID(companyID, modelID);
            ViewBag.CaseList = caselist;
            ViewBag.PeopleList = peoplelist;
            ViewBag.recommodlist = recommodlist;
            //ViewBag.NewsList = newsList;
            return View(company);
        }

        [Description("装修公司土巴详细信息")]
        public ActionResult CompanyTuBaDetail(int companyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            return View(company);
        }

        [Description("装修公司土巴装修案例")]
        public ActionResult CompanyTuBaCaseList(int companyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            return View(company);
        }
        [Description("装修公司土巴案例详情")]
        public ActionResult CompanyTuBaCaseDetail(int companyID,int caseID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            List<WebCase> caselist = webCaseService.GetWebCaseListByCompanyIDAndCount(companyID, 2);
            ViewBag.CaseList = caselist;
            return View(company);
        }

        [Description("装修公司土巴点评")]
        public ActionResult CompanyTuBaRemark(int companyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            return View(company);
        }

        [Description("装修公司土巴设计师列表")]
        public ActionResult CompanyTuBaDesignerList(int companyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            //设计师类型
            List<WebLookup> peoplepositionlist = webCommonService.GetLookupList("people_position");//设计级别
            ViewBag.peoplepositionlist = peoplepositionlist;
            return View(company);
        }

        [Description("装修公司土巴设计师详情")]
        public ActionResult CompanyTuBaDesignerDetail(int companyID,int peopleID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            //设计师类型
            List<WebLookup> peoplepositionlist = webCommonService.GetLookupList("people_position");//设计级别
            WebPeople people = webPeopleService.GetWebPeopleByID(peopleID);
            ViewBag.people = people;
            ViewBag.peoplepositionlist = peoplepositionlist;

            List<WebCase> caselist = webCaseService.GetWebCaseListByPeopleID(peopleID);
            ViewBag.caselist = caselist;
            return View(company);
        }

        [Description("装修公司列表")]
        public ActionResult DecCompanyList()
        {
            string mkjcitycode = SessionHelper.GetSession("mkjcitycode").ToString();
            List<t_Area> t_Arealist = t_AreaService.GetAreaListByfather(mkjcitycode);
            List<WebLookup> Typelist = webCommonService.GetLookupList("Company_Goodattype");
            List<WebLookup> Stylelist = webCommonService.GetLookupList("Company_GoodatStyle");
            List<WebLookup> Pricelist = webCommonService.GetLookupList("Company_Price");
            ViewBag.t_Arealist = t_Arealist;
            ViewBag.Typelist = Typelist;
            ViewBag.Stylelist = Stylelist;
            ViewBag.Pricelist = Pricelist;
            return View();
        }
    }
}

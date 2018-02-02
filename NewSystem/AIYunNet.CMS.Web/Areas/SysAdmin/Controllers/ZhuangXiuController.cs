using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{

    public class ZhuangXiuController : BaseController
    {
        //
        // GET: /Admin/ZhuangXiu/
        IWebCompany webCompanyService = new WebCompanyService();
        IWebPeople webPeopleService = new WebPeopleService();
        IWebRecommend webRRecommendService = new WebRecommendService();
        IWebCommon webCommonService = new WebCommonService();
        t_AreaService areaService = new t_AreaService();

        public ActionResult Index()
        {
            return View();
        }

        #region Company management

        [HttpGet]
        public ActionResult WebCompanyList()
        {
            if (SiteHelper.IsSuperVisor())
            {
                List<WebCompany> companySource = webCompanyService.GetWebCompanyList();
                ViewBag.CompanyList = companySource;
                return View();
            }
            else
            {
                return RedirectToAction("AddOrEditWebCompany", new { companyID = SessionHelper.GetSession("companyID") });
            }

        }

        [HttpGet]
        public ActionResult AddOrEditWebCompany(int companyID)
        {
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            if (company == null)
            {
                company = new WebCompany();
            }
            //公司人员列表
            List<WebPeople> companyPeoples = webPeopleService.GetAllWebPeopleListByCompanyAndPeopleCategory("",companyID);
            ViewBag.CompanyPeoples = companyPeoples;
            //公司案例列表
            List<WebCase> webCaseList = webCaseService.GetWebCaseListByCompanyID(companyID);
            ViewBag.WebCases = webCaseList;
            //公司首页推送
            List<WebRecommend> RecommendList = webRRecommendService.GetAllWebRecommendByCompany(12, companyID);
            ViewBag.RecommendList = RecommendList;

            //省份
            IEnumerable<SelectListItem> provinceList = null;
            List<t_Province> common = areaService.GetProvinceList();
            provinceList = common.Select(com => new SelectListItem { Value = com.provinceID.ToString(), Text = com.province });
            ViewBag.provinceList = provinceList;
            return View(company);
        }

        [HttpPost]
        public ActionResult AddOrEditWebCompany(WebCompany company)
        {
            int result = 0;
            if (company != null && company.CompanyID > 0)
            {
                //修改
                result = webCompanyService.UpdateWebCompany(company);
            }
            else
            {
                //添加
                result = webCompanyService.AddWebCompany(company);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }

        //添加资质
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrEditWebCompanyLicence(WebCompany company)
        {
            int result = 0;
            if (company != null && company.CompanyID > 0)
            {
                result = webCompanyService.UpdateWebCompanyLicence(company);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
        //添加注册信息
        [HttpPost]
        public ActionResult AddOrEditWebCompanyRegist(WebCompany company)
        {
            int result = 0;
            if (company != null && company.CompanyID > 0)
            {
                result = webCompanyService.UpdateWebCompanyRegist(company);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebCompany(int companyID)
        {
            webCompanyService.DeleteWebCompany(companyID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region People management
        
        [HttpGet]
        public ActionResult WebPeopleList(string PeopleCategory)
        {
            List<WebPeople> webPeopleList = null;
            if (SiteHelper.IsSuperVisor())
            {
                webPeopleList = webPeopleService.GetWebPeopleList(PeopleCategory);
            }
            else
            {
                webPeopleList = webPeopleService.GetAllWebPeopleListByCompanyAndPeopleCategory(PeopleCategory, (int)SessionHelper.GetSession("companyID"));
            }

            ViewBag.PeopleList = webPeopleList;
            return View();
        }

        
        [HttpGet]
        public ActionResult AddOrEditWebPeople(int peopleID)
        {
            int CompanyID = Convert.ToInt32(Request["CompanyID"] == null || Request["CompanyID"] == "" ? "0" : Request["CompanyID"]);
            string PeopleCategory =Request["PeopleCategory"] == null || Request["PeopleCategory"].ToString() == "" ? "" : Request["PeopleCategory"].ToString();
            WebPeople people = webPeopleService.GetWebPeopleByID(peopleID);
            if (people == null)
            {
                people = new WebPeople();
            }

            //获取员工类别
            IList<SelectListItem> peopleCategorys = new List<SelectListItem>();
            if (PeopleCategory != null)
            {
                peopleCategorys.Add(new SelectListItem() { Value = PeopleCategory, Text = PeopleCategory });
            }
            else
            {
                List<WebLookup> webCommonlist = webCommonService.GetLookupList("people_category");
                foreach (var arr in webCommonlist)
                {
                    peopleCategorys.Add(new SelectListItem() { Value = arr.Code, Text = arr.Description });
                }
            }
            ViewBag.PeopleCategorys = peopleCategorys;

            //获取装修公司
            IEnumerable<SelectListItem> companys = null;
            if (SiteHelper.IsSuperVisor() && CompanyID == 0)//总后台
            {
                List<WebCompany> companyList = webCompanyService.GetWebCompanyList();
                companyList.Add(new WebCompany
                {
                    CompanyID = 0,
                    CompanyName = "无装修公司"
                });
                companys = companyList.Select(com => new SelectListItem { Value = com.CompanyID.ToString(), Text = com.CompanyName });
            }
            else if (CompanyID > 0)//装修公司页面进入
            {
                companys = new List<SelectListItem> { new SelectListItem { Value = CompanyID.ToString(), Text = webCompanyService.GetWebCompanyByID(CompanyID).CompanyName } };
            }
            else//装修公司后台
            {
                companys = new List<SelectListItem> { new SelectListItem { Value = SessionHelper.GetSession("companyID").ToString(), Text = SessionHelper.GetSession("companyName").ToString() } };
            }
            ViewBag.Companys = companys.ToList();

            //案例列表
            List<WebCase> webCaseList = null;
            if (peopleID != 0)
            {
                webCaseList=webCaseService.GetWebCaseListByPeopleID(peopleID);
            }
            ViewBag.WebCases = webCaseList;

            //设计师职位
            List<WebLookup> commonPeoplePosition = commonService.GetLookupList("people_position");
            IEnumerable<SelectListItem> PeoplePositionList = commonPeoplePosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.PeoplePositionList = PeoplePositionList;
            //工人职位
            List<WebLookup> commonworkPosition = commonService.GetLookupList("People_workers_position");
            IEnumerable<SelectListItem> workPositionList = commonworkPosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.workPositionList = workPositionList;

            //工作年限
            List<WebLookup> workyearlist = commonService.GetLookupList("people_workyear");
            IEnumerable<SelectListItem> workyearslist = workyearlist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.workyearslist = workyearslist;

            //省份
            IEnumerable<SelectListItem> provinceList = null;
            List<t_Province> common = areaService.GetProvinceList();
            provinceList = common.Select(com => new SelectListItem { Value = com.provinceID.ToString(), Text = com.province });
            ViewBag.provinceList = provinceList;
            //设计造价
            List<WebLookup> PriceIDl = commonService.GetLookupList("People_Dec_price");
            IEnumerable<SelectListItem> PriceIDlist = PriceIDl.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.PriceIDlist = PriceIDlist;
            return View(people);
        }
        //提交添加人物表单
        [HttpPost]
        public ActionResult AddOrEditWebPeople(WebPeople webPeople)
        {
            int result = 0;
            WebCompany company = webCompanyService.GetWebCompanyByID(webPeople.CompanyID);
            if (company != null)
            {
                webPeople.CompanyName = company.CompanyName;
            }
            if (webPeople != null && webPeople.PeopleID > 0)
            {
                result = webPeopleService.UpdateWebPeople(webPeople);
            }
            else
            {
                result = webPeopleService.AddWebPeople(webPeople);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteWebPeople(int peopleID)
        {
            int result = webPeopleService.DeleteWebPeople(peopleID);
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Case management
        IWebCase webCaseService = new WebCaseService();
        IWebCommon commonService = new WebCommonService();

        [HttpGet]
        public ActionResult WebCaseList()
        {
            List<WebCase> webCaseList = null;
            if (SiteHelper.IsSuperVisor())
            {
                webCaseList = webCaseService.GetWebCaseList();
            }
            else
            {
                webCaseList = webCaseService.GetWebCaseListByCompanyID((int)SessionHelper.GetSession("companyID"));
            }
            ViewBag.WebCaseList = webCaseList;
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEditWebCase(int caseID)
        {
            int CompanyID = Convert.ToInt32(Request["CompanyID"] == null || Request["CompanyID"] == "" ? "0" : Request["CompanyID"]);
            int PeopleID = Convert.ToInt32(Request["peopleID"] == null || Request["peopleID"] == "" ? "0" : Request["peopleID"]);
            WebCase webCase = webCaseService.GetWebCaseByID(caseID);
            if (webCase == null)
            {
                webCase = new WebCase();
            }
            IEnumerable<SelectListItem> companys = null;
            List<WebPeople> peopleList = null;
            if (SiteHelper.IsSuperVisor() && CompanyID == 0)
            {
                //总直接添加或修改
                List<WebCompany> companyList = webCompanyService.GetWebCompanyList();
                companyList.Add(new WebCompany {
                    CompanyID=0,
                    CompanyName="无装修公司"
                });
                companys = companyList.Select(com => new SelectListItem { Value = com.CompanyID.ToString(), Text = com.CompanyName });

                peopleList = webPeopleService.GetWebPeopleList("");
                peopleList.Add(new WebPeople
                {
                    PeopleID = 0,
                    PeopleName = "无装修人员"
                });
                peopleList = peopleList.OrderBy(c => c.PeopleID).ToList();
            }
            else if (CompanyID > 0)
            {
                //由公司添加或修改
                companys = new List<SelectListItem> { new SelectListItem { Value = CompanyID.ToString(), Text = webCompanyService.GetWebCompanyByID(CompanyID).CompanyName } };
                peopleList = webPeopleService.GetAllWebPeopleListByCompanyAndPeopleCategory("",CompanyID);
            }
            else
            {
                //后台商户登录
                companys = new List<SelectListItem> { new SelectListItem { Value = SessionHelper.GetSession("companyID").ToString(), Text = SessionHelper.GetSession("companyName").ToString() } };
                peopleList = webPeopleService.GetAllWebPeopleListByCompanyAndPeopleCategory("",(int)SessionHelper.GetSession("companyID"));

            }
            IEnumerable<SelectListItem> peoples = peopleList.Select(peo => new SelectListItem { Value = peo.PeopleID.ToString(), Text = peo.PeopleName });
            if (PeopleID != 0)
            {
                companys = new List<SelectListItem> { new SelectListItem { Value = webPeopleService.GetWebPeopleByID(PeopleID).CompanyID.ToString(), Text = webPeopleService.GetWebPeopleByID(PeopleID).CompanyName } };
                peoples = new List<SelectListItem> { new SelectListItem { Value = PeopleID.ToString(), Text = webPeopleService.GetWebPeopleByID(PeopleID).PeopleName } };
            }
            ViewBag.Companys = companys.ToList();


            ViewBag.Peoples = peoples.ToList();



            IEnumerable<SelectListItem> CostAreaList = null;
            List<WebLookup> commonCostArea = commonService.GetLookupList("Case_cost_area");
            CostAreaList = commonCostArea.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });

            List<WebLookup> commonStyle = commonService.GetLookupList("Case_style");
            IEnumerable<SelectListItem> StyleList = commonStyle.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });

            List<WebLookup> commonHouseType = commonService.GetLookupList("Case_house_type");
            IEnumerable<SelectListItem> HouseTypeList = commonHouseType.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });

            List<WebLookup> commonHouseArea = commonService.GetLookupList("Case_house_area");
            IEnumerable<SelectListItem> HouseAreaList = commonHouseArea.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });


            List<WebLookup> commonDectype = commonService.GetLookupList("Case_DecType");
            IEnumerable<SelectListItem> DectypeaList = commonDectype.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });

            List<WebLookup> commonGzStyle = commonService.GetLookupList("Case_gz_style");
            IEnumerable<SelectListItem> GzStyleList = commonGzStyle.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.GzStyleList = GzStyleList;
            ViewBag.DectypeaList = DectypeaList;
            ViewBag.CostAreaList = CostAreaList;
            ViewBag.StyleList = StyleList;
            ViewBag.HouseTypeList = HouseTypeList;
            ViewBag.HouseAreaList = HouseAreaList;
            return View(webCase);
        }

        //根据CompanyID返回PeopleList供Ajax调用
        public JsonResult GetPeopleListByCompany(int CompanyID)
        {
            List<WebPeople> peopleList= webPeopleService.GetAllWebPeopleListByCompanyAndPeopleCategory("", CompanyID);
            return Json(new { RetCode = peopleList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddOrEditWebCase(WebCase webCase)
        {
            int result = 0;
            if (webCase != null && webCase.CaseID > 0)
            {
                result = webCaseService.UpdateWebCase(webCase);
            }
            else
            {
                result = webCaseService.AddWebCase(webCase);
            }
            return Json(new { RetCode = result });
        }

        [HttpPost]
        public JsonResult DeleteWebCase(int caseID)
        {
            int result = webCaseService.DeleteWebCase(caseID);
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}

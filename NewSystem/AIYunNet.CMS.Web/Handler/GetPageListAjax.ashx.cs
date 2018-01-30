using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Handler
{
    /// <summary>
    /// GetPageListAjax 的摘要说明
    /// </summary>
    public class GetPageListAjax : IHttpHandler
    {
        HttpContext context = null;
        Z_CommentService ZCommentservice = new Z_CommentService();
        WebPeopleService webPeopleService = new WebPeopleService();
        WebCompanyService webCompanyService = new WebCompanyService();
        WebCaseService webCaseService = new WebCaseService();
        DownLoadService Dser = new DownLoadService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            this.context = context;
            string methodName = context.Request["methodname"];
            System.Reflection.MethodInfo method = this.GetType().GetMethod(methodName);
            method.Invoke(this, null);
        }
        /// <summary>
        /// 获取下载文件
        /// </summary>
        public void GetDecDownLoadList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string LookupCode = context.Request["LookupCode"];
            string firstID = context.Request["firstID"];
            string secondID = context.Request["secondID"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            string title = Dser.GetDownloadtitle(Convert.ToInt32(LookupCode), Convert.ToInt32(firstID), Convert.ToInt32(secondID));
            string SelectParameters = string.Format("[ID],[title],[Size],[LookupCode],[firstID],[secondID],[score]"
             + ",[Info],[DownLoadImage],[thumbnailImage],[upbody],[userid],[usertype],[AddOn],[EditOn],[DeleteOn],[IsDelete],[fileurl],[DownloadCount],[form]");

            SortParameters = string.Format(" IsDelete=0 {0} {1} {2} ",
                LookupCode == "0" || string.IsNullOrEmpty(LookupCode) ? "" : "and LookupCode=" + LookupCode,
                 firstID == "0" || string.IsNullOrEmpty(firstID) ? "" : "and firstID=" + firstID,
                secondID == "0" || string.IsNullOrEmpty(secondID) ? "" : "and secondID=" + secondID);

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "DownLoad";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " DownloadCount desc,ID desc";
            var result = PageList.GetPageListBySQL<DownLoad>(paginfo, out recordcount, out pageCount);

            var obj = new
            {
                list = result,
                title= title+"("+ recordcount+")",
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 获取公司分页
        /// </summary>
        public void GetDecBuidingList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string mkjcitycode = context.Request["mkjcitycode"];
            string WorkerCategory = context.Request["WorkerCategory"];
            string AreasID = context.Request["AreasID"];
            string CompanyID= context.Request["CompanyID"];
            string WorkerID = context.Request["WorkerID"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;

            string SelectParameters = string.Format("[BuidingID],[BuidingTitle],[BuidingBrief],[BuidingInfo],[CompanyID],[WorkerID]"
                     +",[thumbnailImage],[BuidingImage],[ShowOrder],[AddOn],[EditOn],[DeleteOn],[FlagDelete],[PageViewCount]"
                     + ",[CollectCount],[ZanCount],[CommentCount],[IsHot],[IsTop],[Price],[Space],[constructionstageID]"
                     +",[constructionstage],[ResultID],[StartTime],[StageNow],[EndTime],[superviseName]");

            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} ",
                CompanyID == "0" || string.IsNullOrEmpty(CompanyID) ? "" : "and CompanyID="+ CompanyID,
                WorkerID == "0" || string.IsNullOrEmpty(WorkerID) ? "" : "and WorkerID=" + WorkerID,
                AreasID == "0" || string.IsNullOrEmpty(AreasID) ? "" : "and (AreasID='0' or AreasID like '%" + AreasID + "%')");

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebBuiding";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " ShowOrder desc,BuidingID desc";
            var result = PageList.GetPageListBySQL<WebBuiding>(paginfo, out recordcount, out pageCount);

            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }



        /// <summary>
        /// 获取worker分页
        /// </summary>
        public void GetDecWorkList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string mkjcitycode = context.Request["mkjcitycode"];
            string WorkerCategory= context.Request["WorkerCategory"];
            string positionID = context.Request["positionID"];
            string AreasID = context.Request["AreasID"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;

            string SelectParameters = string.Format("[WorkerID],[WorkerName],[WorkerCategory],[WorkerPhone],[WorkerMail],[Address]"
                +",[WorkerInfo],[WorkerLevel],[WorkerMotto],[IsBond],[BondMoney],[IsAuthentication],[IsHot],[IsTop],[ShowOrder]"
                +",[WorkerImage],[thumbnailImage],[AddOn],[EditOn],[DeleteOn],[FlagDelete],[ProvinceID],[ProvinceName],[CityID]"
                +",[CityName],[AreasID],[AreasName],[UserID],[PriceID],[PriceName],[WorkYearsID],[WorkYears],[WorkerPositionID]"
                +",[WorkerPosition],[GoodAtStyleID],[GoodAtStyle],[PageViewCount],[CollectCount],[CommentCount],[BuildingCount]"
                +",[IsBuildingCount],[IsApproved]");

            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} {3}",
                "and CityID='" + mkjcitycode + "'",
                 positionID == "0" || string.IsNullOrEmpty(positionID) ? "" : "and WorkerPositionID='" + positionID + "'",
                AreasID == "0" || string.IsNullOrEmpty(AreasID) ? "" : "and (AreasID='0' or AreasID like '%" + AreasID + "%')",
                "and WorkerCategory='"+ WorkerCategory+"'");

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebWorker";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " ShowOrder desc,WorkerID desc";
            var result = PageList.GetPageListBySQL<WebWorker>(paginfo, out recordcount, out pageCount);
            List<WorkerAndBuidingList> list = new List<WorkerAndBuidingList>();
            WebBuidingService sercive = new WebBuidingService();
            var obj = new Object();
            if (WorkerCategory == "装修工长")
            {
                foreach (var item in result)
                {
                    WorkerAndBuidingList eq = new WorkerAndBuidingList();
                    eq.worker = item;
                    eq.biuding = sercive.GetWebBuidingListByCount(item.WorkerID, 3);
                    list.Add(eq);
                }
                obj = new
                {
                    list = list,
                    recordcount = recordcount,
                    pageCount = pageCount
                };
            }
            else
            {
                obj = new
                {
                    list = result,
                    recordcount = recordcount,
                    pageCount = pageCount
                };
            }


            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }


        /// <summary>
        /// 获取公司分页
        /// </summary>
        public void GetDecCompanyList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string mkjcitycode = context.Request["mkjcitycode"];
            string AreasID= context.Request["AreasID"];
            string Typelist = context.Request["Typelist"];
            string Stylelist = context.Request["Stylelist"];
            string Pricelist = context.Request["Pricelist"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;

            string SelectParameters = string.Format("[CompanyID],[CompanyName],[CompanyPeople],[CompanyPhone],[CompanyMoble],[CompanyMail],"
                +"[CompanyAddress],[CompanyNet],[CompanyInfo],[CaseCount],[InBuildingCount],[IsBond],[IsAuthentication],"
                +"[IsPreferentialActivity],[IsFamousEnterprise],[IsApproved],[IsTop],[ForwardNetAddress],[BelongArea],"
                +"[ShowOrder],[CompanyImage],[thumbnailImage],[AddOn],[EditOn],[DeleteOn],[FlagDelete],[CityID],[CityName],"
                +"[AreasID],[AreasName],[GoodAtStyleID],[GoodAtStyle],[CompanySize],[CompanyLicence],[Certification],[Honor],"
                +"[CompanyType],[RegistAddress],[RegistMoney],[CompanyAddOn],[RegistAuthority],[BusinessScope],"
                +"[RegistMark],[RepresentPerson],[WebCompanyUserID],[PageViewCount],[CollectCount],[GoodAtTypeID],"
                +"[GoodAtType],[PriceID],[PriceName],[CommentCount]");

            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} {3} {4}",
                Typelist == "0" || string.IsNullOrEmpty(Typelist) ? "" : "and (GoodAtTypeID='0' or GoodAtTypeID like '%" + Typelist + "%')",
                Stylelist == "0" || string.IsNullOrEmpty(Stylelist) ? "" : "and (GoodAtStyleID='0' or GoodAtStyleID like '%" + Stylelist + "%')",
                Pricelist == "0" || string.IsNullOrEmpty(Pricelist) ? "" : "and (PriceID='0' or PriceID like '%" + Pricelist + "%')",
                "and CityID='"+ mkjcitycode + "'",
                AreasID == "0"|| string.IsNullOrEmpty(AreasID)?"": "and (AreasID='0' or AreasID like '%" + AreasID + "%')");

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebCompany";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " ShowOrder desc,CompanyID desc";
            var result = PageList.GetPageListBySQL<WebCompanyPage>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 获取设计师分页
        /// </summary>
        public void GetDecDesignerList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string mkjcitycode = context.Request["mkjcitycode"];
            string AreasID = context.Request["AreasID"];
            string goodatid = context.Request["goodatid"];
            string peoplepositionid = context.Request["peoplepositionid"];
            string PeopleCategory = context.Request["PeopleCategory"];
            string workyearid = context.Request["workyearid"];
            string companyID = context.Request["companyID"];
            string SortOrder = context.Request["SortOrder"];
            string PriceID= context.Request["PriceID"];
            string SortParameters = "";
            string SelectParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SelectParameters = string.Format("[PeopleID],[PeopleName],[PeopleCategory],[PeoplePositionID],"
                + "(select description from WebLookup where code=WebPeople.PeoplePositionID and lookup_key='people_position') as [PeoplePosition],"
                + "(select description from WebLookup where code=WebPeople.PriceID and lookup_key='People_Dec_price') as [PriceName],"
                + "[PeoplePhone],[PeopleMail],[Address],[WorkYears],[WorkYearsID],[PeopleInfo],[PeopleLevel],[GoodAtStyleID],"
                + "[GoodAtStyle],[PeopleMotto],[CaseCount],[IsBuildingCount],[IsBond],[IsAuthentication],[IsApproved],"
                + "[IsTop],[BelongArea],[ShowOrder],[PeopleImage],[DesignerImage],[thumbnailImage],[CompanyID],[CompanyName],"
                + "[AddOn],[EditOn],[DeleteOn],[FlagDelete],[CityID],[CityName],[AreasID],[AreasName],[UserID],[PageViewCount],[CollectCount],[PriceID],ProvinceID,ProvinceName");
            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} {3} {4} {5} {6} {7}", string.IsNullOrEmpty(PeopleCategory) ? "" : "and PeopleCategory like '%" + PeopleCategory + "%'",
                goodatid == "0" || string.IsNullOrEmpty(goodatid) ? "" : "and GoodAtStyleID like '%" + goodatid + "%'",
                AreasID == "0" || string.IsNullOrEmpty(AreasID) ? "" : "and (AreasID='0' or AreasID like '%" + AreasID + "%')",
                peoplepositionid == "0" || string.IsNullOrEmpty(peoplepositionid) ? "" : "and PeoplePositionID like '%" + peoplepositionid + "%'",
                workyearid == "0" || string.IsNullOrEmpty(workyearid) ? "" : "and WorkYearsID =" + Convert.ToInt32(workyearid),
                companyID == "0" || string.IsNullOrEmpty(companyID) ? "and companyID='0'" : "and companyID =" + Convert.ToInt32(companyID),
                PriceID == "0" || string.IsNullOrEmpty(PriceID) ? "" : "and PriceID =" + Convert.ToInt32(PriceID),
                "and CityID='" + mkjcitycode + "'");

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebPeople";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " ShowOrder desc,PeopleID desc";
            var result = PageList.GetPageListBySQL<WebPeoplePage>(paginfo, out recordcount, out pageCount);
            foreach (var item in result)
            {
                List<WebCase> list = webCaseService.GetWebCaseListByPeopleIDAndCount(item.PeopleID, 4);
                item.caselist = list;
            }

            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 获取图库分页
        /// </summary>
        public void GetDecImgList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int DecType= string.IsNullOrEmpty(context.Request["DecType"]) ? 1 : Convert.ToInt32(context.Request["DecType"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string ImgJzspce = context.Request["ImgJzspce"];
            string ImgGzspace = context.Request["ImgGzspace"];
            string ImgJzstyle = context.Request["ImgJzstyle"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            string SelectParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SelectParameters = string.Format("PictureID,PictureName,PictureImg,WebPicture.thumbnailImage as thumbnailImage,WebImg.ImgGzspace as ImgGzspace,WebImg.ImgJzspce as ImgJzspce,WebImg.ImgJzstyle as ImgJzstyle,WebImg.DecType as DecType");
            SortParameters = string.Format(" WebPicture.FlagDelete=0 {0} {1} {2} {3}",
                ImgJzspce == "0" || string.IsNullOrEmpty(ImgJzspce) ? "" : "and ImgJzspce =" + Convert.ToInt32(ImgJzspce),
                ImgGzspace == "0" || string.IsNullOrEmpty(ImgGzspace) ? "" : "and ImgGzspace =" + Convert.ToInt32(ImgGzspace),
                ImgJzstyle == "0" || string.IsNullOrEmpty(ImgJzstyle) ? "" : "and ImgJzstyle =" + Convert.ToInt32(ImgJzstyle),
                "and DecType =" + Convert.ToInt32(DecType));

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.SelectParameters = SelectParameters;
            paginfo.EntityName = "WebPicture INNER JOIN WebImg on WebPicture.WebImgID=WebImg.ImgId";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + "PictureID desc";
            var result = PageList.GetPageListBySQL<WebPicturesPage>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }
        /// <summary>
        /// 获取案例分页
        /// </summary>
        public void GetDecCaseList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            int companyID = string.IsNullOrEmpty(context.Request["companyID"]) ? 0 : Convert.ToInt32(context.Request["companyID"]);
            int peopleID = string.IsNullOrEmpty(context.Request["peopleID"]) ? 0 : Convert.ToInt32(context.Request["peopleID"]);
            int style = Convert.ToInt32(context.Request["styleid"]);
            int housetype = Convert.ToInt32(context.Request["housetypeid"]);
            int costarea = Convert.ToInt32(context.Request["costareaid"]);
            int housearea = Convert.ToInt32(context.Request["houseareaid"]);
            int gzstyleid= Convert.ToInt32(context.Request["gzstyleid"]);
            int DecType = string.IsNullOrEmpty(context.Request["DecType"]) ? 0 : Convert.ToInt32(context.Request["DecType"]);
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            string SelectParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SelectParameters = string.Format("[CaseID],[CaseTitle],[CaseBrief],[CaseInfo],[CompanyID],[PeopleID],[thumbnailImage],[CaseImageBig],[IsTop],[ShowOrder],[DecType]," +
                "(select description from WebLookup where code=WebCase.Style and lookup_key='Case_style') as [StyleName]," +
                "(select description from WebLookup where code=WebCase.HouseType and lookup_key='Case_house_type') as [HouseTypeName]," +
                "(select description from WebLookup where code=WebCase.HouseArea and lookup_key='Case_house_area') as [HouseAreaName]," +
                "(select description from WebLookup where code=WebCase.CostArea and lookup_key='Case_cost_area') as [CostAreaName]," +
                "(select description from WebLookup where code=WebCase.GzStyle and lookup_key='Case_gz_style') as [GzStyleName]," +
                "[PageViewCount],[CollectCount],[ZanCount],[CommentCount],[AddOn]");
            //SelectParameters = string.Format("[PeopleID],[PeopleName],[PeopleCategory],[PeoplePositionID],[PeoplePosition],[PeoplePhone],[PeopleMail],[Address],[WorkYears],[WorkYearsID],[PeopleInfo],[PeopleLevel],[GoodAtStyleID],[GoodAtStyle],[PeopleMotto],[CaseCount],[IsBuildingCount],[IsBond],[IsAuthentication],[IsApproved],[IsTop],[BelongArea],[ShowOrder],[PeopleImage] ,[DesignerImage],[thumbnailImage],[CompanyID],[CompanyName],[AddOn],[EditOn],[DeleteOn],[FlagDelete],[CityID],[CityName],[AreasID],[AreasName]");
            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} {3} {4} {5} {6} {7}",
                companyID == 0 ? "" : "and companyID=" + companyID,
                style == 0 ? "" : "and style=" + style,
                housetype == 0 ? "" : "and housetype=" + housetype,
                costarea == 0 ? "" : "and costarea=" + costarea,
                housearea == 0 ? "" : "and housearea=" + housearea,
                gzstyleid == 0 ? "": "and GzStyle=" + gzstyleid,
                DecType == 0 ? "" : "and DecType=" + DecType,
                peopleID == 0 ? "" : "and PeopleID=" + peopleID);

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebCase";
            paginfo.SelectParameters = SelectParameters;
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + "AddOn desc,CaseID desc";
            var result = PageList.GetPageListBySQL<WebCasePage>(paginfo, out recordcount, out pageCount);
            List<WebCaseAndDesigner> list = new List<WebCaseAndDesigner>();
            foreach (WebCasePage item in result)
            {
                WebCaseAndDesigner cadec = new WebCaseAndDesigner();
                cadec.webcase = item;
                if (item.PeopleID == 0)
                {
                    cadec.designer = new WebPeople();
                }
                else
                {
                    cadec.designer = webPeopleService.GetWebPeopleByID(item.PeopleID);
                }
                if (item.CompanyID == 0)
                {
                    cadec.company = new WebCompany();
                }
                else
                {
                    cadec.company = webCompanyService.GetWebCompanyByID(item.CompanyID);
                }
                list.Add(cadec);

            }

            var obj = new
            {
                list = list,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 获取案例分页
        /// </summary>
        public void GetCaseList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            int companyID = string.IsNullOrEmpty(context.Request["companyID"]) ? 0 : Convert.ToInt32(context.Request["companyID"]);
            int peopleID = string.IsNullOrEmpty(context.Request["peopleID"]) ? 0 : Convert.ToInt32(context.Request["peopleID"]); 
            int style = Convert.ToInt32(context.Request["styleid"]);
            int housetype = Convert.ToInt32(context.Request["housetypeid"]);
            int costarea = Convert.ToInt32(context.Request["costareaid"]);
            int housearea = Convert.ToInt32(context.Request["houseareaid"]);
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            string SelectParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SelectParameters = string.Format("[CaseID],[CaseTitle],[CaseBrief],[CaseInfo],[CompanyID],[PeopleID],[thumbnailImage],[CaseImageBig],[IsTop],[ShowOrder],[CostArea],"+
                "(select description from WebLookup where code=WebCase.Style and lookup_key='Case_style') as [StyleName],"+
                "(select description from WebLookup where code=WebCase.HouseType and lookup_key='Case_house_type') as [HouseTypeName],"+
                "(select description from WebLookup where code=WebCase.HouseArea and lookup_key='Case_house_type') as [HouseAreaName]," +
                "(select description from WebLookup where code=WebCase.CostArea and lookup_key='Case_house_area') as [CostAreaName]," +
                "[Style],[HouseType],[HouseArea],[AddOn],[EditOn],[DeleteOn],[FlagDelete],[PageViewCount],[CollectCount],[ZanCount],[CommentCount]");
            //SelectParameters = string.Format("[PeopleID],[PeopleName],[PeopleCategory],[PeoplePositionID],[PeoplePosition],[PeoplePhone],[PeopleMail],[Address],[WorkYears],[WorkYearsID],[PeopleInfo],[PeopleLevel],[GoodAtStyleID],[GoodAtStyle],[PeopleMotto],[CaseCount],[IsBuildingCount],[IsBond],[IsAuthentication],[IsApproved],[IsTop],[BelongArea],[ShowOrder],[PeopleImage] ,[DesignerImage],[thumbnailImage],[CompanyID],[CompanyName],[AddOn],[EditOn],[DeleteOn],[FlagDelete],[CityID],[CityName],[AreasID],[AreasName]");
            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} {3} {4} {5}", 
                companyID == 0 ? "" : "and companyID=" + companyID, 
                style == 0 ? "" : "and style=" + style,
                housetype == 0 ? "" : "and housetype=" + housetype, 
                costarea == 0 ? "" : "and costarea=" + costarea,
                housearea == 0 ? "" : "and housearea=" + housearea,
                peopleID==0? "" : "and PeopleID=" + peopleID);

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebCase";
            paginfo.SelectParameters = SelectParameters;
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder+"AddOn desc,CaseID desc";
            var result = PageList.GetPageListBySQL<WebCasePage>(paginfo,out recordcount,out pageCount);
            var obj = new
            {
                list = result,
                recordcount= recordcount,
                pageCount= pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 获取人物分页
        /// </summary>
        public void GetPeopleList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string goodatid = context.Request["goodatid"];
            string areasid = context.Request["areasid"];
            string peoplepositionid= context.Request["peoplepositionid"];
            string PeopleCategory = context.Request["PeopleCategory"];
            string workyearid= context.Request["workyearid"];
            string companyID= context.Request["companyID"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            string SelectParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SelectParameters = string.Format("[PeopleID],[PeopleName],[PeopleCategory],[PeoplePositionID]," 
                + "(select description from WebLookup where code=WebPeople.PeoplePositionID and lookup_key='people_position') as [PeoplePosition],"
                + "[PeoplePhone],[PeopleMail],[Address],[WorkYears],[WorkYearsID],[PeopleInfo],[PeopleLevel],[GoodAtStyleID],"
                +"[GoodAtStyle],[PeopleMotto],[CaseCount],[IsBuildingCount],[IsBond],[IsAuthentication],[IsApproved],"
                +"[IsTop],[BelongArea],[ShowOrder],[PeopleImage],[DesignerImage],[thumbnailImage],[CompanyID],[CompanyName],"
                +"[AddOn],[EditOn],[DeleteOn],[FlagDelete],[CityID],[CityName],[AreasID],[AreasName],[UserID],[PageViewCount],[CollectCount]");
            SortParameters = string.Format(" FlagDelete=0 {0} {1} {2} {3} {4} {5}", string.IsNullOrEmpty(PeopleCategory) ? "" : "and PeopleCategory like '%" + PeopleCategory + "%'", 
                goodatid=="0"|| string.IsNullOrEmpty(goodatid) ? "" : "and GoodAtStyleID like '%" + goodatid + "%'",
                areasid=="0" || string.IsNullOrEmpty(areasid) ? "" : "and AreasID like '%" + areasid + "%'",
                peoplepositionid == "0" || string.IsNullOrEmpty(peoplepositionid) ? "" : "and PeoplePositionID like '%" + peoplepositionid + "%'",
                workyearid == "0" || string.IsNullOrEmpty(workyearid) ? "" : "and WorkYearsID =" + Convert.ToInt32(workyearid),
                companyID == "0" || string.IsNullOrEmpty(companyID) ? "" : "and companyID =" + Convert.ToInt32(companyID));

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebPeople";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder+ "ShowOrder desc,PeopleID desc";
            var result = PageList.GetPageListBySQL<WebPeoplePage>(paginfo,out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount= pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 获取图库分页
        /// </summary>
        public void GetImgList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string housestylelist = context.Request["housestylelist"];
            string commercialstylelist = context.Request["commercialstylelist"];
            string designerrstylelist = context.Request["designerrstylelist"];
            string hotalstylelist = context.Request["hotalstylelist"];
            string softcoverstylelist = context.Request["softcoverstylelist"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" FlagDelete=0 and IsPublish=1 {0} {1} {2} {3} {4}",
                housestylelist == "0" || string.IsNullOrEmpty(housestylelist) ? "" : "and housestyle =" + Convert.ToInt32(housestylelist),
                commercialstylelist == "0" || string.IsNullOrEmpty(commercialstylelist) ? "" : "and commercialstyle =" + Convert.ToInt32(commercialstylelist),
                designerrstylelist == "0" || string.IsNullOrEmpty(designerrstylelist) ? "" : "and designerrstyle =" + Convert.ToInt32(designerrstylelist),
                hotalstylelist == "0" || string.IsNullOrEmpty(hotalstylelist) ? "" : "and hotalstyle =" + Convert.ToInt32(hotalstylelist),
                softcoverstylelist == "0" || string.IsNullOrEmpty(softcoverstylelist) ? "" : "and softcoverstyle =" + Convert.ToInt32(softcoverstylelist));

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebImg";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder+"ImgId desc";
            var result = PageList.GetPageListBySQL<WebImg>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }
        /// <summary>
        /// 获取公司分页
        /// </summary>
        public void GetCompanyList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string goodatid = context.Request["goodatid"];
            string areasid = context.Request["areasid"];
            string SortOrder= context.Request["SortOrder"];
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
            paginfo.SortOrder = SortOrder + "ShowOrder desc,CompanyID desc";
            var result = PageList.GetPageListBySQL<WebCompany>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }
        /// <summary>
        /// 获取新闻分页
        /// </summary>
        public void GetNewsList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string classID= context.Request["classID"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            SortParameters = string.Format(" flagdelete=0 {0}",
                classID == "0" || string.IsNullOrEmpty(classID) ? "" : "and ClassID =" + Convert.ToInt32(classID));

            Pagination paginfo = new Pagination();
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebNews";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = "PageViewCount desc, ContentID desc";
            var result = PageList.GetPageListBySQL<WebNews>(paginfo, out recordcount, out pageCount);
            var obj = new
            {
                list = result,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 论坛互动分页
        /// </summary>
        public void GetCommentList()
        {
            List<PeopleComments> listComment = new List<PeopleComments>();
            int topic_id = Convert.ToInt32(context.Request["topic_id"]);
            string topic_type = context.Request["topic_type"];
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            int pageCount = 0;
            int recordcount = 0;
            var result = PageList.GetPageList<Z_Comment,int>(c => c.topic_type == topic_type && c.topic_id == topic_id, c => c.ZanCount, c => c.addtime, PageSize, pageIndex, out recordcount, out pageCount);
            foreach (var item in result)
            {
                PeopleComments Comment = new PeopleComments();
                Comment.comment = item;
                Comment.reCommentList = ZCommentservice.GetReplyCommentListByID(item.comment_guid);
                listComment.Add(Comment);
            }
            var obj = new
            {
                list = listComment,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebPeopleService : IWebPeople
    {
        WebCaseService webCaseService = new WebCaseService();
        /// <summary>
        /// 人物列表
        /// </summary>
        public List<WebPeople> GetWebPeopleList(string PeopleCategory)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
               return context.WebPeople.Where(p => p.FlagDelete == 0).OrderByDescending(p => p.AddOn).ToList();               
            }
        }

        /// <summary>
        /// 设计师列表
        /// </summary>
        //public List<WebPeople> GetWebDesignerList()
        //{
        //    using (AIYunNetContext context = new AIYunNetContext())
        //    {
        //        return context.WebPeople.Where(p => p.FlagDelete == 0 && p.PeopleCategory == "设计师" ).OrderByDescending(p => p.AddOn).ToList();
        //    }
        //}

        /// <summary>
        /// 根据类型和至首数量获取首页装修人员列表
        /// </summary>
        public List<WebPeople> IndexGetWebPeopleList(string type, int topcount)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Where(p => p.FlagDelete == 0 && p.PeopleCategory == type && p.IsTop == true).OrderByDescending(p => p.AddOn).Take(topcount).ToList();
            }
        }
        /// <summary>
        /// 获取设计师列表页推荐列表
        /// </summary>
        public List<WebPeople> IndexGetWebDesignerList(string cityid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Where(p => p.FlagDelete == 0 && p.IsTop == true && p.CityID== cityid && p.CompanyID==0).OrderByDescending(p => p.AddOn).ToList();
            }
        }
        /// <summary>
        /// 获取首页装修工人列表
        /// </summary>
        public List<WebPeople> IndexGetWebWorkerList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Where(p => p.FlagDelete == 0 && p.PeopleCategory == "装修工人" && p.IsTop == true).OrderByDescending(p => p.AddOn).Take(8).ToList();
            }
        }
        /// <summary>
        /// 获取首页至首装修工长列表
        /// </summary>
        public List<WebPeople> IndexGetWebWorkLeaderList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Where(p => p.FlagDelete == 0 && p.PeopleCategory == "装修工长" && p.IsTop == true).OrderByDescending(p => p.AddOn).Take(12).ToList();
            }
        }
        /// <summary>
        /// 装修公司首页获取置首人物列表
        /// </summary>
        /// <param name="companyID">公司ID</param>
        /// <param name="modelID">公司页面模板ID</param>
        /// <returns></returns>
        public List<WebPeople> IndexGetWebPeopleListByCompanyID(int companyID, int modelID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (modelID == 2)
                {
                    return context.WebPeople.Where(p => p.CompanyID == companyID && p.FlagDelete == 0 && p.IsTop == true && p.PeopleCategory == "设计师").Take(4).OrderByDescending(p => p.AddOn).ToList();
                }
                else
                {
                    return context.WebPeople.Where(p => p.CompanyID == companyID && p.FlagDelete == 0 && p.IsTop == true && p.PeopleCategory == "设计师").Take(4).OrderByDescending(p => p.AddOn).ToList();
                }

            }
        }
        /// <summary>
        /// 通过companyID和类别获取装修人员
        /// </summary>
        public List<WebPeople> GetAllWebPeopleListByCompanyAndPeopleCategory(string PeopleCategory, int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPeople.Where(p => p.CompanyID == companyID && p.FlagDelete == 0).OrderByDescending(p => p.AddOn).ToList();
                
            }
        }
        /// <summary>
        /// 通过companyID和数量获取装修人员
        /// </summary>
        public List<WebPeople> GetWebPeopleListByCompanyIDAndCount(int companyID, int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Where(p => p.CompanyID == companyID && p.FlagDelete == 0).OrderByDescending(p => p.CaseCount).Take(count).ToList();
            }
        }
        /// <summary>
        /// 通过companyID获取人员
        /// </summary>
        public List<WebPeople> GetWebPeopleListByCompanyID(int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Where(p => p.FlagDelete == 0 && p.CompanyID == companyID).OrderByDescending(p => p.AddOn).ToList();
            }
        }
        /// <summary>
        /// 通过ID获取单个人员
        /// </summary>
        public WebPeople GetWebPeopleByID(int peopleID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.Find(peopleID);
            }
        }
        /// <summary>
        /// 通过UserID获取单个人员
        /// </summary>
        public WebPeople GetWebPeopleByUserID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeople.FirstOrDefault(c=>c.UserID== userID);
            }
        }

        public int AddWebPeople(WebPeople webPeople)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebPeople.Add(webPeople);
                context.SaveChanges();
                return 1;
            }
        }
        public int UpdateWebPeople(WebPeople webPeople)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webPeople != null)
                {
                    WebPeople originalPeople = context.WebPeople.Find(webPeople.PeopleID);
                    WebCompany company = context.WebCompany.Find(webPeople.CompanyID);
                    WebCommonService weblookupservice = new WebCommonService();
                    if (originalPeople != null)
                    {
                        originalPeople.Address = webPeople.Address;
                        originalPeople.BelongArea = webPeople.BelongArea;
                        originalPeople.CaseCount = webPeople.CaseCount;
                        if (webPeople.CompanyID == 0)
                        {
                            originalPeople.CompanyID = 0;
                            originalPeople.CompanyName = "";
                        }
                        else
                        {
                            originalPeople.CompanyID = webPeople.CompanyID;
                            originalPeople.CompanyName = company.CompanyName;
                        }
                        originalPeople.EditOn = DateTime.Now;
                        originalPeople.GoodAtStyleID = webPeople.GoodAtStyleID;
                        originalPeople.GoodAtStyle = webPeople.GoodAtStyle;
                        originalPeople.IsApproved = webPeople.IsApproved;
                        originalPeople.IsAuthentication = webPeople.IsAuthentication;
                        originalPeople.IsBond = webPeople.IsBond;
                        originalPeople.IsBuildingCount = webPeople.IsBuildingCount;
                        originalPeople.IsTop = webPeople.IsTop;
                        originalPeople.PeopleCategory = webPeople.PeopleCategory;
                        originalPeople.PeopleInfo = webPeople.PeopleInfo;
                        originalPeople.PeopleLevel = webPeople.PeopleLevel;
                        originalPeople.PeopleMail = webPeople.PeopleMail;
                        originalPeople.PeopleMotto = webPeople.PeopleMotto;
                        originalPeople.PeopleName = webPeople.PeopleName;
                        originalPeople.PeoplePhone = webPeople.PeoplePhone;
                        originalPeople.PeopleImage = webPeople.PeopleImage;
                        originalPeople.DesignerImage = webPeople.DesignerImage == null ? "" : webPeople.DesignerImage;
                        originalPeople.thumbnailImage = webPeople.thumbnailImage == null ? "" : webPeople.thumbnailImage;
                        originalPeople.ShowOrder = webPeople.ShowOrder;
                        originalPeople.WorkYearsID = webPeople.WorkYearsID;
                        originalPeople.WorkYears = weblookupservice.GetLookupDesc("people_workyear", webPeople.WorkYearsID.ToString());

                        originalPeople.PeoplePositionID = webPeople.PeoplePositionID;
                        if (webPeople.PeopleCategory == "设计师")
                        {
                            originalPeople.PeoplePosition = weblookupservice.GetLookupDesc("people_position", webPeople.PeoplePositionID.ToString());
                        }
                        else
                        {
                            originalPeople.PeoplePosition = weblookupservice.GetLookupDesc("People_workers_position", webPeople.PeoplePositionID.ToString());
                        }
                        originalPeople.ProvinceID = webPeople.ProvinceID;
                        originalPeople.ProvinceName = webPeople.ProvinceName;
                        originalPeople.CityID = webPeople.CityID;
                        originalPeople.CityName = webPeople.CityName;
                        originalPeople.AreasID = webPeople.AreasID;
                        originalPeople.AreasName = webPeople.AreasName;
                        originalPeople.PriceID = webPeople.PriceID;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int UpdateWebPeopleByCompanyDes(WebPeople webPeople)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webPeople != null)
                {
                    WebPeople originalPeople = context.WebPeople.Find(webPeople.PeopleID);
                    WebCompany company = context.WebCompany.Find(webPeople.CompanyID);
                    WebCommonService weblookupservice = new WebCommonService();
                    if (originalPeople != null)
                    {
                        originalPeople.Address = webPeople.Address;
                        originalPeople.BelongArea = webPeople.BelongArea;
                        //originalPeople.CaseCount = webPeople.CaseCount;
                        if (webPeople.CompanyID == 0)
                        {
                            originalPeople.CompanyID = 0;
                            originalPeople.CompanyName = "";
                        }
                        else
                        {
                            originalPeople.CompanyID = webPeople.CompanyID;
                            originalPeople.CompanyName = company.CompanyName;
                        }
                        originalPeople.EditOn = DateTime.Now;
                        originalPeople.GoodAtStyle = webPeople.GoodAtStyle;
                        //originalPeople.IsApproved = webPeople.IsApproved;
                        //originalPeople.IsAuthentication = webPeople.IsAuthentication;
                        //originalPeople.IsBond = webPeople.IsBond;
                        //originalPeople.IsBuildingCount = webPeople.IsBuildingCount;
                        //originalPeople.IsTop = webPeople.IsTop;
                        originalPeople.PeopleCategory = webPeople.PeopleCategory;
                        originalPeople.PeopleInfo = webPeople.PeopleInfo;
                        originalPeople.PeopleLevel = webPeople.PeopleLevel;
                        originalPeople.PeopleMail = webPeople.PeopleMail;
                        originalPeople.PeopleMotto = webPeople.PeopleMotto;
                        originalPeople.PeopleName = webPeople.PeopleName;
                        originalPeople.PeoplePhone = webPeople.PeoplePhone;
                        originalPeople.PeopleImage = webPeople.PeopleImage;
                        originalPeople.DesignerImage = webPeople.DesignerImage == null ? "" : webPeople.DesignerImage;
                        originalPeople.thumbnailImage = webPeople.thumbnailImage == null ? "" : webPeople.thumbnailImage;
                        //originalPeople.ShowOrder = webPeople.ShowOrder;
                        originalPeople.WorkYearsID = webPeople.WorkYearsID;
                        originalPeople.WorkYears = weblookupservice.GetLookupDesc("people_workyear", webPeople.WorkYearsID.ToString());

                        originalPeople.PeoplePositionID = webPeople.PeoplePositionID;
                        if (webPeople.PeopleCategory == "设计师")
                        {
                            originalPeople.PeoplePosition = weblookupservice.GetLookupDesc("people_position", webPeople.PeoplePositionID.ToString());
                        }
                        else
                        {
                            originalPeople.PeoplePosition = weblookupservice.GetLookupDesc("People_workers_position", webPeople.PeoplePositionID.ToString());
                        }
                        originalPeople.GoodAtStyleID = webPeople.GoodAtStyleID;
                        originalPeople.GoodAtStyle = webPeople.GoodAtStyle;
                        //originalPeople.PriceID = webPeople.PriceID;

                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public bool IsHaveuser(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPeople WebPeople = context.WebPeople.FirstOrDefault(us => us.UserID == userID);
                return WebPeople != null ? true : false;
            }
        }
        public int DeleteWebPeople(int peopleID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPeople webPeople = context.WebPeople.Find(peopleID);
                if (webPeople != null)
                {
                    webPeople.FlagDelete = 1;
                    webPeople.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        //从个人中心修改
        public int UpdateWebPeopleFromCenter(WebPeople webPeople)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webPeople != null)
                {
                    WebPeople originalPeople = context.WebPeople.Find(webPeople.PeopleID);
                    WebCompany company = context.WebCompany.Find(webPeople.CompanyID);
                    if (originalPeople != null)
                    {
                        //originalPeople.Address = webPeople.Address;
                        //originalPeople.BelongArea = webPeople.BelongArea;
                        //originalPeople.CaseCount = webPeople.CaseCount;
                        if (webPeople.CompanyID == 0)
                        {
                            originalPeople.CompanyID = 0;
                            originalPeople.CompanyName = "";
                        }
                        else
                        {
                            originalPeople.CompanyID = webPeople.CompanyID;
                            originalPeople.CompanyName = company.CompanyName;
                        }
                        originalPeople.EditOn = DateTime.Now;
                        //originalPeople.GoodAtStyle = webPeople.GoodAtStyle;
                        //originalPeople.IsApproved = webPeople.IsApproved;
                        //originalPeople.IsAuthentication = webPeople.IsAuthentication;
                        //originalPeople.IsBond = webPeople.IsBond;
                        //originalPeople.IsBuildingCount = webPeople.IsBuildingCount;
                        //originalPeople.IsTop = webPeople.IsTop;
                        originalPeople.PeopleCategory = webPeople.PeopleCategory;
                        //originalPeople.PeopleInfo = webPeople.PeopleInfo;
                        //originalPeople.PeopleLevel = webPeople.PeopleLevel;
                        originalPeople.PeopleMail = webPeople.PeopleMail;
                        //originalPeople.PeopleMotto = webPeople.PeopleMotto;
                        originalPeople.PeopleName = webPeople.PeopleName;
                        originalPeople.PeoplePhone = webPeople.PeoplePhone;
                        originalPeople.PeopleImage = webPeople.PeopleImage;
                        //originalPeople.DesignerImage = webPeople.DesignerImage == null ? "" : webPeople.DesignerImage;
                        originalPeople.thumbnailImage = webPeople.thumbnailImage == null ? "" : webPeople.thumbnailImage;
                        originalPeople.ProvinceID = webPeople.ProvinceID;
                        originalPeople.ProvinceName = webPeople.ProvinceName;
                        originalPeople.CityID = webPeople.CityID;
                        originalPeople.CityName = webPeople.CityName;
                        originalPeople.AreasID = webPeople.AreasID;
                        originalPeople.AreasName = webPeople.AreasName;
                        //originalPeople.ShowOrder = webPeople.ShowOrder;
                        //originalPeople.WorkYears = webPeople.WorkYears;
                        //originalPeople.PeoplePosition = webPeople.PeoplePosition;

                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }


        //从个人中心详情页面修改
        public int UpdateWebPeopleFromCenterDetail(WebPeople webPeople)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webPeople != null)
                {
                    WebPeople originalPeople = context.WebPeople.Find(webPeople.PeopleID);
                    if (originalPeople != null)
                    {
                        originalPeople.PeoplePositionID = webPeople.PeoplePositionID;
                        originalPeople.PeoplePosition = webPeople.PeoplePosition;
                        originalPeople.WorkYearsID = webPeople.WorkYearsID;
                        originalPeople.WorkYears = webPeople.WorkYears;
                        originalPeople.PriceID = webPeople.PriceID;
                        //originalPeople.BelongArea = webPeople.BelongArea;
                        //originalPeople.CaseCount = webPeople.CaseCount;
                        originalPeople.EditOn = DateTime.Now;
                        originalPeople.GoodAtStyleID = webPeople.GoodAtStyleID;
                        originalPeople.GoodAtStyle = webPeople.GoodAtStyle;
                        //originalPeople.IsApproved = webPeople.IsApproved;
                        //originalPeople.IsAuthentication = webPeople.IsAuthentication;
                        //originalPeople.IsBond = webPeople.IsBond;
                        //originalPeople.IsBuildingCount = webPeople.IsBuildingCount;
                        //originalPeople.IsTop = webPeople.IsTop;
                        originalPeople.PeopleInfo = webPeople.PeopleInfo;
                        //originalPeople.PeopleLevel = webPeople.PeopleLevel;
                        originalPeople.PeopleMotto = webPeople.PeopleMotto;
                        originalPeople.DesignerImage = webPeople.DesignerImage == null ? "" : webPeople.DesignerImage;

                        //originalPeople.ShowOrder = webPeople.ShowOrder;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }



        public void PageViewAdd(int PeopleID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPeople originalWebPeople = context.WebPeople.Find(PeopleID);
                if (originalWebPeople != null)
                {
                    originalWebPeople.PageViewCount = originalWebPeople.PageViewCount + 1;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 根据peopleID修改案例个数
        /// </summary>
        public void updateCaseCountbyPeopleID(int peopleID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPeople originalWebPeople = context.WebPeople.Find(peopleID);
                if (originalWebPeople != null)
                {
                    originalWebPeople.CaseCount = webCaseService.GetCaseCountByPeopleID(peopleID);
                    context.SaveChanges();
                }
            }
        }
    }
}

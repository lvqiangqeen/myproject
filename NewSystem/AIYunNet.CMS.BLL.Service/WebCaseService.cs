using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebCaseService : IWebCase
    {
        /// <summary>
        /// 首页hot案例
        /// </summary>
        public List<WebCase> GetHotWebCaseList(int count,int DecType)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.FlagDelete == 0 && wc.IsHot==true && wc.DecType== DecType).OrderByDescending(wc => wc.AddOn).Take(count).ToList();
            }
        }
        public List<WebCase> GetWebCaseList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.FlagDelete == 0).OrderByDescending(wc => wc.AddOn).ToList();
            }
        }
        /// <summary>
        ///  根据companyID和数量获取推荐案例列表
        /// </summary>
        /// <returns></returns>
        public List<WebCase> GetWebCaseListByCompanyIDAndCount(int companyID,int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.CompanyID == companyID && wc.FlagDelete == 0 && wc.IsTop == true).OrderByDescending(wc => wc.AddOn).Take(count).ToList();
            }
        }

        /// <summary>
        /// 根据peopleID和数量获取案例列表
        /// </summary>
        /// <param name="peopleID">peopleID</param>
        /// <param name="count">count</param>
        /// <returns></returns>
        public List<WebCase> GetWebCaseListByPeopleIDAndCount(int peopleID,int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.PeopleID == peopleID && wc.FlagDelete == 0).OrderByDescending(wc => wc.AddOn).Take(count).ToList();
            }
        }
        /// <summary>
        /// 根据peopleID和数量获取案例列表
        /// </summary>
        /// <param name="peopleID">peopleID</param>
        /// <param name="count">count</param>
        /// <returns></returns>
        public List<WebCase> GetWebCaseListByPeopleIDAndskip(int peopleID, int skip)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.PeopleID == peopleID && wc.FlagDelete == 0).OrderByDescending(wc => wc.AddOn).Skip(skip).ToList();
            }
        }
        /// <summary>
        /// 装修公司首页获取置首案例列表
        /// </summary>
        /// <param name="companyID">公司ID</param>
        /// <param name="modelID">公司页面模板ID</param>
        /// <returns></returns>
        public List<WebCase> IndexGetWebCaseListByCompanyID(int companyID, int modelID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (modelID == 2)
                {
                    return context.WebCase.Where(wc => wc.CompanyID == companyID && wc.FlagDelete == 0 && wc.IsTop == true).Take(4).OrderByDescending(wc => wc.AddOn).ToList();
                }
                else
                {
                    return context.WebCase.Where(wc => wc.CompanyID == companyID && wc.FlagDelete == 0).OrderByDescending(wc => wc.AddOn).ToList();
                }
            }
        }
        public List<WebCase> GetWebCaseListByCompanyID(int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.CompanyID == companyID && wc.FlagDelete == 0).OrderByDescending(wc => wc.AddOn).ToList();
            }
        }

        public List<WebCase> GetWebCaseListByPeopleID(int peopleID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Where(wc => wc.PeopleID == peopleID && wc.FlagDelete == 0).OrderByDescending(wc => wc.AddOn).ToList();
            }
        }

        public WebCase GetWebCaseByID(int caseID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCase.Find(caseID);
            }
        }
        //添加案例同时添加缩略图
        public int AddWebCase(WebCase webCase)
        {
            WebCompanyService comSer = new WebCompanyService();
            WebPeopleService peoSer = new WebPeopleService();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCase.Add(webCase);
                
                string[] list = ImageHelper.GetHvtImgUrls(webCase.CaseInfo);
                foreach (var item in list)
                {
                    string thum = ImageHelper.GetthumImgByUrl(item);
                    WebCaseImg img = new WebCaseImg
                    {
                        CompanyID = webCase.CompanyID,
                        CompanyName= webCase.CompanyID==0?"":comSer.GetWebCompanyByID(webCase.CompanyID).CompanyName,
                        PeopleID = webCase.PeopleID,
                        PeopleName= webCase.PeopleID==0?"":peoSer.GetWebPeopleByID(webCase.PeopleID).PeopleName,
                        imgName = webCase.CaseTitle,
                        Img= item,
                        thumbnailImage = thum,
                        WebCaseID= webCase.CaseID,
                        DecType= webCase.DecType,
                        GzStyle= webCase.GzStyle,
                        JzStyle=webCase.Style
                    };
                    context.WebCaseImg.Add(img);
                }
                context.SaveChanges();
                return 1;
            }
        }
        //从总后台修改
        public int UpdateWebCase(WebCase webCase)
        {
            using (AIYunNetContext context=new AIYunNetContext())
            {
                WebCase originalCase = context.WebCase.Find(webCase.CaseID);
                if(originalCase!=null)
                {
                    originalCase.CaseBrief = webCase.CaseBrief;
                    originalCase.CaseImageBig = webCase.CaseImageBig;
                    originalCase.thumbnailImage = webCase.thumbnailImage;
                    originalCase.CaseInfo = webCase.CaseInfo;
                    originalCase.CaseTitle = webCase.CaseTitle;
                    originalCase.CompanyID = webCase.CompanyID;
                    originalCase.IsHot = webCase.IsHot;
                    originalCase.PeopleID = webCase.PeopleID;
                    originalCase.ShowOrder = webCase.ShowOrder;
                    originalCase.CostArea = webCase.CostArea;
                    originalCase.Style = webCase.Style;
                    originalCase.HouseType = webCase.HouseType;
                    originalCase.HouseArea = webCase.HouseArea;
                    originalCase.GzStyle = webCase.GzStyle;
                    originalCase.Jobschedule = webCase.Jobschedule;
                    originalCase.EditOn = DateTime.Now;
                    originalCase.DecType = webCase.DecType;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeleteWebCase(int caseID)
        {
            WebCompanyService webCompanyService = new WebCompanyService();
            WebPeopleService webPeopleService = new WebPeopleService();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCase originalCase = context.WebCase.Find(caseID);
                if (originalCase != null)
                {
                    originalCase.FlagDelete = 1;
                    originalCase.DeleteOn = DateTime.Now;
                    webCompanyService.updateCaseCountbyCompanyID(originalCase.CompanyID);
                    webPeopleService.updateCaseCountbyPeopleID(originalCase.PeopleID);
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AddWebCaseRelationship(WebCaseRelationship webCaseRelationship)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCaseRelationship.Add(webCaseRelationship);
                context.SaveChanges();
                return 1;
            }
        }
        //从公司后台修改
        public int UpdateWebCaseByCompany(WebCase webCase)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCase originalCase = context.WebCase.Find(webCase.CaseID);
                if (originalCase != null)
                {
                    originalCase.CaseBrief = webCase.CaseBrief;
                    originalCase.CaseImageBig = webCase.CaseImageBig;
                    originalCase.thumbnailImage = webCase.thumbnailImage;
                    originalCase.CaseInfo = webCase.CaseInfo;
                    originalCase.CaseTitle = webCase.CaseTitle;
                    originalCase.CompanyID = webCase.CompanyID;  
                    originalCase.IsTop = webCase.IsTop;
                    originalCase.PeopleID = webCase.PeopleID;
                    originalCase.ShowOrder = webCase.ShowOrder;
                    originalCase.CostArea = webCase.CostArea;
                    originalCase.Style = webCase.Style;
                    originalCase.HouseType = webCase.HouseType;
                    originalCase.HouseArea = webCase.HouseArea;
                    originalCase.GzStyle = webCase.GzStyle;
                    originalCase.Jobschedule = webCase.Jobschedule;
                    originalCase.EditOn = DateTime.Now;

                    originalCase.DecType = webCase.DecType;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        //设计师后台修改
        public int UpdateWebCasefromCenter(WebCase webCase)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCase originalCase = context.WebCase.Find(webCase.CaseID);
                if (originalCase != null)
                {
                    originalCase.CaseBrief = webCase.CaseBrief;
                    originalCase.CaseImageBig = webCase.CaseImageBig;
                    originalCase.thumbnailImage = webCase.thumbnailImage;
                    originalCase.CaseInfo = webCase.CaseInfo;
                    originalCase.CaseTitle = webCase.CaseTitle;
                    originalCase.CompanyID = 0;
                    originalCase.IsTop = webCase.IsTop;
                    originalCase.PeopleID = webCase.PeopleID;

                    originalCase.ShowOrder = 0;
                    originalCase.CostArea = webCase.CostArea;
                    originalCase.Style = webCase.Style;
                    originalCase.HouseType = webCase.HouseType;
                    originalCase.HouseArea = webCase.HouseArea;
                    originalCase.GzStyle = webCase.GzStyle;
                    originalCase.Jobschedule = webCase.Jobschedule;
                    originalCase.EditOn = DateTime.Now;
                    originalCase.DecType = webCase.DecType;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 点击量增加
        /// </summary>
        /// <returns></returns>
        public void PageViewAdd(int CaseID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCase originalCase = context.WebCase.Find(CaseID);
                if (originalCase != null)
                {
                    originalCase.PageViewCount = originalCase.PageViewCount + 1;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 根据公司获取案例个数
        /// </summary>
        /// <returns></returns>
        public int GetCaseCountByCompanyId(int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                int Casecount = context.WebCase.Where(c=>c.CompanyID== companyID && c.FlagDelete==0).ToList().Count;
                return Casecount;
            }
        }
        /// <summary>
        /// 根据peopleID获取案例个数
        /// </summary>
        /// <returns></returns>
        public int GetCaseCountByPeopleID(int peopleID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                int Casecount = context.WebCase.Where(c => c.PeopleID == peopleID && c.FlagDelete == 0).ToList().Count;
                return Casecount;
            }
        }
    }
}

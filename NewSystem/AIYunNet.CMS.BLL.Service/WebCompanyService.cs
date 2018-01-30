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
    public class WebCompanyService : IWebCompany
    {
       
        public List<WebCompany> GetWebCompanyList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompany.Where(wc => wc.FlagDelete == 0).ToList();
            }
        }
        /// <summary>
        /// 首页获取置首装修公司列表
        /// </summary>
        public List<WebCompany> IndexGetWebCompanyList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompany.Where(wc => wc.FlagDelete == 0 && wc.IsTop == true).Take(15).ToList();
            }
        }
        //public List<WebCompany> GetWebCompanyListByID(int companyID)
        //{
        //    using (AIYunNetContext context = new AIYunNetContext())
        //    {
        //        return context.WebCompany.Where(wc => wc.CompanyID == companyID && wc.FlagDelete == 0).ToList();
        //    }
        //}
        public WebCompany GetWebCompanyByID(int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompany.Find(companyID);
            }
        }

        public int AddWebCompany(WebCompany webCompany)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCompany.Add(webCompany);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebCompany(WebCompany webCompany)
        {
            WebCaseService webCaseService = new WebCaseService();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany originalCompany = context.WebCompany.Find(webCompany.CompanyID);

                if (originalCompany != null && webCompany != null)
                {
                    originalCompany.CompanyName = webCompany.CompanyName;
                    originalCompany.CompanyNet = webCompany.CompanyNet;
                    originalCompany.BelongArea = webCompany.BelongArea;
                    originalCompany.CaseCount = webCaseService.GetCaseCountByCompanyId(webCompany.CompanyID);
                    originalCompany.CompanyAddress = webCompany.CompanyAddress;
                    originalCompany.CompanyInfo = webCompany.CompanyInfo;
                    originalCompany.CompanyMail = webCompany.CompanyMail;
                    originalCompany.CompanyMoble = webCompany.CompanyMoble;
                    originalCompany.CompanyPeople = webCompany.CompanyPeople;
                    originalCompany.CompanyPhone = webCompany.CompanyPhone;
                    originalCompany.EditOn = DateTime.Now;
                    originalCompany.ForwardNetAddress = webCompany.ForwardNetAddress;
                    originalCompany.InBuildingCount = webCompany.InBuildingCount;
                    originalCompany.IsApproved = webCompany.IsApproved;
                    originalCompany.IsAuthentication = webCompany.IsAuthentication;
                    originalCompany.IsBond = webCompany.IsBond;
                    originalCompany.IsFamousEnterprise = webCompany.IsFamousEnterprise;
                    originalCompany.IsPreferentialActivity = webCompany.IsPreferentialActivity;
                    originalCompany.IsTop = webCompany.IsTop;
                    originalCompany.ShowOrder = webCompany.ShowOrder;
                    originalCompany.CompanyImage = webCompany.CompanyImage;
                    originalCompany.thumbnailImage = webCompany.thumbnailImage;
                    originalCompany.CompanySize = webCompany.CompanySize;
                    originalCompany.GoodAtStyle = webCompany.GoodAtStyle;
                    originalCompany.GoodAtStyleID = webCompany.GoodAtStyleID;

                    originalCompany.ProvinceID = webCompany.ProvinceID;
                    originalCompany.ProvinceName = webCompany.ProvinceName;
                    originalCompany.CityID = webCompany.CityID;
                    originalCompany.CityName = webCompany.CityName;
                    originalCompany.AreasID = webCompany.AreasID;
                    originalCompany.AreasName = webCompany.AreasName;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public int UpdateWebCompanyByCompanyCenter(WebCompany webCompany)
        {
            WebCaseService webCaseService = new WebCaseService();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany originalCompany = context.WebCompany.Find(webCompany.CompanyID);
                if (originalCompany != null && webCompany != null)
                {
                    originalCompany.CompanyName = webCompany.CompanyName;
                    originalCompany.CompanyNet = webCompany.CompanyNet;
                    originalCompany.BelongArea = webCompany.BelongArea;
                    originalCompany.CaseCount = webCaseService.GetCaseCountByCompanyId(webCompany.CompanyID);
                    originalCompany.CompanyAddress = webCompany.CompanyAddress;
                    originalCompany.CompanyInfo = webCompany.CompanyInfo;
                    //originalCompany.CompanyMail = webCompany.CompanyMail;
                    originalCompany.CompanyMoble = webCompany.CompanyMoble;
                    originalCompany.CompanyPeople = webCompany.CompanyPeople;
                    originalCompany.CompanyPhone = webCompany.CompanyPhone;
                    originalCompany.EditOn = DateTime.Now;
                    //originalCompany.ForwardNetAddress = webCompany.ForwardNetAddress;
                    //originalCompany.InBuildingCount = webCompany.InBuildingCount;
                    //originalCompany.IsApproved = webCompany.IsApproved;
                    //originalCompany.IsAuthentication = webCompany.IsAuthentication;
                    //originalCompany.IsBond = webCompany.IsBond;
                    //originalCompany.IsFamousEnterprise = webCompany.IsFamousEnterprise;
                    //originalCompany.IsPreferentialActivity = webCompany.IsPreferentialActivity;
                    //originalCompany.IsTop = webCompany.IsTop;
                    //originalCompany.ShowOrder = webCompany.ShowOrder;
                    originalCompany.GoodAtStyle = webCompany.GoodAtStyle;
                    originalCompany.GoodAtStyleID = webCompany.GoodAtStyleID;
                    originalCompany.GoodAtTypeID = webCompany.GoodAtTypeID;
                    originalCompany.GoodAtType = webCompany.GoodAtType;
                    originalCompany.PriceID = webCompany.PriceID;
                    originalCompany.PriceName = webCompany.PriceName;

                    originalCompany.CompanyImage = webCompany.CompanyImage;
                    originalCompany.thumbnailImage = webCompany.thumbnailImage;
                    originalCompany.CompanySize = webCompany.CompanySize;

                    originalCompany.ProvinceID = webCompany.ProvinceID;
                    originalCompany.ProvinceName = webCompany.ProvinceName;
                    originalCompany.CityID = webCompany.CityID;
                    originalCompany.CityName = webCompany.CityName;
                    originalCompany.AreasID = webCompany.AreasID;
                    originalCompany.AreasName = webCompany.AreasName;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }
        public int UpdateWebCompanyLicence(WebCompany webCompany)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany originalCompany = context.WebCompany.Find(webCompany.CompanyID);
                if (originalCompany != null && webCompany != null)
                {
                    originalCompany.Honor = webCompany.Honor;
                    originalCompany.Certification = webCompany.Certification;
                    originalCompany.CompanyLicence = webCompany.CompanyLicence;
                    originalCompany.EditOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }
        public int UpdateWebCompanyRegist(WebCompany webCompany)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany originalCompany = context.WebCompany.Find(webCompany.CompanyID);
                if (originalCompany != null && webCompany != null)
                {

                    originalCompany.CompanyType = webCompany.CompanyType;
                    originalCompany.RegistAddress = webCompany.RegistAddress;
                    originalCompany.RegistAuthority = webCompany.RegistAuthority;
                    originalCompany.RegistMark = webCompany.RegistMark;
                    originalCompany.RepresentPerson = webCompany.RepresentPerson;
                    originalCompany.CompanyAddOn = webCompany.CompanyAddOn;
                    originalCompany.BusinessScope = webCompany.BusinessScope;
                    originalCompany.RegistMoney = webCompany.RegistMoney;
                    originalCompany.EditOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }
        public int DeleteWebCompany(int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany webCompany = context.WebCompany.Find(companyID);
                if (webCompany != null)
                {
                    webCompany.FlagDelete = 1;
                    webCompany.DeleteOn = DateTime.Now;
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
        /// 通过CompanyUserID获取单个人员
        /// </summary>
        public WebCompany GetWebCompanyByUserID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompany.FirstOrDefault(c => c.WebCompanyUserID == userID);
            }
        }

        public bool IsHaveuser(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany WebCompany = context.WebCompany.FirstOrDefault(us => us.WebCompanyUserID == userID);
                return WebCompany != null ? true : false;
            }
        }


        public void PageViewAdd(int CompanyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany originalWebCompany = context.WebCompany.Find(CompanyID);
                if (originalWebCompany != null)
                {
                    originalWebCompany.PageViewCount = originalWebCompany.PageViewCount + 1;
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 根据companyID修改案例个数
        /// </summary>
        public void updateCaseCountbyCompanyID(int companyID)
        {
            WebCaseService webCaseService = new WebCaseService();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompany originalWebCompany = context.WebCompany.Find(companyID);
                if (originalWebCompany != null)
                {
                    originalWebCompany.CaseCount = webCaseService.GetCaseCountByCompanyId(companyID);
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 根据companyID获取团队人员数
        /// </summary>
        public int GetPeopleCountbyCompanyID(int companyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                int Peoplecount = context.WebPeople.Where(c => c.CompanyID == companyID && c.FlagDelete == 0).ToList().Count;
                return Peoplecount;

            }
        }
    }
}

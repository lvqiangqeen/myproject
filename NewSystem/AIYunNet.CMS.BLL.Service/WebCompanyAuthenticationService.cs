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
    public class WebCompanyAuthenticationService
    {
        /// <summary>
        /// 用户申请审核列表
        /// </summary>
        public List<WebCompanyAuthentication> GetWebCompanyAuthenticationList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebCompanyAuthentication.Where(p => p.IsDelete == 0).OrderByDescending(p => p.AddOn).ToList();

            }
        }
        /// <summary>
        /// 获取审核用户
        /// </summary>
        public List<WebCompanyAuthentication> GetWebCompanyAuthenticationList(int IsAuthentication)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebCompanyAuthentication.Where(p => p.IsDelete == 0 && p.IsAuthentication == IsAuthentication).ToList();

            }
        }


        public WebCompanyAuthentication GetWebCompanyAuthenticationByUserID(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompanyAuthentication.FirstOrDefault(c => c.CompanyUserID == UserID && c.IsDelete == 0);
            }
        }
        public WebCompanyAuthentication GetWebCompanyAuthenticationByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompanyAuthentication.Find(id);
            }
        }
        public int AddWebCompanyAuthentication(WebCompanyAuthentication WebCompanyAuthentication)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCompanyAuthentication.Add(WebCompanyAuthentication);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebCompanyAuthentication(WebCompanyAuthentication WebCompanyAuthentication)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebCompanyAuthentication != null)
                {
                    WebCompanyAuthentication origWebCompanyAuthentication = context.WebCompanyAuthentication.FirstOrDefault(c => c.CompanyUserID == WebCompanyAuthentication.CompanyUserID);
                    if (origWebCompanyAuthentication != null)
                    {
                        origWebCompanyAuthentication.CompanyID = WebCompanyAuthentication.CompanyID;
                        origWebCompanyAuthentication.CompanyName = WebCompanyAuthentication.CompanyName;
                        origWebCompanyAuthentication.PeopleName = WebCompanyAuthentication.PeopleName;
                        origWebCompanyAuthentication.IsAuthentication = 0;
                        origWebCompanyAuthentication.ShengfenF = WebCompanyAuthentication.ShengfenF;
                        origWebCompanyAuthentication.ShengfenZ = WebCompanyAuthentication.ShengfenZ;
                        origWebCompanyAuthentication.PeopleIdentity = WebCompanyAuthentication.PeopleIdentity;
                        origWebCompanyAuthentication.ZthumbnailImage = WebCompanyAuthentication.ZthumbnailImage;
                        origWebCompanyAuthentication.FthumbnailImage = WebCompanyAuthentication.FthumbnailImage;
                        origWebCompanyAuthentication.UploadFile = WebCompanyAuthentication.UploadFile;
                        origWebCompanyAuthentication.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }

        public int IsAuthentication(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    WebCompanyAuthentication origWebCompanyAuthentication = context.WebCompanyAuthentication.Find(id);
                    WebCompany orwebcompany = context.WebCompany.FirstOrDefault(c => c.WebCompanyUserID == origWebCompanyAuthentication.CompanyUserID);
                    if (origWebCompanyAuthentication != null)
                    {
                        origWebCompanyAuthentication.IsAuthentication = 1;
                        orwebcompany.IsAuthentication = true;
                        origWebCompanyAuthentication.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int IsNotAuthentication(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    WebCompanyAuthentication origWebCompanyAuthentication = context.WebCompanyAuthentication.Find(id);
                    WebCompany orwebcompany = context.WebCompany.FirstOrDefault(c => c.WebCompanyUserID == origWebCompanyAuthentication.CompanyUserID);
                    if (origWebCompanyAuthentication != null)
                    {
                        origWebCompanyAuthentication.IsAuthentication = 2;
                        orwebcompany.IsAuthentication = false;
                        origWebCompanyAuthentication.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int DeleteWebCompanyAuthentication(int WebCompanyAuthenticationID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyAuthentication WebCompanyAuthentication = context.WebCompanyAuthentication.Find(WebCompanyAuthenticationID);
                if (WebCompanyAuthentication != null)
                {
                    WebCompanyAuthentication.IsDelete = 1;
                    WebCompanyAuthentication.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

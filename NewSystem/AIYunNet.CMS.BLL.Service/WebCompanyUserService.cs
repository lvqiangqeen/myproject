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
    public class WebCompanyUserService
    {
        public int AddWebCompanyUser(WebCompanyUser WebCompanyUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCompanyUser.Add(WebCompanyUser);
                context.SaveChanges();
                return 1;
            }
        }
        public bool IsHaveuserAccount(string userAccount)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser user = context.WebCompanyUser.FirstOrDefault(us => us.ComUserName == userAccount);
                return user != null ? true : false;
            }
        }
        public bool ExistUser(string userAccount, string userPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser user = context.WebCompanyUser.FirstOrDefault(us => us.ComUserName == userAccount && us.Password == userPwd);
                return user != null ? true : false;
            }
        }

        public int UpdateWebCompanyUserPassword(string userAccount, string newUserPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser user = context.WebCompanyUser.FirstOrDefault(us => us.ComUserName == userAccount);
                if (user != null)
                {
                    user.Password = newUserPwd;
                    user.EditOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public List<WebCompanyUser> GetWebCompanyUserList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompanyUser.Where(su => su.IsDelete == false).OrderByDescending(su => su.AddOn).ToList();
            }
        }

        public int UpdateWebCompanyUser(WebCompanyUser newWebCompanyUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser originalUser = context.WebCompanyUser.Find(newWebCompanyUser.CompanyUserID);
                WebCompany oriwebcompany = context.WebCompany.FirstOrDefault(c => c.WebCompanyUserID == newWebCompanyUser.CompanyUserID);
                if (originalUser != null)
                {
                    originalUser.CompanyName = newWebCompanyUser.CompanyName;
                    originalUser.CompanyPhone = newWebCompanyUser.CompanyPhone;
                    originalUser.IsLock = newWebCompanyUser.IsLock;
                    originalUser.EditOn = DateTime.Now;
                    if (oriwebcompany != null)
                    {
                        oriwebcompany.CompanyName = newWebCompanyUser.CompanyName;
                        oriwebcompany.CompanyMoble = newWebCompanyUser.CompanyPhone;
                    }
                    context.SaveChanges();
                }
                return 1;
            }
        }
        public int UpdateWebCompanyUserFromCenter(WebCompanyUser newWebCompanyUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser originalUser = context.WebCompanyUser.Find(newWebCompanyUser.CompanyUserID);
                if (originalUser != null)
                {
                    originalUser.CompanyName = newWebCompanyUser.CompanyName;
                    originalUser.EditOn = DateTime.Now;
                    context.SaveChanges();
                }

                return 1;
            }
        }
        public WebCompanyUser GetWebCompanyUserByID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompanyUser.Find(userID);
            }
        }

        public WebCompanyUser GetWebCompanyUserByAccount(string userAccount, string userPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser user = context.WebCompanyUser.FirstOrDefault(us => us.ComUserName == userAccount && us.Password == userPwd);
                return user;
            }
        }

        public WebCompanyUser GetWebCompanyUserByAccount(string userAccount)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser user = context.WebCompanyUser.FirstOrDefault(us => us.ComUserName == userAccount);
                return user;
            }
        }

        public int deleteWebCompanyUser(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyUser originalNews = context.WebCompanyUser.Find(UserID);
                if (originalNews != null)
                {
                    originalNews.IsDelete = true;
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

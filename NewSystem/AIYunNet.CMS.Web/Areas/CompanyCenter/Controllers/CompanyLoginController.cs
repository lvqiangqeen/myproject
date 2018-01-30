using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Areas.CompanyCenter.Controllers
{
    public class CompanyLoginController : Controller
    {
        WebCompanyUserService webcomuserser = new WebCompanyUserService();
        WebCompanyService webcomser = new WebCompanyService();
        // GET: CompanyCenter/CompanyLogin
        public ActionResult CompanyLogin()
        {
            return View();
        }
        public ActionResult CompanySignup()
        {
            return View();
        }

        [HttpPost]
        public int CompanyUserLoginOn(string userAccount, string userPassword)
        {
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "md5");
            bool exist = webcomuserser.ExistUser(userAccount, password);
            if (exist)
            {
                WebCompanyUser User = webcomuserser.GetWebCompanyUserByAccount(userAccount, password);
                WebCompanyUserService webuserservice = new WebCompanyUserService();
                WebCompanyService webcompanyeservice = new WebCompanyService();
                //userAccount=UserName
                if (User.IsLock)
                {

                    //被锁定
                    return 100;
                }
                else
                {
                    SessionHelper.SetSession("companyUserName", userAccount);
                    WebCompany WebCompany = new WebCompany();
                    if (webcompanyeservice.IsHaveuser(User.CompanyUserID))
                    {
                        WebCompany = webcompanyeservice.GetWebCompanyByUserID(User.CompanyUserID);
                    }
                    SessionHelper.SetSession("companyID", WebCompany.CompanyID);
                    SessionHelper.SetSession("CompanyName", User.CompanyName);
                    SessionHelper.SetSession("companyUserID", User.CompanyUserID);
                    //正常
                    return 200;
                }
            }
            else
            {
                //无用户
                return 500;
            }
        }


        [HttpPost]
        public int CompanyRegister(string userAccount, string userPassword)
        {
            bool bit = webcomuserser.IsHaveuserAccount(userAccount);
            if (bit)
            {
                //存在
                return 0;
            }
            else
            {
                WebCompanyUser webcompanyuser = new WebCompanyUser
                {
                    ComUserName = userAccount,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "md5"),
                    CompanyPhone = userAccount
                };
                webcomuserser.AddWebCompanyUser(webcompanyuser);
                WebCompany webcom = new WebCompany
                {
                    CompanyMoble = userAccount,
                    WebCompanyUserID = webcomuserser.GetWebCompanyUserByAccount(userAccount).CompanyUserID
                };
                int result = webcomser.AddWebCompany(webcom);
                return result;
            }

        }
        [HttpPost]
        public int IsHaveTel(string userAccount)
        {
            bool bit = webcomuserser.IsHaveuserAccount(userAccount);
            if (bit)
            {
                //存在
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
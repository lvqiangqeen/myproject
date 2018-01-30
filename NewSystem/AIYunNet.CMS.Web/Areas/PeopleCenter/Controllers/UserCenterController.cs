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

namespace AIYunNet.CMS.Web.Areas.PeopleCenter.Controllers
{
    
    public class UserCenterController : Controller
    {
        WebUserService webUserservice = new WebUserService();
        WebPeopleService webpeopleservice = new WebPeopleService();
        // GET: PeopleCenter/UserCenter
        [HttpGet]
        public ActionResult LoginOn()
        {
            return View();
        }
        [HttpPost]
        public int LoginOn(string userAccount, string userPassword)
        {
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "md5");
            bool exist = webUserservice.ExistUser(userAccount, password);
            if (exist)
            {
                WebUser User = webUserservice.GetWebUserByAccount(userAccount, password);
                WebUserService webuserservice = new WebUserService();
                WebPeopleService webpeopleservice = new WebPeopleService();
                //userAccount=UserName
                if (User.IsLock)
                {
                    
                    //被锁定
                    return 100;
                }
                else
                {
                    SessionHelper.SetSession("userName", userAccount);
                    WebUser webuser = webuserservice.GetWebUserByAccount(userAccount);
                    WebPeople webpeople = new WebPeople();
                    if (webpeopleservice.IsHaveuser(webuser.UserID))
                    {
                        webpeople = webpeopleservice.GetWebPeopleByUserID(webuser.UserID);
                    }
                    SessionHelper.SetSession("PeopleID", webpeople.PeopleID);
                    SessionHelper.SetSession("NickName", webuser.NickName);
                    SessionHelper.SetSession("UserID", webuser.UserID);
                    return 200;
                }
            }
            else
            {
                return 500;
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public int Register(string userAccount, string userPassword)
        {
            bool bit=webUserservice.IsHaveuserAccount(userAccount);
            if (bit)
            {
                //存在
                return 0;
            }
            else
            {
                WebUser webuser = new WebUser
                {
                    UserName = userAccount,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "md5"),
                    Telephone = userAccount
                };
                int result = webUserservice.AddWebUser(webuser);
                return result;
            }

        }
        [HttpPost]
        public int IsHaveTel(string userAccount)
        {
            bool bit = webUserservice.IsHaveuserAccount(userAccount);
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
        [AuthorityFilter]
        public ActionResult PeopleCenterIndex()
        {
            return View();
        }


        //个人资料
        [HttpGet]
        [AuthorityFilter]
        public ActionResult PeopleDetail()
        {

            return View();
        }
        //修改资料
        [HttpPost]
        [AuthorityFilter]
        public int UpdatePeople()
        {
            WebUser webuser = new WebUser {
                UserID=Convert.ToInt32(Request["UserID"]),
                NickName = Request["NickName"],
                TrueName = Request["TrueName"],
                Email = Request["Email"],
                Address = Request["Address"],
                Sex=Request["Sex"],
                UserType=Request["UserType"]
            };
            webUserservice.UpdateWebUserFromCenter(webuser);
            if (webpeopleservice.IsHaveuser(Convert.ToInt32(Request["UserID"])))
            {
                WebPeople webpeople = webpeopleservice.GetWebPeopleByUserID(Convert.ToInt32(Request["UserID"]));
                WebPeople webpeo = new WebPeople
                {
                    PeopleID = webpeople.PeopleID,
                    Address = Request["Address"],
                    PeopleCategory= Request["UserType"],
                    PeopleImage= Request["PeopleImage"],
                    thumbnailImage= Request["thumbnailImage"],
                    PeoplePhone=Request["PeoplePhone"],
                    PeopleName=Request["TrueName"],
                    PeopleMail=Request["Email"]
                };
                webpeopleservice.UpdateWebPeopleFromCenter(webpeo);
                
            }
            else
            {
                WebPeople webpeo = new WebPeople
                {
                    Address = Request["Address"],
                    PeopleName= Request["TrueName"],
                    PeopleCategory = Request["UserType"],
                    PeopleImage = Request["PeopleImage"],
                    thumbnailImage = Request["thumbnailImage"],
                    PeoplePhone = Request["PeoplePhone"],
                    PeopleMail = Request["Email"]
                };
                webpeopleservice.AddWebPeople(webpeo);
            }
            return 1;
        }
        //修改人物信息
        [HttpPost]
        [AuthorityFilter]
        public int UpdatePeopleDetail()
        {
            WebPeople webpeo = new WebPeople
            {
                PeopleID = Convert.ToInt32(Request["PeopleID"]),
                PeoplePositionID = Request["PeoplePositionID"],
                WorkYearsID = Convert.ToInt32(Request["WorkYearsID"]),
                BelongArea = Request["BelongArea"],
                PeopleMotto = Request["PeopleMotto"],
                PeopleInfo = Request["PeopleInfo"],
                GoodAtStyleID = Request["GoodAtStyleID"],
                GoodAtStyle =Request["GoodAtStyle"]
            };
            webpeopleservice.UpdateWebPeopleFromCenterDetail(webpeo);
            return 1;
        }




        //修改密码
        [HttpGet]
        [AuthorityFilter]
        public ActionResult UpdateUserPassword()
        {
            return View();
        }
        [HttpPost]
        [AuthorityFilter]
        public int UpdateUserPassword(string userAccount,string OriginPwd, string userPassword)
        {
            string oldpwd= FormsAuthentication.HashPasswordForStoringInConfigFile(OriginPwd, "md5");
            string userpwd=FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "md5");
            bool bit = webUserservice.ExistUser(userAccount, oldpwd);
            if (bit)
            {
                webUserservice.UpdateWebUserPassword(userAccount, userpwd);
                return 1;
            }
            else
            {
                //旧密码错误
                return 0;
            }
        }
        //账户安全
        [HttpGet]
        [AuthorityFilter]
        public ActionResult UserCenterSafe()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    public class MobileCenterController : Controller
    {
        WebUserService webUserservice = new WebUserService();
        WebPeopleService webpeopleservice = new WebPeopleService();
        WebWorkerService webWorkerService = new WebWorkerService();
        t_AreaService areaService = new t_AreaService();
        // GET: MobileApp/MobileCenter
        public ActionResult mPCenter()
        {
            return View();
        }
        //登录页面
        public ActionResult LoginCenter()
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
                    SessionHelper.SetSession("UserName", userAccount);

                    WebUser webuser = webuserservice.GetWebUserByAccount(userAccount);
                    SessionHelper.SetSession("UserID", webuser.UserID);
                    SessionHelper.SetSession("PositionCode", webuser.PositionCode);

                    WebPeople webpeople = new WebPeople();
                    WebWorker webWorker = new WebWorker();
                    if (webpeopleservice.IsHaveuser(webuser.UserID) && webuser.PositionCode == "WebPeople")
                    {
                        webpeople = webpeopleservice.GetWebPeopleByUserID(webuser.UserID);
                        SessionHelper.SetSession("PositionID", webpeople.PeopleID);
                    }
                    else if (webWorkerService.IsHaveWorker(webuser.UserID) && (webuser.PositionCode == "WebWorkerLeader" || webuser.PositionCode == "WebWorker"))
                    {
                        webWorker = webWorkerService.GetWebWorkerByUserID(webuser.UserID);
                        SessionHelper.SetSession("PositionID", webWorker.WorkerID);
                    }
                    SessionHelper.SetSession("NickName", webuser.NickName);
                    return 200;
                }
            }
            else
            {
                return 500;
            }
        }
        //注册页面
        public ActionResult registCenter()
        {
            return View();
        }
    }
}
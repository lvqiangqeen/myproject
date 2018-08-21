using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain.OccaModel;
using System.Web.Security;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class UsersCenterController : BaseController
    {
        WebUserService webuserservice = new WebUserService();
        WebPeopleAuthenticationService AuthenticationService = new WebPeopleAuthenticationService();
        WebPeopleGuarantMoneyService GuarantMoneyService = new WebPeopleGuarantMoneyService();
        WebCommonService webcommonser = new WebCommonService();
        WebWorkerService workSer = new WebWorkerService();
        t_AreaService areaService = new t_AreaService();
        WebCommonService commonService = new WebCommonService();
        // GET: SysAdmin/UsersCenter
        public ActionResult Userlist(string usertype)
        {
            List<WebUser> userlist = webuserservice.GetWebUserList(usertype);
            ViewBag.userlist = userlist;
            return View();
        }
        [HttpGet]
        public ActionResult AddAndUpdateUser(int userid)
        {
            //省份
            IEnumerable<SelectListItem> provinceList = null;
            List<t_Province> common = areaService.GetProvinceList();
            provinceList = common.Select(com => new SelectListItem { Value = com.provinceID.ToString(), Text = com.province });
            ViewBag.provinceList = provinceList;
            //工作年限
            List<WebLookup> workyearlist = commonService.GetLookupList("people_workyear");
            ViewBag.workyearslist = workyearlist;
            //工人职位
            List<WebLookup> commonworkPosition = commonService.GetLookupList("workers_position");       
            ViewBag.workPositionList = commonworkPosition;

            WebUser webuser = webuserservice.GetWebUserByID(userid);
            //List<WebLookup> weblooktypelist = webcommonser.GetLookupList("people_category");
            //IEnumerable<SelectListItem> typelist = weblooktypelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            //ViewBag.typelist = typelist;
            WebWorker work = new WebWorker();
            if (webuser != null)
            {
                if (webuser.PositionCode != "WebUser")
                {
                    work = workSer.GetWebWorkerByUserID(userid);
                }
            }else
            {
                webuser = new WebUser();
            }
            ViewBag.worker = work;
            return View(webuser);
        }
        [HttpPost]
        public ActionResult AddAndUpdateUserAndWorkerModel(UserAndWorkerModel model)
        {
            string workercategory = "";
            if(model.PositionCode== "WebWorkerLeader")
            {
                workercategory = "装修工长";
            }
            else if (model.PositionCode == "WebWorker")
            {
                workercategory = "装修工人";
            }
            int result = 0;

            string Password = "";
            if (model.Password != null)
            {
                Password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "md5");
            }

            WebUser user = new WebUser()
            {
                UserID = model.UserID,
                UserName = model.UserName,
                Password = Password,
                NickName = model.NickName,
                TrueName = model.TrueName,
                Email = model.Email,
                Sex = model.Sex,
                PositionCode = model.PositionCode,
                Telephone = model.Telephone,
                ProvinceID = model.ProvinceID,
                ProvinceName = model.ProvinceName,
                CityID = model.CityID,
                CityName = model.CityName,
                AreasID = model.AreasID,
                AreasName = model.AreasName,
                IsLock = model.IsLock,
                InUser = model.InUser
            };
            WebWorker worker = new WebWorker()
            {
                WorkerName=model.TrueName,
                WorkerCategory= workercategory,
                WorkerPhone=model.Telephone,
                WorkerMail=model.Email,
                WorkerInfo=model.WorkerInfo,
                WorkerMotto=model.WorkerMotto,
                ProvinceID=model.ProvinceID,
                ProvinceName=model.ProvinceName,
                CityID=model.CityID,
                CityName=model.CityName,
                AreasID=model.AreasID,
                AreasName=model.AreasName,
                WorkYearsID=model.WorkYearsID,
                WorkYears=model.WorkYears,
                PriceName=model.PriceName,
                GoodAtStyle=model.GoodAtStyle,
                WorkerPositionID=model.WorkerPositionID,
                WorkerPosition=model.WorkerPosition,
                IsApproved=model.InUser

            };
            if (model != null && model.UserID > 0)
            {
                result = webuserservice.UpdateWebUser(user);
                WebUser webu = webuserservice.GetWebUserByAccount(model.UserName);
                worker.UserID = webu.UserID;
                result = workSer.UpdateWebWorkerFromCenter(worker);
            }
            else
            {
                result = webuserservice.AddWebUser(user);
                WebUser webu= webuserservice.GetWebUserByAccount(model.UserName);
                worker.UserID = webu.UserID;
                result = workSer.AddWebWorker(worker);

            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddAndUpdateUser(WebUser webuser)
        {
            int result = 0;
            if (webuser != null && webuser.UserID > 0)
            {
                result = webuserservice.UpdateWebUser(webuser);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebUser(int UserID)
        {
            webuserservice.deleteWebUser(UserID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
        //身份认证
        public ActionResult Authenticationlist()
        {
            List<WebPeopleAuthentication> aulist = AuthenticationService.GetWebPeopleAuthenticationList();
            ViewBag.aulist = aulist;
            return View();
        }
        public ActionResult DeleteAu(int AUID)
        {
            AuthenticationService.DeleteWebPeopleAuthentication(AUID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddAndUpdateAu(int auid)
        {
            WebPeopleAuthentication authen = AuthenticationService.GetWebPeopleAuthenticationByID(auid);
            return View(authen);
        }
        [HttpPost]
        public int AddAndUpdateAu(int AUID,int IsIsAuthentication)
        {
            if (IsIsAuthentication == 1)
            {
                AuthenticationService.IsAuthentication(AUID);
            }
            else
            {
                AuthenticationService.IsNotAuthentication(AUID);
            }
            return 1;
        }
        //保证金申请
        public ActionResult GuarantMoneylist()
        {
            List<WebPeopleGuarantMoney> gulist = GuarantMoneyService.GetWebPeopleGuarantMoneyList();
            ViewBag.gulist = gulist;
            return View();
        }
        public ActionResult DeleteGu(int GUID)
        {
            GuarantMoneyService.DeleteWebPeopleGuarantMoney(GUID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddAndUpdateGu(int guid)
        {
            WebPeopleGuarantMoney Gu = GuarantMoneyService.GetWebPeopleGuarantMoneyByID(guid);
            return View(Gu);
        }
        [HttpPost]
        public int AddAndUpdateGu(int GUID,int IsGuarantMoney)
        {
            if (IsGuarantMoney == 1)
            {
                GuarantMoneyService.IsGuarantMoney(GUID);
            }
            else
            {
                GuarantMoneyService.IsNotGuarantMoney(GUID);
            }
            return 1;
        }
    }
}
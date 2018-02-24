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
        WebWorkerService webWorkerService = new WebWorkerService();
        t_AreaService areaService = new t_AreaService();

        [HttpGet]
        public ActionResult LoinOnButton()
        {
            return View();
        }
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
                    else if (webWorkerService.IsHaveWorker(webuser.UserID) && (webuser.PositionCode == "WebWorkerLeader"|| webuser.PositionCode == "WebWorker"))
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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public int Register(string userAccount, string userPassword,string PositionCode,int PositionType)
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
                    Telephone = userAccount,
                    PositionCode= PositionCode,
                    PositionType= PositionType
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
            //省份
            List<t_Province> provinceList = areaService.GetProvinceList();
            ViewBag.provinceList = provinceList;
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
                //Address = Request["Address"],
                Sex=Request["Sex"],
                ProvinceID= Request["ProvinceID"],
                ProvinceName= Request["ProvinceName"],
                CityID= Request["CityID"],
                CityName= Request["CityName"],
                AreasID= Request["AreasID"],
                AreasName= Request["AreasName"],
                Img= Request["PeopleImage"],
                thumbnailImage = Request["thumbnailImage"],

            };
            webUserservice.UpdateWebUserFromCenter(webuser);
            //设计师
            if (Request["PositionCode"] == "WebPeople")
            {
                WebPeople webpeo = new WebPeople
                {
                    //Address = Request["Address"],
                    //PeopleCategory = Request["UserType"],
                    PeopleImage = Request["PeopleImage"],
                    thumbnailImage = Request["thumbnailImage"],
                    PeoplePhone = Request["PeoplePhone"],
                    PeopleName = Request["TrueName"],
                    PeopleMail = Request["Email"],
                    ProvinceID = Request["ProvinceID"],
                    ProvinceName = Request["ProvinceName"],
                    CityID = Request["CityID"],
                    CityName = Request["CityName"],
                    AreasID = Request["AreasID"],
                    AreasName = Request["AreasName"],
                };
                if (webpeopleservice.IsHaveuser(Convert.ToInt32(Request["UserID"])))
                {
                    WebPeople webpeople = webpeopleservice.GetWebPeopleByUserID(Convert.ToInt32(Request["UserID"]));
                    webpeo.PeopleID = webpeople.PeopleID;
                    webpeopleservice.UpdateWebPeopleFromCenter(webpeo);
                }
                else
                {
                    webpeo.UserID= Convert.ToInt32(Request["UserID"]);
                    webpeopleservice.AddWebPeople(webpeo);
                }
            }
            else if(Request["PositionCode"] == "WebWorkerLeader"|| Request["PositionCode"] == "WebWorker")
            {
                WebWorker worker = new WebWorker {
                    WorkerName= Request["TrueName"],
                    WorkerPhone= Request["PeoplePhone"],
                    WorkerMail= Request["Email"],
                    WorkerImage = Request["PeopleImage"],
                    thumbnailImage= Request["thumbnailImage"],
                    ProvinceID = Request["ProvinceID"],
                    ProvinceName = Request["ProvinceName"],
                    CityID = Request["CityID"],
                    CityName = Request["CityName"],
                    AreasID = Request["AreasID"],
                    AreasName = Request["AreasName"],
                };
                if (Request["PositionCode"] == "WebWorkerLeader")
                {
                    worker.WorkerCategory = "装修工长";
                }
                else { worker.WorkerCategory = "装修工人"; }
                if (webWorkerService.IsHaveWorker(Convert.ToInt32(Request["UserID"])))
                {
                    WebWorker WebWorker = webWorkerService.GetWebWorkerByUserID(Convert.ToInt32(Request["UserID"]));
                    worker.WorkerID = WebWorker.WorkerID;
                    webWorkerService.UpdateWebWorkerFromCenter(worker);
                }
                else
                {
                    worker.UserID= Convert.ToInt32(Request["UserID"]);
                    webWorkerService.AddWebWorker(worker);
                }
            }

            return 1;
        }

        //设计师详细信息
        public ActionResult _DesignerView()
        {
            return View();
        }
        //工人和工长详细信息
        public ActionResult _WorkerView()
        {
            return View();
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
                PeoplePosition = Request["PeoplePosition"],
                WorkYearsID = Convert.ToInt32(Request["WorkYearsID"]),
                WorkYears= Request["WorkYears"],
                PriceID = Convert.ToInt32(Request["PriceID"]),
                PeopleMotto = Request["PeopleMotto"],
                PeopleInfo = Request["PeopleInfo"],
                GoodAtStyleID = Request["GoodAtStyleID"],
                GoodAtStyle =Request["GoodAtStyle"],
                DesignerImage= Request["DesignerImage"],
            };
            webpeopleservice.UpdateWebPeopleFromCenterDetail(webpeo);
            return 1;
        }
        //修改人物信息
        [HttpPost]
        [AuthorityFilter]
        public int UpdateWorkerDetail()
        {
            WebWorker webpeo = new WebWorker
            {
                WorkerID = Convert.ToInt32(Request["WorkerID"]),
                WorkerPositionID = Request["WorkerPositionID"],
                WorkerPosition = Request["WorkerPosition"],
                WorkYearsID = Convert.ToInt32(Request["WorkYearsID"]),
                WorkYears = Request["WorkYears"],
                PriceName = Request["PriceName"],
                WorkerMotto = Request["WorkerMotto"],
                WorkerInfo = Request["WorkerInfo"],
                GoodAtStyleID = Request["GoodAtStyleID"],
                GoodAtStyle = Request["GoodAtStyle"]
            };
            webWorkerService.UpdateWebWorkerFromCenterDetail(webpeo);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Areas.PeopleCenter.Controllers
{
    [AuthorityFilter]
    public class CertificationController : Controller
    {
        WebPeopleAuthenticationService webautnservice = new WebPeopleAuthenticationService();
        WebPeopleGuarantMoneyService webmoneyservice = new WebPeopleGuarantMoneyService();
        // GET: PeopleCenter/Certification
        public ActionResult Authentication()
        {
            return View();
        }
        [HttpPost]
        public int AddAuthentication(WebPeopleAuthentication webAuthen)
        {
            WebPeopleAuthentication webthis = webautnservice.GetWebPeopleAuthenticationByUserID(webAuthen.UserID);
            if (webthis != null && webthis.IsAuthentication == 2)
            {
                webautnservice.UpdateWebPeopleAuthentication(webAuthen);
                //申请
                return 1;
            }
            else if (webthis != null && webthis.IsAuthentication == 1)
            {
                //已通过
                return 0;
            }
            else if (webthis != null && webthis.IsAuthentication == 0)
            {
                //已提交
                return 2;
            }
            else
            {
                //申请
                webautnservice.AddWebPeopleAuthentication(webAuthen);
                return 1;
            }

        }


        public ActionResult GuarantMoney()
        {
            return View();
        }
        [HttpPost]
        public int AddGuarantMoney(WebPeopleGuarantMoney GuarantMoney)
        {
            WebPeopleGuarantMoney webthis = webmoneyservice.GetWebPeopleGuarantMoneyByUserID(GuarantMoney.UserID);
            if (webthis != null && webthis.IsGuarantMoney == 2)
            {
                webmoneyservice.UpdateWebPeopleGuarantMoney(GuarantMoney);
                //申请
                return 1;
            }
            else if (webthis != null && webthis.IsGuarantMoney == 1)
            {
                //已通过
                return 0;
            }
            else if (webthis != null && webthis.IsGuarantMoney == 0)
            {
                //已提交
                return 2;
            }
            else
            {
                //申请
                webmoneyservice.AddWebPeopleGuarantMoney(GuarantMoney);
                return 1;
            }

        }

        public ActionResult CertificStatic()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public void GetCitySession()
        {
            string mkjcitycode = Request["mkjcitycode"];
            string mkjcityname = Request["mkjcityname"];
            SessionHelper.SetSession("mkjcitycode", mkjcitycode);
            SessionHelper.SetSession("mkjcityname", mkjcityname);
        }
    }
}
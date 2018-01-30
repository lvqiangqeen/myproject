using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Common.Utility.Tools;

namespace AIYunNet.CMS.Web.filter
{
    public class ZanFilter:ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.RequestContext.HttpContext.Request;
            Security sec = new Security();
            string RequestKey = sec.GetRequestKey();
            SessionHelper.SetSession("RequestKey", RequestKey);
        }
    }
}
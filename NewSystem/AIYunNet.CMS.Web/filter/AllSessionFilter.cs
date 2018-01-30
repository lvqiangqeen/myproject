using AIYunNet.CMS.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIYunNet.CMS.Web.filter
{
    public class AllSessionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.RequestContext.HttpContext.Request;
            if (SessionHelper.GetSession("mkjcitycode") == null)
            {
                SessionHelper.SetSession("mkjcitycode", "130100");
                SessionHelper.SetSession("mkjcityname", "石家庄");
            }

            //string mkjcitycode= SessionHelper.GetSession("mkjcitycode").ToString();

        }
    }
}
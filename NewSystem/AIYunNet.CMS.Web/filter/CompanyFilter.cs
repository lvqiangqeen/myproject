using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.filter
{
    public class CompanyFilter: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.RequestContext.HttpContext.Request;
            string userAcount = SessionHelper.Get("companyUserName");
            if (string.IsNullOrEmpty(userAcount))
            {
                filterContext.Result = new RedirectResult(string.Format("/CompanyCenter/CompanyLogin/CompanyLogin"));
                return;
            }

        }
    }
}
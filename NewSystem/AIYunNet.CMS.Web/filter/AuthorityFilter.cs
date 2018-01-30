using AIYunNet.CMS.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIYunNet.CMS.Web.filter
{
    public class AuthorityFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.RequestContext.HttpContext.Request;
            string userAcount = SessionHelper.Get("userName");
            if (string.IsNullOrEmpty(userAcount))
            {
                filterContext.Result =new RedirectResult(string.Format("/PeopleCenter/UserCenter/LoginOn"));
                return;
            }

        }
    }
}
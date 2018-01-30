using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /SysAdmin/Base/

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (requestContext.HttpContext.Session["userAccount"] != null)
            {
                 
            }
            else
            {
                requestContext.HttpContext.Response.Redirect("/SysAdmin/Account/Index");
            }
        }  


    }
}

using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.MobileApp
{
    public class MobileAppAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MobileApp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MobileApp_default",
                "MobileApp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
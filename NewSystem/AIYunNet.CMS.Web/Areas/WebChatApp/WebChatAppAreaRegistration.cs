using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.WebChatApp
{
    public class WebChatAppAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebChatApp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebChatApp_default",
                "WebChatApp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
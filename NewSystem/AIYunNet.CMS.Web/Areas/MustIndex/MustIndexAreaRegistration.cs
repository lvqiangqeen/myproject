using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.MustIndex
{
    public class MustIndexAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MustIndex";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MustIndex_default",
                "MustIndex/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
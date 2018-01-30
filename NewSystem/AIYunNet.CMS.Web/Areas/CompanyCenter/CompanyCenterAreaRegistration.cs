using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.CompanyCenter
{
    public class CompanyCenterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CompanyCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CompanyCenter_default",
                "CompanyCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
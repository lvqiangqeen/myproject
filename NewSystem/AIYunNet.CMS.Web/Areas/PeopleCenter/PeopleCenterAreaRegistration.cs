using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.PeopleCenter
{
    public class PeopleCenterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PeopleCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PeopleCenter_default",
                "PeopleCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
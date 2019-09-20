using System.Web.Mvc;

namespace GE.App.Areas.GruposEtareos
{
    public class GruposEtareosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GruposEtareos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GruposEtareos_default",
                "GruposEtareos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using Nekram.App.App_Start;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nekram.App {
    public class MvcApplication : HttpApplication {
        protected void Application_Start() {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapProfile>());
        }
    }
}

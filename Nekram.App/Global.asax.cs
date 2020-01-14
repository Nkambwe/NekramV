using Nekram.App.App_Start;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace Nekram.App {
    public class MvcApplication : HttpApplication {
        protected void Application_Start() {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeAutoMapper();
        }

        public static void InitializeAutoMapper() {
            Mapper.Initialize(m =>
                m.AddProfile<AutoMapProfile>()
            );
        }
    }
}

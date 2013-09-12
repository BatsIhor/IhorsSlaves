using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IhorsSlaves.Context;
using IhorsSlaves.DR;
using IhorsSlaves.Migrations;
namespace IhorsSlaves
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //Database.SetInitializer<IhorsSlaversDbContext>(new  CreateDatabaseIfNotExists<IhorsSlaversDbContext>());
            
            DependencyResolver.SetResolver(new NinjectDR());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            //IhorsSlaversDbContext context = new IhorsSlaversDbContext();
            //context.Database.CreateIfNotExists();
            //context.Database.Initialize(true);
        }
    }
}
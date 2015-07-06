using System.Web.Http;
using Microsoft.Owin;
using Owin;
using StacksOfWax.OwinApi;

[assembly: OwinStartup(typeof(Startup))]

namespace StacksOfWax.OwinApi
{
    // This replaces WebApiConfig
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            app.UseWebApi(config);
        }
    }
}

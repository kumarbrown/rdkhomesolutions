using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RDKHomeSolutions.Website.Startup))]

namespace RDKHomeSolutions.Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
         //services.addmv
        }
        public void Configuration(IAppBuilder app)
        {
            
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Owin;
using Nancy.Owin;
using Microsoft.Extensions.Logging;
namespace WebApplication1
{
    public class Startup {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
                // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app,ILoggerFactory loggerFactory){
            // loggerFactory.AddConsole(LogLevel.Information);
            // app.UseNancy();
             app.UseOwin(pipeline =>
            {
                // pipeline.UseNancy(options => options.Bootstrapper = new MyNancyBootstrapper());
                pipeline.UseNancy();
            });
           
        }
        public static void Main(string[] args)
        {
           var configuration = WebApplicationConfiguration.GetDefault(args);

            var application = new WebApplicationBuilder()
                        // .UseWebRoot()
                        // .UseApplicationBasePath(Directory.GetCurrentDirectory())
                        .UseConfiguration(configuration)
                        .UseStartup<Startup>()
                        .Build();

            application.Run();
        }
    }
}
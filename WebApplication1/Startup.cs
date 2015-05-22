using Owin;
namespace WebApplication1
{
    public class Startup {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
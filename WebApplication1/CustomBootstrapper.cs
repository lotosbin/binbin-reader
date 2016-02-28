using System;
using System.Diagnostics;
using System.Timers;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using WebApplication1.Services;
namespace WebApplication1
{
    public class CustomBootstrapper : DefaultNancyBootstrapper {
        private Timer _timer;

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines) {

            
            Nancy.Json.JsonSettings.MaxJsonLength = int.MaxValue;
            // your customization goes here
            _timer = new Timer();
            _timer.Interval = 60 * 1000;
            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;
            
            // container.AutoRegister();
            container.Register<ArticleService,ArticleService>();
            container.Register<FeedService,FeedService>();
            container.Register(typeof(Repository<>),typeof(Repository<>));
           }

        void timer_Elapsed(object sender, ElapsedEventArgs e) {
            Debug.WriteLine(DateTime.Now + " elapsed");
            var container = TinyIoCContainer.Current;
            var articleService = container.Resolve<ArticleService>();
            articleService.UpdateAll();
        }
    }
}
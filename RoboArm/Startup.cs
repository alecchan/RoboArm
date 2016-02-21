using System;
using Microsoft.Owin;
using Owin;
using Nancy.Owin;


namespace RoboArm
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage(new Microsoft.Owin.Diagnostics.WelcomePageOptions()
            {

                Path = new Microsoft.Owin.PathString("/welcome")
            });

            app.UseNancy();

            app.Run(ctx =>
            {

                ctx.Response.ContentType = "text/plain";
                string output = string.Format("I'm running on {0} from assembly {1}",
                    Environment.OSVersion,
                    System.Reflection.Assembly.GetEntryAssembly().FullName);

                return ctx.Response.WriteAsync(output);
            });
        }
    }
}

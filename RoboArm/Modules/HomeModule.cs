using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboArm.Modules
{

    public class Act
    {
        public string Action { get; set; }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/home"] = x => View["Home"];

            Post["/robotarm"] = (ctx) =>
            {
                try
                {
                    Console.WriteLine("HTTP POST Request: RobotArm");
                    var post = this.Bind<Act>(); //Breakpoint
                    var cmd = (Device.RobotArmCmds)Enum.Parse(typeof(Device.RobotArmCmds), post.Action, true);

                    using (var rb = new Device.UsbRobotArm())
                    {
                        rb.Initilise();
                        rb.SendCommand(cmd);
                    }
                    return Response.AsJson<string>("Done", HttpStatusCode.Accepted);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error :" + e.Message);
                    throw e;
                }
            };

            Post["/robotarm/reset"] = (ctx) =>
            {
                try
                {
                    Console.WriteLine("HTTP POST Request: RobotArm");
                    var history = this.Bind<string[]>(); //Breakpoint

                    foreach (var item in history.Reverse())
                    {
                        var cmd = (Device.RobotArmCmds)Enum.Parse(typeof(Device.RobotArmCmds), item, true);
                        
                        using (var rb = new Device.UsbRobotArm())
                        {
                            rb.Initilise();
                            rb.SendCommand(cmd, true);
                        }
                    }

                    return Response.AsJson<string>("Done", HttpStatusCode.Accepted);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error :" + e.Message);
                    throw e;
                }
            };
        }
    }
}

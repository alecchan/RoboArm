using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboArm
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://+:5000";
            var options = new StartOptions { Port = 5000 };
            options.Urls.Add(baseUrl);
            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();

            }
        }
    }
}

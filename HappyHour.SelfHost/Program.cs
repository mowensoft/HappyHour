using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyHour.Infrastructure;
using Nancy.Hosting.Self;

namespace HappyHour.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (
                    var host = new NancyHost(
                        new Uri("http://localhost:8086"), 
                        new Bootstrapper(),
                        new HostConfiguration()))
                {
                    host.Start();
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

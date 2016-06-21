using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.ConfTestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Hello)))
            {
                host.Open();
                Console.WriteLine("Services has begun listenting");
                Console.ReadKey();
            }
        }
    }
}

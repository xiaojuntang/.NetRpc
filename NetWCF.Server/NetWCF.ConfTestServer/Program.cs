using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.ConfTestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ServiceHost host = new ServiceHost(typeof(Hello)))
            //{
            //    host.Open();
            //    Console.WriteLine("Services has begun listenting");
            //    Console.ReadKey();
            //}

            if (serviceHostes.Count > 0)
                serviceHostes.Clear();
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            ServiceModelSectionGroup serviceModelSectionGroup = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
            // 开启每个服务
            foreach (ServiceElement serviceElement in serviceModelSectionGroup.Services.Services)
            {
                var wcfServiceType = Assembly.Load("RTLS.Services").GetType(serviceElement.Name);
                var serviceHost = new ServiceHost(wcfServiceType);
                serviceHostes.Add(serviceHost);
                serviceHost.Opened += delegate
                {
                    LogManager.WriteLog("Log", string.Format("{0}开始监听Uri为：{1}",
                    serviceElement.Name, serviceElement.Endpoints[0].Address.ToString()));
                };
                serviceHost.Open();
            }
        }
    }
}

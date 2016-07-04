using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zxxk.Ques.Business;
using Zxxk.Ques.Core;

namespace Zxxk.Ques.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZxxkServiceHost host = new ZxxkServiceHost())
            {
                host.Open();      
                Console.ReadLine();
            }
        }
    }

    public class ZxxkServiceHost : IDisposable
    {
        /// <summary>
        /// 定义一个服务对象
        /// </summary>
        private ServiceHost serviceHost;

        public ZxxkServiceHost()
        {
            string ipAndPort = "192.168.1.139:8085";
            //定义一个基地址
            string baseAddress = string.Format("net.tcp://{0}", ipAndPort);
            //通讯协议
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            netTcpBinding.Security.Mode = SecurityMode.None;
            serviceHost = new ServiceHost(typeof(QuesManager), new Uri[] { new Uri(baseAddress) });
            serviceHost.AddServiceEndpoint(typeof(IQuesManager), netTcpBinding, "QuesManager");
        }

        /// <summary>
        /// 服务对象
        /// </summary>
        public ServiceHost Host
        {
            get
            {
                return serviceHost;
            }
        }

        /// <summary>
        /// 打开服务
        /// </summary>
        public void Open()
        {
            serviceHost.Opening += delegate
            {
                Console.WriteLine("服务启动……");
            };
            serviceHost.Open();
            serviceHost.Opened += (a, b) =>
            {
                Console.WriteLine("启动成功");
            };
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (Host != null)
            {
                (Host as IDisposable).Dispose();
            }
        }
    }
}

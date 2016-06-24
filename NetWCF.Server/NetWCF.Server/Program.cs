using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyHelloHost host = new MyHelloHost())
            {
                host.Open();
                Console.ReadLine();
            }
        }
    }

    public class MyHelloHost : IDisposable
    {
        /// <summary>
        /// 定义一个服务对象
        /// </summary>
        private ServiceHost _myhost;
        /// <summary>
        /// 定义一个基地址
        /// </summary>
        public const string BaseAddress = "net.tcp://10.1.2.102:8083";
        /// <summary>
        /// 通讯协议
        /// </summary>
        private static NetTcpBinding netTcpBinding = new NetTcpBinding();

        public ServiceHost Myhost
        {
            get
            {
                return _myhost;
            }
        }

        public MyHelloHost()
        {
            netTcpBinding.Security.Mode = SecurityMode.None;
            _myhost = new ServiceHost(typeof(Hello), new Uri[] { new Uri(BaseAddress) });
            CreateServiceHost();
        }
        
        private void CreateServiceHost()
        {
            _myhost.AddServiceEndpoint(typeof(IHello), netTcpBinding, "Hello");
            _myhost.AddServiceEndpoint(typeof(IUser), netTcpBinding, "User");
        }

        /// <summary>
        /// 打开服务
        /// </summary>
        public void Open()
        {
            Console.WriteLine("服务启动中……");
            _myhost.Open();
            Console.WriteLine("启动成功");
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (Myhost != null)
            {
                (Myhost as IDisposable).Dispose();
            }
        }
    }
}

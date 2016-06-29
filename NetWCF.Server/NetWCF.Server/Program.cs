using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Server
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
            string ipAndPort = "192.168.187.1:8083";
            //定义一个基地址
            string baseAddress = string.Format("net.tcp://{0}", ipAndPort);
            //通讯协议
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            netTcpBinding.Security.Mode = SecurityMode.None;
            serviceHost = new ServiceHost(typeof(Hello), new Uri[] { new Uri(baseAddress) });
            serviceHost.AddServiceEndpoint(typeof(IHello), netTcpBinding, "Hello");
            serviceHost.AddServiceEndpoint(typeof(IUser), netTcpBinding, "User");
            //if (serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            //{
            //    ServiceMetadataBehavior metadata = new ServiceMetadataBehavior();
            //    metadata.HttpGetEnabled = true;
            //    metadata.HttpGetUrl = new Uri("http://192.168.187.1:8085/Hello/metadata");
            //    serviceHost.Description.Behaviors.Add(metadata);
            //}
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

    public class ICSFactory
    {
        /// <summary>
        /// 创建WCF服务代理对象
        /// </summary>
        /// <typeparam name="T">WCF的Contract类型</typeparam>
        /// <returns></returns>
        public static T Create<T>()
        {
            string contractNamespace = typeof(T).Namespace;
            string contract = typeof(T).Name;

            //根据WCF Contract信息找到相应的位置信息
            //Location location = ServiceLocator.Locate(contractNamespace, contract);

            //生成绑定信息
            NetTcpBinding binding = new NetTcpBinding();
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.Security.Mode = SecurityMode.None;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;

            //事务设置
            binding.TransactionFlow = true;
            binding.TransactionProtocol = TransactionProtocol.OleTransactions;

            //地址信息
            EndpointAddress address = null;// new EndpointAddress(location.Url);

            //建立信道
            T broker = ChannelFactory<T>.CreateChannel(binding, address);

            //返回代理对象
            return broker;
        }

        /// <summary>
        /// Dispose代理对象
        /// </summary>
        /// <param name="broker"></param>
        public static void Close(object broker)
        {
            if (broker == null)
                return;

            IDisposable disposable = broker as IDisposable;
            if (disposable == null)
                return;

            disposable.Dispose();
        }
    }
}

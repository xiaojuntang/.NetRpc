using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Client
{
    public class RPCHelloClient
    {
        private static IHello proxy = null;
        static RPCHelloClient()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            EndpointAddress tcpAddr = new EndpointAddress("net.tcp://192.168.187.1:8083/Hello");
            tcpBinding.Security.Mode = SecurityMode.None;//与服务端保持一致
            proxy = new ChannelFactory<IHello>(tcpBinding, tcpAddr).CreateChannel();
        }

        public static string Say(string name, string sex)
        {
            return proxy.SayHello(name, sex);
        }
    }
}

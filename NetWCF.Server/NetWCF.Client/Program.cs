using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Client
{
    class Program
    {
        //protected static NetWCF.Impl.IHello proxy2;
        public static System.Timers.Timer _timer = new System.Timers.Timer();
        public static int Index = 0;

        static void Main(string[] args)
        {
            //定义绑定与服务地址 
            //Binding httpBinding = new BasicHttpBinding();
            //EndpointAddress httpAddr = new EndpointAddress("http://localhost:8080/wcf");
            //利用ChannelFactory创建一个IData的代理对象，指定binding与address，而不用配置文件中的  
            //var proxy = new ChannelFactory<Server.IData>(httpBinding, httpAddr).CreateChannel();
            //调用SayHello方法并关闭连接 
            //Console.WriteLine(proxy.SayHello("WCF"));
            //((IChannel)proxy).Close();

            //try
            //{
            //    换TCP绑定试试
            //    Binding tcpBinding = new NetTcpBinding();
            //    EndpointAddress tcpAddr = new EndpointAddress("net.tcp://10.1.2.85:8083/Hello");
            //    proxy2 = new ChannelFactory<NetWCF.Impl.IHello>(tcpBinding, tcpAddr).CreateChannel();
            //    if (proxy2 == null)
            //        Console.WriteLine("异常");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //((IChannel)proxy2).Close();
            _timer.Interval = 100;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            Console.ReadLine();
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(WcfClient.SayHello("我说的是：" + Index++, Index++));
        }
    }

    public class WcfClient
    {
        private static readonly string URL = "net.tcp://10.1.2.85:8083/Hello";

        private static readonly string URL_User = "net.tcp://10.1.2.85:8083/User";
        //private static IHello proxy;
        public static IHello CreateHello()
        {
            try
            {
                NetTcpBinding tcpBinding = new NetTcpBinding();
                EndpointAddress tcpAddr = new EndpointAddress(URL);
                tcpBinding.Security.Mode = SecurityMode.None;//与服务端保持一致
                IHello proxy = new ChannelFactory<IHello>(tcpBinding, tcpAddr).CreateChannel();
                return proxy;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static IUser CreateUser()
        {
            try
            {
                NetTcpBinding tcpBinding = new NetTcpBinding();
                EndpointAddress tcpAddr = new EndpointAddress(URL_User);
                tcpBinding.Security.Mode = SecurityMode.None;//与服务端保持一致
                IUser proxy = new ChannelFactory<IUser>(tcpBinding, tcpAddr).CreateChannel();
                return proxy;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static string SayHello(string say, int index)
        {
            TestEntity e = CreateUser().GetEntity(index);
            Console.WriteLine(e.Name);
            return CreateHello().SayHello(say);
        }
    }
}

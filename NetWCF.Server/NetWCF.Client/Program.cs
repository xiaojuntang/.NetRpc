using NetWCF.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
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

            int a = 5;

            Task.Run(() =>
            {
                a = 10;
            });
            var d = "";
            //第一种方式开启
            var task1 = new Task(() =>
                     {
                         a = 9;
                     });
            task1.Start();
            var c = "";

            try
            {
                NetTcpBinding tcpBinding = new NetTcpBinding();
                EndpointAddress tcpAddr = new EndpointAddress("net.tcp://192.168.187.1:8083/Hello");
                tcpBinding.Security.Mode = SecurityMode.None;//与服务端保持一致
                IHello proxy = new ChannelFactory<IHello>(tcpBinding, tcpAddr).CreateChannel();
                int index = 1;
                for (int i = 0; i < 20000; i++)
                {
                    try
                    {
                        Task.Factory.StartNew((obj) =>
                        {
                            try
                            {


                                Console.WriteLine("第 {0} 个请求开始。。。", obj);
                                Parallel.For(0, 3, o =>
                                {
                                    RPCHelloClient.Say(index++.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                                });


                                Console.WriteLine("第 {0} 个请求结束。。。", obj);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }, i);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.Read();
            }
            catch (Exception ex)
            {
                throw;
            }

            //----------------------------------------------------------------------------------
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

            //----------------------------------------------------------------------------------


            //_timer.Interval = 100;
            //_timer.Elapsed += _timer_Elapsed;
            //_timer.Start();
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
            return "";// CreateHello().SayHello(say);
        }
    }
}

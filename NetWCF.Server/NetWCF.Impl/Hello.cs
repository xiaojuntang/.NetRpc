using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Impl
{
    public partial class Hello : IHello
    {
        public string SayHello(string name, int index, int tId)
        {
            string msg = string.Format("服务器已经收到第{0}个请求,并处理完毕。当前时间：{1} 线程ID;{2}", index, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tId);
            Console.WriteLine(msg);
            return "SayHello " + name;
        }

        public string SayHello(string name, string sex)
        {
            string msg = string.Format("服务器已经收到第{0}个请求,并处理完毕。当前时间：{1} 线程ID;{2}", name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sex);
            Console.WriteLine(msg);
            return "SayHelloSex " + name + sex;
        }
    }
}

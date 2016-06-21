using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Impl
{
    public partial class Hello : IHello
    {
        public string SayHello(string name)
        {
            Console.WriteLine("收到请求：" + name);
            return "SayHello " + name;
        }

        public string SayHello(string name, string sex)
        {
            return "SayHelloSex " + name + sex;
        }
    }
}

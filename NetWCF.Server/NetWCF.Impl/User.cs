using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Impl
{
    public partial class Hello : IUser
    {
        public TestEntity GetEntity(int ID)
        {
            TestEntity e = new TestEntity();
            e.ID = ID;
            e.Name = "姓名：" + ID;
            Console.WriteLine("用户：" + e.Name);
            return e;
        }
    }
}

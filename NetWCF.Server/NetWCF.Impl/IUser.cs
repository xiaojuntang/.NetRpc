using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NetWCF.Impl
{
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        TestEntity GetEntity(int ID);
    }
}

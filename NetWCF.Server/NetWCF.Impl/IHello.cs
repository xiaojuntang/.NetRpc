using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace NetWCF.Impl
{
    [ServiceContract]
    public interface IHello
    {
        [OperationContract]
        string SayHello(string name, int index, int tId);

        [OperationContract(Name = "SayHelloBySex")]
        string SayHello(string name, string sex);

    }
}

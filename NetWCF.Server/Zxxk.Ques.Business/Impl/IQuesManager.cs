using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zxxk.Ques.Business
{
    [ServiceContract]
    public interface IQuesManager
    {
        [OperationContract]
        string GetString(string param);
    }
}

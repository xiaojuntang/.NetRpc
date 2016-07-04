using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxxk.Ques.Core;

namespace Zxxk.Ques.Business
{
    public partial class QuesManager : IQuesManager
    {
        private static Messages _msg = null;
        static QuesManager()
        {
            _msg = new Messages();
        }

        public string GetString(string param)
        {
            _msg.ShowMessage(param, "GetString");
            return "我的测试";
        }
    }
}

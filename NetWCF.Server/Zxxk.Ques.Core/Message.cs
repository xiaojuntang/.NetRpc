using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxxk.Ques.Core
{
    public delegate void NotifyHandler(string message, string method);
    /// <summary>
    /// 消息通知类库
    /// </summary>
    public class Messages
    {
        public event NotifyHandler MsgEvent;

        public Messages()
        {
            this.MsgEvent += Messages_MsgEvent;
        }

        /// <summary>
        /// 日志显示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="method"></param>
        private void Messages_MsgEvent(string message, string method)
        {
            Console.WriteLine(message + "  My event is ok!");
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="method"></param>
        public void ShowMessage(string message, string method)
        {
            if (MsgEvent != null)
                MsgEvent(message, method);
        }
    }






    //public class EventTest
    //{
    //    // 步骤1，定义delegate对象  
    //    public delegate void MyEventHandler(object sender, System.EventArgs e);
    //    // 步骤2省略  
    //    public class MyEventCls
    //    {
    //        // 步骤3，定义事件处理方法，它与delegate对象具有相同的参数和返回值类型  
    //        public void MyEventFunc(object sender, System.EventArgs e)
    //        {
    //            Console.WriteLine("My event is ok!");
    //        }
    //    }
    //    // 步骤4，用event关键字定义事件对象  
    //    private event MyEventHandler myevent;
    //    private MyEventCls myecls;
    //    public EventTest()
    //    {
    //        myecls = new MyEventCls();
    //        // 步骤5，用+=操作符将事件添加到队列中  
    //        this.myevent += new MyEventHandler(myecls.MyEventFunc);
    //    }
    //    // 步骤6，以调用delegate的方式写事件触发函数  
    //    protected void OnMyEvent(System.EventArgs e)
    //    {
    //        if (myevent != null)
    //            myevent(this, e);
    //    }

    //    public void RaiseEvent()
    //    {
    //        EventArgs e = new EventArgs();
    //        // 步骤7，触发事件  
    //        OnMyEvent(e);
    //    }

    //    public static void Main()
    //    {
    //        EventTest et = new EventTest();
    //        Console.Write("Please input a:");
    //        string s = Console.ReadLine();
    //        if (s == "a")
    //        {
    //            et.RaiseEvent();
    //        }
    //        else
    //        {
    //            Console.WriteLine("Error");
    //        }
    //    }
    //}
}

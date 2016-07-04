using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxxk.Ques.Entites;
using Common.Net.DbProvider;

namespace Zxxk.Ques.Access
{
    public class NodeDal
    {
        public static List<HW_ZujuanNodes> GetNodesById()
        {
            SQLHelper.ExecuteScalar("", DataBase.CResourceKF);
            return new List<HW_ZujuanNodes>();
        }
    }
}

namespace Common.Net.DbProvider
{
    public enum DataBase
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 数据库一 192.168.200.103
        /// </summary>
        CResource,
        /// <summary>
        /// 数据库二 192.168.200.72
        /// </summary>
        Jg,
        /// <summary>
        /// 数据库三
        /// </summary>
        ZYTConnString,
        /// <summary>
        /// 资源线下测试数据库 192.168.180.186
        /// </summary>
        CResourceKF,

        ZYTConnString68
    }
}

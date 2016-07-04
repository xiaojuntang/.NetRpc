using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxxk.Ques.Entites
{
    /// <summary>
    /// 组卷结点对象
    /// </summary>
    public class HW_ZujuanNodes
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NodeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ParentNodeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TencentID { get; set; }
    }
}

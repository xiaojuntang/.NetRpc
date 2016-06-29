using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfBookService
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string BookNO;
        [DataMember]
        public string BookName;
        [DataMember]
        public decimal BookPrice;
    }
}

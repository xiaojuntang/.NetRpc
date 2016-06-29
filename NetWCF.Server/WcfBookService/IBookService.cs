using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfBookService
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        void AddBooks(Book book);

        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        void RemoveBook(string id);
    }
}

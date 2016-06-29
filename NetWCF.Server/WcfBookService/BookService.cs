using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfBookService
{
    //此类是对IBookService接口的具体实现，在此类的上面我们声明了[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]标签，此标签代表这个类采用SingleTone（单类模式）来生成对象。
    //使用[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 接口需要导入using System.ServiceModel;命名空间。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BookService : IBookService
    {
        List<Book> _Books = new List<Book>();
        public void AddBooks(Book book)
        {
            book.BookNO = Guid.NewGuid().ToString();
            _Books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _Books;
        }

        public void RemoveBook(string id)
        {
            Book book = _Books.Find(p => p.BookNO == id);
            _Books.Remove(book);
        }
    }
}

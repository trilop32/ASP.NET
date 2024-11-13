using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IRepository<T>:IDisposable where T : class
    {
        //public List<int> GetAll();
        //public List<int> GetById(int id);
        IEnumerable<T> GetBookList();
        T GetBook(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}

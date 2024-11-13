using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IRepositoryCustomer<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetBook(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}

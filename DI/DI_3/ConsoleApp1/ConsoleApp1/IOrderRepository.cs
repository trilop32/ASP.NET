using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IOrderRepository<T> where T : class
    {
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public T GetBook(int id)
        {
            throw new NotImplementedException();
        }
        public void Create(T item)
        {
            throw new NotImplementedException();
        }
        public void Update(T item)
        {
            throw new NotImplementedException();
        }
        public void Delete(T item)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

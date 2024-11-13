using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IRepositoryFactory
    {
        IUserrepository CreateUserRepository(string userName);
        IRepositoryCustomer CreateCustomerRepository();
        IOrderRepository CreateOrderRepository();
    }
}

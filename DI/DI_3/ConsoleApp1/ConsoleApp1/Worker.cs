using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Worker(IRepositoryCustomer repositoryCustomer,
        IOrderRepository orderRepository, IUserrepository userRepository):IWorker
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public Worker(IRepositoryFactory repositoryFactory)
        {
            repositoryFactory = repositoryFactory;
        }

        public virtual void Test()
        {
            throw new Exception("test exception");
        }
        public List<Customer> GetallCustomer()
        {
            var customers = repositoryCustomer.GetAll();
            return customers.ToList();
        }
        public List<Order> GetAllOrders()
        {
            var orders = orderRepository.GetList();
            return orders.ToList();
        }
        public List<User> GetAllUsers()
        {
            var users = userRepository.Get.List();
            return users.ToList();
        }
    }
}

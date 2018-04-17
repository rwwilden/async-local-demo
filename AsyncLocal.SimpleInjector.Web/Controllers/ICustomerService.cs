using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncLocal.SimpleInjector.Web.Controllers
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(int customerId);
    }

    public class Customer
    {
        public string Name { get; set; } = "John Doe";

        public int Age { get; set; } = 42;
    }
}
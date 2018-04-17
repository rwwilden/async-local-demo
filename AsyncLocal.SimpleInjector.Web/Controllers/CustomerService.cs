using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncLocal.SimpleInjector.Web.Controllers
{
    public class CustomerService : ICustomerService
    {
        private readonly CorrelationContainer _correlationContainer;

        public CustomerService(CorrelationContainer correlationContainer)
        {
            _correlationContainer = correlationContainer;
        }

        public Task<IEnumerable<string>> GetCustomerTags(int customerId)
        {
            return Task.FromResult(new[] { "elm", "is", "cool" }.AsEnumerable());
        }
    }
}
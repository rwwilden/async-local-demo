using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncLocal.SimpleInjector.Web.Controllers
{
    public interface ICustomerService
    {
        Task<IEnumerable<string>> GetCustomerTags(int customerId);
    }
}
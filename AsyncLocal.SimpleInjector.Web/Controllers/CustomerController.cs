using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncLocal.SimpleInjector.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly CorrelationContainer _correlationContainer;

        public CustomerController(ICustomerService customerService, CorrelationContainer correlationContainer)
        {
            _customerService = customerService;
            _correlationContainer = correlationContainer;
        }

        [HttpGet]
        public async Task<Customer> Get(int id)
        {
            // Set async local correlation id.
            var correlationId = Guid.NewGuid();
            _correlationContainer.SetCorrelationId(correlationId);

            // Call controller dependency (decorated by LoggingDecorator).
            var customer = await _customerService.GetCustomer(id);

            // Return values.
            return customer;
        }
    }
}

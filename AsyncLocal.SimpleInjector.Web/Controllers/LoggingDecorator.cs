using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AsyncLocal.SimpleInjector.Web.Controllers
{
    public class LoggingDecorator : ICustomerService
    {
        private readonly Func<ICustomerService> _decorateeFunc;
        private readonly ILogger<CustomerService> _logger;
        private readonly CorrelationContainer _correlationContainer;

        public LoggingDecorator(
            Func<ICustomerService> decorateeFunc,
            ILogger<CustomerService> logger,
            CorrelationContainer correlationContainer)
        {
            _decorateeFunc = decorateeFunc;
            _logger = logger;
            _correlationContainer = correlationContainer;
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            // Get async local correlation id and log.
            var correlationIdBeforeAwait = _correlationContainer.GetCorrelationId();
            _logger.LogWarning($"Getting customer by id {customerId} ({correlationIdBeforeAwait})");

            // Call decoratee.
            var decoratee = _decorateeFunc.Invoke();
            var customer = await decoratee.GetCustomer(customerId);

            // For demo purposes: get correlation id again after await and log.
            var correlationIdAfterAwait = _correlationContainer.GetCorrelationId();
            _logger.LogWarning($"Retrieved customer by id {customerId} ({correlationIdBeforeAwait})");

            // Return values.
            return customer;
        }
    }
}
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

        public async Task<IEnumerable<string>> GetCustomerTags(int customerId)
        {
            // Get async local correlation id.
            var correlationId = _correlationContainer.GetCorrelationId();
            _logger.LogWarning($"Getting customer tags for {customerId} ({correlationId})");

            // Call decoratee.
            var decoratee = _decorateeFunc.Invoke();
            var values = await decoratee.GetCustomerTags(customerId);

            // Return values.
            return values;
        }
    }
}
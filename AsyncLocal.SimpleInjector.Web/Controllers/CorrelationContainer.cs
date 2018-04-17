using System;
using System.Threading;

namespace AsyncLocal.SimpleInjector.Web.Controllers
{
    public class CorrelationContainer
    {
        private readonly AsyncLocal<Guid> _correlationId = new AsyncLocal<Guid>();

        public void SetCorrelationId(Guid correlationId)
        {
            _correlationId.Value = correlationId;
        }

        public Guid GetCorrelationId()
        {
            return _correlationId.Value;
        }
    }
}
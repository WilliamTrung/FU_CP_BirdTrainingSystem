using AdviceConsultingSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.HostedService.Implementation
{
    public class ConsultingTicketHostedService : IConsultingTicketHostedService
    {
        private bool disposedValue;
        private readonly IAdviceConsultingFeature _consultingTicket;
        public ConsultingTicketHostedService (IAdviceConsultingFeature consultingTicket)
        {
            _consultingTicket = consultingTicket;
        }
        public async Task CheckOutDateTicket()
        {
            await _consultingTicket.Other.CheckOutDateTicket();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~WorkshopHostedService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

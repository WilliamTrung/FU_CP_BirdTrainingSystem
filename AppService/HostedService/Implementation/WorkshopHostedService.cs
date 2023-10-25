using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopSubsystem;

namespace AppService.HostedService.Implementation
{
    public class WorkshopHostedService : IWorkshopHostedService
    {
        private bool disposedValue;
        private readonly IWorkshopFeature _workshop;
        public WorkshopHostedService(IWorkshopFeature workshop)
        {
            _workshop = workshop;
        }
        public async Task CheckCompleteClasses()
        {
            await _workshop.All.SetWorkshopClassComplete();
        }

        public async Task CheckExceedRegistrationTime()
        {
            await _workshop.All.SetWorkshopClassExceedRegistration();
        }

        public async Task CheckOpenClasses()
        {
            await _workshop.All.SetWorkshopClassOngoing();
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

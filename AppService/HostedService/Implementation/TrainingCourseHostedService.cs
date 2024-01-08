using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCourseSubsystem;

namespace AppService.HostedService.Implementation
{
    public class TrainingCourseHostedService : ITrainingCourseHostedService
    {
        private bool disposedValue;
        private readonly ITrainingCourseFeature _trainingCourse;

        public TrainingCourseHostedService(ITrainingCourseFeature trainingCourse)
        {
            _trainingCourse = trainingCourse;
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

        public async Task LateMarkTrainingSlot()
        {
            await _trainingCourse.All.SetLateTrainingSlotAbsent();
        }
    }
}

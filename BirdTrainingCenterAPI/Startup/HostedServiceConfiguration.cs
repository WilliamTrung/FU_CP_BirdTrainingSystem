using AppService.HostedService;

namespace BirdTrainingCenterAPI.Startup
{
    public static class HostedServiceConfiguration
    {
        public static void AddWorkshopHostedService(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IWorkshopHostedService, IWorkshopHostedService>();
            builder.Services.AddHostedService<WorkshopBackgroundService>();
        }
    }
}

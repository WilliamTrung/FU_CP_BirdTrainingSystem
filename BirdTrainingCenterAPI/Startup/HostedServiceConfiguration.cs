using AppService.HostedService;
using AppService.HostedService.Implementation;

namespace BirdTrainingCenterAPI.Startup
{
    public static class HostedServiceConfiguration
    {
        public static void AddWorkshopHostedService(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IWorkshopHostedService, WorkshopHostedService>();
            builder.Services.AddHostedService<WorkshopBackgroundService>();
        }

        public static void AddConsulitngTicketHostedService(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IConsultingTicketHostedService, ConsultingTicketHostedService>();
            builder.Services.AddHostedService<ConsultingTicketBackgroundService>();
        }
    }
}

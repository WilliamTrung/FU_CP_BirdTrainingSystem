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

        public static void AddConsulitngTicketHostedService(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IConsultingTicketHostedService, IConsultingTicketHostedService>();
            builder.Services.AddHostedService<ConsultingTicketBackgroundService>();
        }
    }
}

using AppService.WorkshopService;
using AppService.TimetableService;
using WorkshopSubsystem.Implementation;
using WorkshopSubsystem;
using TimetableSubsystem;
using TimetableSubsystem.Implementation;
using AppRepository.UnitOfWork;

namespace BirdTrainingCenterAPI.Startup
{
    public static class SubsystemConfiguration
    {
        public static void AddUOW(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static void AddWorkshopFeature(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IFeatureAll, FeatureAll>();
            builder.Services.AddTransient<IFeatureStaff, FeatureStaff>();
            builder.Services.AddTransient<IFeatureManager, FeatureManager>();
            builder.Services.AddTransient<IFeatureCustomer, FeatureCustomer>();
            builder.Services.AddTransient<IFeatureTrainer, FeatureTrainer>();
            builder.Services.AddTransient<IWorkshopFeature, WorkshopFeature>();
            
            builder.Services.AddTransient<AppService.WorkshopService.IServiceAll, AppService.WorkshopService.Implementation.AllService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceCustomer, AppService.WorkshopService.Implementation.CustomerService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceManager, AppService.WorkshopService.Implementation.ManagerService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceStaff, AppService.WorkshopService.Implementation.StaffService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceTrainer, AppService.WorkshopService.Implementation.TrainerService>();
            builder.Services.AddTransient<IWorkshopService, WorkshopService>();
        }
        public static void AddTimetableFeature(this WebApplicationBuilder builder)
        {

            builder.Services.AddTransient<ITimetableFeature, TimetableFeature>();
            builder.Services.AddTransient<AppService.TimetableService.IServiceAll, AppService.TimetableService.Implementation.ServiceAll>();
            //builder.Services.AddTransient<AppService.TimetableService.IServiceCustomer, AppService.WorkshopService.Implementation.CustomerService>();
            builder.Services.AddTransient<AppService.TimetableService.IServiceManager, AppService.TimetableService.Implementation.ServiceManager>();
            builder.Services.AddTransient<AppService.TimetableService.IServiceStaff, AppService.TimetableService.Implementation.ServiceStaff>();
            builder.Services.AddTransient<AppService.TimetableService.IServiceTrainer, AppService.TimetableService.Implementation.ServiceTrainer>();
            builder.Services.AddTransient<ITimetableService, TimetableService>();
        }
    }
}

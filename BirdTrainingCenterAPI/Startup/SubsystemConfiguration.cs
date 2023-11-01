﻿using AppService.WorkshopService;
using AppService.TimetableService;
using WorkshopSubsystem.Implementation;
using WorkshopSubsystem;
using TimetableSubsystem;
using TimetableSubsystem.Implementation;
using AppRepository.UnitOfWork;
using TransactionSubsystem;
using TransactionSubsystem.Implementation;
using AppService.TrainingCourseService;
using TrainingCourseSubsystem;
using TrainingCourseSubsystem.Implementation;

namespace BirdTrainingCenterAPI.Startup
{
    public static class SubsystemConfiguration
    {
        public static void AddUOW(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static void AddTrainingCourseFeature(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<TrainingCourseSubsystem.IFeatureTrainer, TrainingCourseSubsystem.Implementation.FeatureTrainer>();
            builder.Services.AddTransient<TrainingCourseSubsystem.IFeatureStaff, TrainingCourseSubsystem.Implementation.FeatureStaff> ();
            builder.Services.AddTransient<TrainingCourseSubsystem.IFeatureManager, TrainingCourseSubsystem.Implementation.FeatureManager>();
            builder.Services.AddTransient<TrainingCourseSubsystem.IFeatureCustomer, TrainingCourseSubsystem.Implementation.FeatureCustomer>();
            builder.Services.AddTransient<TrainingCourseSubsystem.ITrainingCourseFeature, TrainingCourseSubsystem.Implementation.TrainingCourseFeature>();

            builder.Services.AddTransient<AppService.TrainingCourseService.IServiceTrainer, AppService.TrainingCourseService.Implement.ServiceTrainer>();
            builder.Services.AddTransient<AppService.TrainingCourseService.IServiceCustomer, AppService.TrainingCourseService.Implement.ServiceCustomer>();
            builder.Services.AddTransient<AppService.TrainingCourseService.IServiceStaff, AppService.TrainingCourseService.Implement.ServiceStaff>();
            builder.Services.AddTransient<AppService.TrainingCourseService.IServiceManager, AppService.TrainingCourseService.Implement.ServiceManager>();

            builder.Services.AddTransient<ITrainingCourseService, AppService.TrainingCourseService.TrainingCourse>();
        }
        public static void AddWorkshopFeature(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<WorkshopSubsystem.IFeatureAll, WorkshopSubsystem.Implementation.FeatureAll>();
            builder.Services.AddTransient<WorkshopSubsystem.IFeatureStaff, WorkshopSubsystem.Implementation.FeatureStaff>();
            builder.Services.AddTransient<WorkshopSubsystem.IFeatureManager, WorkshopSubsystem.Implementation.FeatureManager>();
            builder.Services.AddTransient<WorkshopSubsystem.IFeatureCustomer, WorkshopSubsystem.Implementation.FeatureCustomer>();
            builder.Services.AddTransient<WorkshopSubsystem.IFeatureTrainer, WorkshopSubsystem.Implementation.FeatureTrainer>();
            builder.Services.AddTransient<WorkshopSubsystem.IWorkshopFeature, WorkshopSubsystem.Implementation.WorkshopFeature>();
            
            builder.Services.AddTransient<AppService.WorkshopService.IServiceAll, AppService.WorkshopService.Implementation.AllService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceCustomer, AppService.WorkshopService.Implementation.CustomerService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceManager, AppService.WorkshopService.Implementation.ManagerService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceStaff, AppService.WorkshopService.Implementation.StaffService>();
            builder.Services.AddTransient<AppService.WorkshopService.IServiceTrainer, AppService.WorkshopService.Implementation.TrainerService>();
            builder.Services.AddTransient<IWorkshopService, WorkshopService>();
            builder.Services.AddTransient<IFeatureTransaction, FeatureTransaction>();
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

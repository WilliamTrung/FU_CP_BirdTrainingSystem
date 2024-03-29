﻿
using AppService.Implementation;
using AppService;
using AuthSubsystem.Implementation;
using AuthSubsystem;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Models.ConfigModels;
using ApplicationService.MailSettings;
using AppCore.Context;
using TEST_CERTSAMPLE;
using Microsoft.EntityFrameworkCore;

namespace BirdTrainingCenterAPI.Startup
{
    public static class ServiceConfiguration
    {
        public static void ConfiguringBusinessRules(this WebApplicationBuilder builder)
        {
            //builder.Services.Configure<BR_WorkshopConstant>(option =>
            //{
            //    option.StartDateDeadlineAfterRegistrationEnd = Int32.Parse(builder.Configuration.GetSection("BusinessRuleSet")["StartDateDeadlineAfterRegistrationEnd"]);
            //});
        }
        public static void ConfiguringServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAuthFeature, AuthFeature>();
            //Add services
            var connectionData = builder.Configuration.GetRequiredSection("ConnectionData");
            builder.Services.AddDbContext<BirdTrainingCenterSystemContext>(opt =>
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                opt.UseNpgsql($"Server={connectionData["Server"]};Port={connectionData["Port"]};Database={connectionData["Database"]};User Id={connectionData["UID"]};Password={connectionData["Password"]};SSL Mode=Require;Trust Server Certificate=True;");
            });
            builder.Services.AddSingleton(_ =>
            {
                var credential = GoogleCredential.FromFile("birdtrainingcentersystem-firebase-adminsdk-9yolt-2b38d5f11c.json");
                return StorageClient.Create(credential);
            });
            builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("MailSettings"));
            builder.Services.Configure<CenterGeocode>(config =>
            {
                config.Latitude = Double.Parse(builder.Configuration.GetRequiredSection("CenterGeocode")["Latitude"]);
                config.Longitude = Double.Parse(builder.Configuration.GetRequiredSection("CenterGeocode")["Longtitude"]);
            });
            builder.Services.Configure<GoogleConfig>(config =>
            {
                config.API_KEY = builder.Configuration.GetRequiredSection("GoogleConfig")["ApiKey"];
                config.SEARCH_ENGINE_ID = builder.Configuration.GetRequiredSection("GoogleConfig")["SearchEngineId"];
                config.CLIENT_SECRET = builder.Configuration.GetRequiredSection("GoogleConfig")["ClientSecret"];
                config.CLIENT_ID = builder.Configuration.GetRequiredSection("GoogleConfig")["ClientId"];
            });
            builder.Services.Configure<FirebaseConfig>(options =>
            {
                options.Storage = builder.Configuration.GetRequiredSection("Firebase")["Storage"];

            });
            builder.Services.Configure<FirebaseBucket>(options =>
            {
                options.General = builder.Configuration.GetRequiredSection("Firebase")["GeneralBucket"];
            });
            builder.Services.AddTransient<IGoogleMapService, GoogleMapService>();
            builder.Services.AddTransient<IFirebaseService, FirebaseService>();
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IMailService, MailService>();
            builder.Services.AddSingleton<IPdfGenerator, PdfGenerator>();
        }
        public static void ConfiguringCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}

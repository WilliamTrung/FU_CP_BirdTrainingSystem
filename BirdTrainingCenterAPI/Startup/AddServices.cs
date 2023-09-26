
using AppService.Implementation;
using AppService;
using AuthSubsystem.Implementation;
using AuthSubsystem;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Models.ConfigModels;

namespace BirdTrainingCenterAPI.Startup
{
    public class AddServices
    {
        public static void ConfiguringServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAuthFeature, AuthFeature>();
            //Add services

            builder.Services.AddSingleton(_ =>
            {
                var credential = GoogleCredential.FromFile("birdtrainingcentersystem-firebase-adminsdk-9yolt-2b38d5f11c.json");
                return StorageClient.Create(credential);
            });
            builder.Services.Configure<FirebaseConfig>(options =>
            {
                options.Storage = builder.Configuration.GetRequiredSection("Firebase")["Storage"];

            });
            builder.Services.Configure<FirebaseBucket>(options =>
            {
                options.General = builder.Configuration.GetRequiredSection("Firebase")["GeneralBucket"];
            });

            builder.Services.AddTransient<IFirebaseService, FirebaseService>();
            builder.Services.AddTransient<IAuthService, AuthService>();
        }
        public static void ConfiguringCors(WebApplicationBuilder builder)
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

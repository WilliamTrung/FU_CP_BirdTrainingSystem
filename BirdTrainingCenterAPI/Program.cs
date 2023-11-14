using AppService;
using AppService.Implementation;
using AuthSubsystem;
using Microsoft.AspNetCore.Builder;
using AuthSubsystem.Implementation;
using BirdTrainingCenterAPI.Startup;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using GoogleApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Models.ConfigModels;
using SP_Middleware.CustomJsonConverter;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(null)
        )
    .AddJsonOptions
               (
                   x =>
                   {
                       x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                       x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                       x.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
                       x.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.ConsultingTicket.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Workshop.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Workshop.Class.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.EntityType>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Role>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Customer.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Trainer.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.BirdTrainingProgress.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.BirdTrainingCourse.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.BirdTrainingReport.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Trainer.Category>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.OnlineCourse.Customer.OnlineCourse.Status>());
                       x.JsonSerializerOptions.Converters.Add(new StringEnumConverter<Models.Enum.Workshop.Class.Customer.Status>());
                   }
               );

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(SP_AutoMapperConfig.SP_AutoMapperAssembly)));
builder.Services.AddGoogleApiClients();

builder.WebHost.ConfigureKestrel(options => {
    options.Limits.MaxRequestBodySize = 524288000; // 500 MB
});
//builder.WebHost.UseUrls("http://localhost:5000");
//Add service
builder.JwtConfiguration();
builder.ConfiguringServices();
builder.ConfiguringCors();
builder.AddUOW();
builder.AddTimetableFeature();
builder.AddWorkshopFeature();
builder.AddAdministrativeFeature();
builder.AddTrainingCourseFeature();
builder.AddAdviceConsultinFeature();
builder.AddOnlineCourseFeature();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
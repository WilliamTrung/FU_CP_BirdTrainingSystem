using AppService;
using AppService.Implementation;
using AuthSubsystem;
using AuthSubsystem.Implementation;
using BirdTrainingCenterAPI.Startup;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Models.ConfigModels;
using System.Reflection;
using System.Text.Json.Serialization;

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
                   }
               );

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(SP_AutoMapperConfig.SP_AutoMapperAssembly)));
//Add json

//Add service
AddServices.ConfiguringServices(builder);
AddServices.ConfiguringCors(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopSubsystem;

namespace AppService.HostedService
{
    public class WorkshopBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public WorkshopBackgroundService(IServiceScopeFactory scopeFactory)
        {
            Console.WriteLine("Init workshop background service");
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var _tasks = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IWorkshopHostedService>())
                {
                    //await _tasks.CheckOpenClasses();
                    await _tasks.CheckCompleteClasses();
                    //await _tasks.CheckExceedRegistrationTime();
                    await _tasks.LateCheckAttendance();
                    //await _tasks.CheckFullClass();
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}

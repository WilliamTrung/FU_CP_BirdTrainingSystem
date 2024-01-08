using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.HostedService
{
    public class TrainingCourseBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TrainingCourseBackgroundService(IServiceScopeFactory scopeFactory)
        {
            Console.WriteLine("Init training course background service");
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var _tasks = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ITrainingCourseHostedService>())
                {
                    await _tasks.LateMarkTrainingSlot();
                }
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}

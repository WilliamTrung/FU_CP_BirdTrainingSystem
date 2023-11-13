using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.HostedService
{
    public class ConsultingTicketBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ConsultingTicketBackgroundService(IServiceScopeFactory scopeFactory)
        {
            Console.WriteLine("Init consulting ticket background service");
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var _tasks = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IConsultingTicketHostedService>())
                {
                    await _tasks.CheckOutDateTicket();
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}

using case_study.Repositories;
using case_study.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace case_study
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<ICustomerRepository, CustomerRepository>();
                    services.AddScoped<IAccountRepository, AccountRepository>();
                    services.AddScoped<ICustomerService, CustomerService>();
                    services.AddScoped<IAccountService, AccountService>();
                    services.AddScoped<ITransferService, TransferService>();
                    services.AddScoped<IMessageQueuePublisher, MessageQueuePublisher>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

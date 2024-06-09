using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using case_study.Repositories;
using case_study.Services;

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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Register your repositories and services here
                    services.AddSingleton<ICustomerRepository, CustomerRepository>();
                    services.AddSingleton<IAccountRepository, AccountRepository>();
                    services.AddSingleton<ICustomerService, CustomerService>();
                    services.AddSingleton<IAccountService, AccountService>();
                    services.AddSingleton<IMessageQueuePublisher, MessageQueuePublisher>(); // If using a message queue
                });
    }
}

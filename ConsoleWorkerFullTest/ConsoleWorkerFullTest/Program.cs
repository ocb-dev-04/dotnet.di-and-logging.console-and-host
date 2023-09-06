using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ConsoleWorkerFullTest.Context;
using ConsoleWorkerFullTest.Services;
using ConsoleWorkerFullTest.Repositoties;

namespace ConsoleWorkerFullTest;

// ********************* using generic console *****************************

/// <summary>
/// Example with generic console
/// </summary>
class Program
{
    #region Injections

    //IConfigurationRoot configuration = new ConfigurationBuilder()
    //     .SetBasePath(Directory.GetCurrentDirectory())
    //     .AddJsonFile($"appsettings.json", false, false)
    //     .AddEnvironmentVariables()
    //     .Build();

    private static readonly ServiceProvider _serviceProvider
                = new ServiceCollection()
                .AddSingleton<IConfiguration>(new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json", false, false)
                     .AddEnvironmentVariables()
                     .Build()
                 )
                .AddTransient<Program>()
                .AddTransient<IStart, Start>()
                .AddTransient<IRepo, Repo>()
                .AddTransient<IServiceRepo, ServiceRepo>()
                .AddTransient<IDatabaseServices, DatabaseServices>()
                .AddLogging(configure =>
                    configure.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                        .AddConsole()
                )
                .AddDbContext<AppDbContext>(o =>
                {
                    o.UseSqlServer("Server=.;Database=test_database;Trusted_Connection=True;TrustServerCertificate=True;");
                })
                .BuildServiceProvider();

    #endregion

    static void Main()
        => _serviceProvider.GetRequiredService<IStart>().Run();
}

// ************************** using worker *********************************

/// <summary>
/// Example with generic console
/// </summary>
//class Program
//{
//string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//IConfigurationRoot configuration = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile($"appsettings.json", false,false)
//     .AddEnvironmentVariables()
//     .AddCommandLine(args)
//     .Build();

//IHostBuilder host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices((_, services) =>
//    {
//        services.AddSingleton<IConfiguration>(configuration);
//        services.AddTransient<Worker>();
//        services.AddHostedService<Worker>();
//    })
//    .ConfigureLogging((_, logging) =>
//    {
//        logging.ClearProviders();
//        logging.AddSimpleConsole(options => options.IncludeScopes = true);
//        logging.AddEventLog();
//    });
//    //.ConfigureServices((hostContext, services) =>
//    //{
//    //});
//    //.ConfigureHostConfiguration(options =>
//    //    options
//    //        .SetBasePath(Directory.GetCurrentDirectory())
//    //        .AddJsonFile("appsettings.json", false, false)
//    //        .AddEnvironmentVariables()
//    //);

//IHost builder = host.Build();
//await builder.RunAsync();
//}
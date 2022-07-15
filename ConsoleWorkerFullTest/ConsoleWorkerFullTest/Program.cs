using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ConsoleWorkerFullTest;

string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

IConfigurationRoot configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json", false,false)
     .AddEnvironmentVariables()
     .AddCommandLine(args)
     .Build();

IHostBuilder host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddTransient<Worker>();
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging((_, logging) =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(options => options.IncludeScopes = true);
        logging.AddEventLog();
    });
    //.ConfigureServices((hostContext, services) =>
    //{
    //});
    //.ConfigureHostConfiguration(options =>
    //    options
    //        .SetBasePath(Directory.GetCurrentDirectory())
    //        .AddJsonFile("appsettings.json", false, false)
    //        .AddEnvironmentVariables()
    //);

IHost builder = host.Build();
await builder.RunAsync();

/// <summary>
/// Example with generic console
/// </summary>
//class Program
//{
//    #region Injections

//    private static readonly ServiceProvider _serviceProvider
//                = new ServiceCollection()
//                .AddTransient<Program>()
//                .AddTransient<IRepo, Repo>()
//                .AddTransient<IServiceRepo, ServiceRepo>()
//                .AddLogging(configure =>
//                    configure.AddFilter("Microsoft", LogLevel.Warning)
//                        .AddFilter("System", LogLevel.Warning)
//                        .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
//                        .AddConsole()
//                )
//                .BuildServiceProvider();

//    #endregion

//    #region Ctor

//    private readonly IServiceRepo _serviceRepo;

//    public Program(IServiceRepo serviceRepo)
//    {
//        _serviceRepo = serviceRepo ?? throw new ArgumentNullException(nameof(serviceRepo));
//    }

//    #endregion

//    static void Main()
//        => _serviceProvider.GetRequiredService<IServiceRepo>().ShowMessage();
//}
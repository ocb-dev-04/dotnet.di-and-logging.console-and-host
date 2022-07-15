using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using ConsoleWorkerFullTest;

using IHost host = CreateHostBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<Worker>();
    })
    .ConfigureLogging((_, logging) =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(options => options.IncludeScopes = true);
        logging.AddEventLog();
    });



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
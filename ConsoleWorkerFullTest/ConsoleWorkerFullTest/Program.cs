using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleWorkerFullTest;

class Program
{
    #region Injections

    private static readonly ServiceProvider _serviceProvider
                = new ServiceCollection()
                .AddTransient<Program>()
                .AddTransient<IRepo, Repo>()
                .AddTransient<IServiceRepo, ServiceRepo>()
                .AddLogging(configure =>
                    configure.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                        .AddConsole()
                )
                .BuildServiceProvider();

    #endregion

    #region Ctor

    private readonly IServiceRepo _serviceRepo;

    public Program(IServiceRepo serviceRepo)
    {
        _serviceRepo = serviceRepo ?? throw new ArgumentNullException(nameof(serviceRepo));
    }

    #endregion

    static void Main()
        => _serviceProvider.GetRequiredService<IServiceRepo>().ShowMessage();
}
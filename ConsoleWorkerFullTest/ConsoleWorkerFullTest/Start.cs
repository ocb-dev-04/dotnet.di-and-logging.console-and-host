using ConsoleWorkerFullTest.Services;
using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest;

public class Start : IStart
{
    #region Ctor

    private readonly IExampleService _serviceRepo;
    private readonly IDatabaseServices _databaseServices;
    private readonly ILogger<Start> _logger;

    public Start(
        IExampleService serviceRepo,
        IDatabaseServices databaseServices,
        ILogger<Start> logger)
    {
        _serviceRepo = serviceRepo ?? throw new ArgumentNullException(nameof(serviceRepo));
        _databaseServices = databaseServices ?? throw new ArgumentNullException(nameof(databaseServices));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    void IStart.Run()
    {
        try
        {
            _databaseServices.HandleMigrations();
            _databaseServices.CreateAndQueries();
            _serviceRepo.ShowMessage();
        }
        catch (Exception e)
        {
            _logger.LogError($"Some error ocurred: {e.ToString()}");
        }
    }
}

public interface IStart
{
    void Run();
}
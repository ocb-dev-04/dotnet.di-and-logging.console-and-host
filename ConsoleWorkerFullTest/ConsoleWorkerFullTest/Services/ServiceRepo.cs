using ConsoleWorkerFullTest.Repositoties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest.Services;

public sealed class ServiceRepo : IServiceRepo
{
    #region Props & Ctor

    private readonly IRepo _repo;
    private readonly ILogger<ServiceRepo> _logger;
    private readonly IConfiguration _configuration;

    public ServiceRepo(
        IRepo repo,
        ILogger<ServiceRepo> logger,
        IConfiguration configuration)
    {
        _repo = repo;
        _logger = logger;
        _configuration = configuration;
    }

    #endregion

    public void ShowMessage()
    {
        string prodConString = _configuration.GetConnectionString("Prod").ToString();
        _logger.LogWarning($"Prod Connection String -> {prodConString}");

        _logger.LogWarning($"Ejecute method {nameof(ShowMessage)} into {nameof(ServiceRepo)}");
        _repo.ShowMessage();
    }
}

public interface IServiceRepo
{
    void ShowMessage();
}

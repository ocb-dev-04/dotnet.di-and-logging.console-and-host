using ConsoleWorkerFullTest.Repositoties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest.Services;

public sealed class ExampleService : IExampleService
{
    #region Props & Ctor

    private readonly IExampleRepo _repo;
    private readonly ILogger<ExampleService> _logger;
    private readonly IConfiguration _configuration;

    public ExampleService(
        IExampleRepo repo,
        ILogger<ExampleService> logger,
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

        _logger.LogWarning($"Ejecute method {nameof(ShowMessage)} into {nameof(ExampleService)}");
        _repo.ShowMessage();
    }
}

public interface IExampleService
{
    void ShowMessage();
}

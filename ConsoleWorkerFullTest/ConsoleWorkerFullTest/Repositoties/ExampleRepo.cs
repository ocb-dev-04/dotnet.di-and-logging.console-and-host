using ConsoleWorkerFullTest.Context;
using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest.Repositoties;

public sealed class ExampleRepo : IExampleRepo
{
    #region Props & Ctor

    private readonly ILogger<ExampleRepo> _logger;
    private readonly AppDbContext _appDbContext;

    public ExampleRepo(
        ILogger<ExampleRepo> logger,
        AppDbContext context)
    {
        _logger = logger;
        _appDbContext = context;
    }

    #endregion

    public void ShowMessage()
    {
        _logger.LogInformation($"Hello from --> {nameof(ExampleRepo)} ejecuting {nameof(ShowMessage)} method");
    }
}

public interface IExampleRepo
{
    void ShowMessage();
}

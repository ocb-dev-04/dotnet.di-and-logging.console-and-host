using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest;

public sealed class Repo : IRepo
{
    #region Props & Ctor
    
    private readonly ILogger<ServiceRepo> _logger;

    public Repo(ILogger<ServiceRepo> logger)
    {
        _logger = logger;
    }

    #endregion

    public void ShowMessage()
    {
        _logger.LogInformation($"Hello from --> {nameof(Repo)} ejecuting {nameof(ShowMessage)} method");
    }
}

public interface IRepo
{
    void ShowMessage();
}

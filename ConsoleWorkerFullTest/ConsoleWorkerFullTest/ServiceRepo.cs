using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest;

public sealed class ServiceRepo : IServiceRepo
{
    #region Props & Ctor

    private readonly IRepo _repo;
    private readonly ILogger<ServiceRepo> _logger;
    
    public ServiceRepo(
        IRepo repo,
        ILogger<ServiceRepo> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #endregion
    
    public void ShowMessage()
    {
        _logger.LogWarning($"Ejecute method {nameof(ShowMessage)} into {nameof(ServiceRepo)}");
        _repo.ShowMessage();
    }
}

public interface IServiceRepo
{
    void ShowMessage();
}

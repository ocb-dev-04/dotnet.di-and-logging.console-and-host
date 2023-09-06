using ConsoleWorkerFullTest.Context;
using ConsoleWorkerFullTest.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ConsoleWorkerFullTest.Repositoties;

public sealed class Repo : IRepo
{
    #region Props & Ctor

    private readonly ILogger<ServiceRepo> _logger;
    private readonly AppDbContext _appDbContext;

    public Repo(
        ILogger<ServiceRepo> logger,
        AppDbContext context)
    {
        _logger = logger;
        _appDbContext = context;
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

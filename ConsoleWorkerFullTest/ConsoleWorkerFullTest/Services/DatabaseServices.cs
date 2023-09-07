using ConsoleWorkerFullTest.Context;
using ConsoleWorkerFullTest.Dto;
using ConsoleWorkerFullTest.Entities;
using ConsoleWorkerFullTest.Repositoties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWorkerFullTest.Services;

public sealed class DatabaseServices : IDatabaseServices
{
    private readonly IDatabaseRepo _databaseRepo;
    private readonly ILogger<DatabaseServices> _logger;

    public DatabaseServices(
        IDatabaseRepo databaseRepo,
        ILogger<DatabaseServices> logger)
    {
        _databaseRepo = databaseRepo ?? throw new ArgumentNullException(nameof(databaseRepo));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateAndQueries()
    {
        Profile newProfile = new Profile("Oscar", 26, "oscarchb04@gmail.com");
        _databaseRepo.Create(newProfile);

        IEnumerable<ProfileDto> dtoCollection = _databaseRepo.Get();
        _logger.LogInformation("--> All done");
    }

    public void HandleMigrations()
        => _databaseRepo.HandleMigrations();
}

public interface IDatabaseServices
{
    void HandleMigrations();

    void CreateAndQueries();
}
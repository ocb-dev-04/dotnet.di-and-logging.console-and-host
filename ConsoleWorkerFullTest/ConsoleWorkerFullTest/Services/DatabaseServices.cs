using ConsoleWorkerFullTest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWorkerFullTest.Services;

public sealed class DatabaseServices : IDatabaseServices
{
    private readonly AppDbContext _appDbContext;
    public DatabaseServices(AppDbContext context)
    {
        _appDbContext = context;
    }

    public void HandleMigrations()
    {
        DatabaseFacade? database = _appDbContext.Database;
        bool connect = database.CanConnect();
        if (!connect) throw new Exception("Cannot connect to database");

        bool pending = database.GetPendingMigrations().Any();
        if (!pending) return;
    }
}

public interface IDatabaseServices
{
    void HandleMigrations();
}
using ConsoleWorkerFullTest.Dto;
using ConsoleWorkerFullTest.Context;
using ConsoleWorkerFullTest.Mappers;
using ConsoleWorkerFullTest.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ConsoleWorkerFullTest.Repositoties;

public sealed class DatabaseRepo : IDatabaseRepo
{
    private readonly AppDbContext _context;

    public DatabaseRepo(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<ProfileDto> Get()
    {
        IEnumerable<ProfileDto>? collection = _context.Profiles
            .TagWith("--> Using specific select projection")
            .Select(s => ProfileDto.Create(s.Id, s.Email))
            .ToList();

        return collection;
    }

    public ProfileDto GetSingle(Guid id)
    {
        Profile? found = _context.Profiles.FirstOrDefault(f => f.Id.Equals(id));
        if (found is null)
            throw new ArgumentNullException(nameof(found));

        return ProfileDto.FromEntity(found);
    }

    public void Create(Profile profile)
    {
        _context.Add(profile);
        _context.SaveChanges();
    }

    public void HandleMigrations()
    {
        DatabaseFacade? database = _context.Database;
        bool pending = database.GetPendingMigrations().Any();
        if (!pending) return;

        database.Migrate();
    }
}

public interface IDatabaseRepo
{
   void  HandleMigrations();
    IEnumerable<ProfileDto> Get();
    void Create(Profile profile);
}
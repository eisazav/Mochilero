using Domain.HikerElement.Entities;
using Domain.Hiker.Entities;
using Infrastructure.Repositories.DbContext.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DbContext;

public class HikerDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public HikerDbContext(DbContextOptions<HikerDbContext> options)
        : base(options)
    {
    }

    public DbSet<HikerElement> HikerElements { get;set; }
    public DbSet<Hiker> Hiker{ get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.MapHikerElement();
        modelBuilder.MapHiker();
    }


}
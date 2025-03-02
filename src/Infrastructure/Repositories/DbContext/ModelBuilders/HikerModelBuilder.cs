using Domain.Hiker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DbContext.ModelBuilders;

public static class HikerModelBuilder
{
    public static void MapHiker(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hiker>(i =>
        {
            i.Property(o=> o.Id).ValueGeneratedOnAdd();
            i.Property(o => o.HikerElements).HasMaxLength(500).IsRequired();
            i.Property(o => o.Name).HasMaxLength(60).IsRequired();
        });
    }
}
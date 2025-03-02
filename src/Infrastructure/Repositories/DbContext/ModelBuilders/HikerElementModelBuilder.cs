using Domain.HikerElement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DbContext.ModelBuilders;

public static class HikerElementModelBuilder
{
    public static void MapHikerElement(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HikerElement>().HasData( new HikerElement {
            Id = 1,
            Name = "E1",
            Calories = 3,
            Weight = 5
        });
        modelBuilder.Entity<HikerElement>().HasData( new HikerElement {
            Id = 2,
            Name = "E2",
            Calories = 5,
            Weight = 3
        });
        modelBuilder.Entity<HikerElement>().HasData( new HikerElement {
            Id = 3,
            Name = "E3",
            Calories = 2,
            Weight = 5
        });
        modelBuilder.Entity<HikerElement>().HasData( new HikerElement {
            Id = 4,
            Name = "E4",
            Calories = 8,
            Weight = 1
        });
        modelBuilder.Entity<HikerElement>().HasData( new HikerElement {
            Id = 5,
            Name = "E5",
            Calories = 3,
            Weight = 2
        });
        modelBuilder.Entity<HikerElement>(i =>
        {
            i.Property(o=> o.Id).ValueGeneratedOnAdd();
            i.Property(o => o.Calories).IsRequired();
            i.Property(o => o.Weight).IsRequired();
            i.Property(o => o.Name).HasMaxLength(60).IsRequired();
        });
    }
}
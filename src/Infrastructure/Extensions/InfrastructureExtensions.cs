using Application.HikerElement;
using Domain.HikerElement;
using Domain.HikerElement.Repositories;
using Application.Hiker;
using Domain.Hiker;
using Domain.Hiker.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HikerDbContext>(
            o => o.UseNpgsql(configuration.GetConnectionString("Postgres")));
        services.AddScoped<IHikerElementRepository, HikerElementRepository>();
        services.AddScoped<IHikerElementProcess, HikerElementProcess>();
        services.AddScoped<IHikerRepository, HikerRepository>();
        services.AddScoped<IHikerProcess, HikerProcess>();
        return services;
    }
}
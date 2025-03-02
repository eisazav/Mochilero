using Domain.Hiker.Entities;
using Domain.Hiker.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HikerRepository: IHikerRepository
{
    private readonly HikerDbContext _hikerElementContext;

    public HikerRepository(HikerDbContext hikerElementContext)
    {
        _hikerElementContext = hikerElementContext;
    }

    public async Task<int> AddHikerAsync(Hiker hiker)
    {
        if (hiker is null)
        {
            throw new ArgumentNullException(nameof(hiker),"Error the entity doesn't exist");
        }
        await _hikerElementContext.Hiker.AddAsync(hiker);
        await _hikerElementContext.SaveChangesAsync();
        return hiker.Id;
    }

    public async Task<Hiker?> GetHikerByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentNullException(nameof(id), "Error the id is negative number");
        }

        return await _hikerElementContext.Hiker.FirstOrDefaultAsync(i => i.Id == id);
        
    }

    public async Task<IList<Hiker?>> GetHikersAsync()
    {   
        return await _hikerElementContext.Hiker.ToListAsync();
    }

    public async Task<int> DeleteHikerAsync(Hiker hiker)
    {
        _hikerElementContext.Hiker.Remove(hiker);
        return await _hikerElementContext.SaveChangesAsync();
    }

    public async Task<int> UpdatedHikerAsync(Hiker hiker)
    {
        _hikerElementContext.Entry(hiker).State = EntityState.Modified; 
        return await _hikerElementContext.SaveChangesAsync();
    }
}
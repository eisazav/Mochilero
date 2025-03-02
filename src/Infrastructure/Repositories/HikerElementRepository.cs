using Domain.HikerElement.Entities;
using Domain.HikerElement.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HikerElementRepository: IHikerElementRepository
{
    private readonly HikerDbContext _hikerElementContext;

    public HikerElementRepository(HikerDbContext hikerElementContext)
    {
        _hikerElementContext = hikerElementContext;
    }

    public async Task<int> AddHikerElementAsync(HikerElement hikerElement)
    {
        if (hikerElement is null)
        {
            throw new ArgumentNullException(nameof(hikerElement),"Error the entity doesn't exist");
        }
        await _hikerElementContext.HikerElements.AddAsync(hikerElement);
        await _hikerElementContext.SaveChangesAsync();
        return hikerElement.Id;
    }

    public async Task<HikerElement?> GetHikerElementByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentNullException(nameof(id), "Error the id is negative number");
        }

        return await _hikerElementContext.HikerElements.FirstOrDefaultAsync(i => i.Id == id);
        
    }

    public async Task<IList<HikerElement?>> GetHikerElementsAsync()
    {   
        return await _hikerElementContext.HikerElements.ToListAsync();
    }

    public async Task<int> DeleteHikerElementAsync(HikerElement hikerElement)
    {
        _hikerElementContext.HikerElements.Remove(hikerElement);
        return await _hikerElementContext.SaveChangesAsync();
    }

    public async Task<int> UpdatedHikerElementAsync(HikerElement hikerElement)
    {
        _hikerElementContext.Entry(hikerElement).State = EntityState.Modified; 
        return await _hikerElementContext.SaveChangesAsync();
    }
}
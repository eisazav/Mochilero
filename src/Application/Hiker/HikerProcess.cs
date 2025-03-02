using Domain.Hiker;
using Domain.Hiker.Dtos;

namespace Application.Hiker;

using Domain.Hiker.Repositories;
using Domain.Hiker.Entities;
    
public class HikerProcess: IHikerProcess
{
    private readonly IHikerRepository _hikerRepository;
    public HikerProcess(IHikerRepository hikerRepository)
    {
        _hikerRepository = hikerRepository;
    }
    public async Task<int> AddHikerAsync(Hiker hiker)
    {
        return await _hikerRepository.AddHikerAsync(hiker);
    }

    public async Task<int> UpdateHikerAsync(Hiker hiker, HikerUpdateDto hikerUpdateDto)
    {
        hiker.Update(hikerUpdateDto);
        
        return await _hikerRepository.UpdatedHikerAsync(hiker);
    }

    public async Task<Hiker?> GetHikerByIdAsync(int id)
    {
        return await _hikerRepository.GetHikerByIdAsync(id);
    }

    public async Task<IList<Hiker?>> GetHikersAsync()
    {
        return await _hikerRepository.GetHikersAsync();
    }

    public async Task<int> DeleteHikerASync(int id)
    {
        var hiker = await _hikerRepository.GetHikerByIdAsync(id);
        if (hiker is null)
        {
            return 0;
        }
        return await _hikerRepository.DeleteHikerAsync(hiker);
    }
}
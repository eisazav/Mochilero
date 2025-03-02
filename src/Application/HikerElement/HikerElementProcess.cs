using Domain.HikerElement;
using Domain.HikerElement.Dtos;

namespace Application.HikerElement;

using Domain.HikerElement.Repositories;
using Domain.HikerElement.Entities;
    
public class HikerElementProcess: IHikerElementProcess
{
    private readonly IHikerElementRepository _hikerElementRepository;
    public HikerElementProcess(IHikerElementRepository hikerElementRepository)
    {
        _hikerElementRepository = hikerElementRepository;
    }
    public async Task<int> AddHikerElementAsync(HikerElement hikerElement)
    {
        return await _hikerElementRepository.AddHikerElementAsync(hikerElement);
    }

    public async Task<int> UpdateHikerElementAsync(HikerElement hikerElement, HikerElementUpdateDto hikerElementUpdateDto)
    {
        hikerElement.Update(hikerElementUpdateDto);
        
        return await _hikerElementRepository.UpdatedHikerElementAsync(hikerElement);
    }

    public async Task<HikerElement?> GetHikerElementByIdAsync(int id)
    {
        return await _hikerElementRepository.GetHikerElementByIdAsync(id);
    }

    public async Task<IList<HikerElement?>> GetHikerElementsAsync()
    {
        return await _hikerElementRepository.GetHikerElementsAsync();
    }

    public async Task<int> DeleteHikerElementASync(int id)
    {
        var hikerElement = await _hikerElementRepository.GetHikerElementByIdAsync(id);
        if (hikerElement is null)
        {
            return 0;
        }
        return await _hikerElementRepository.DeleteHikerElementAsync(hikerElement);
    }
}
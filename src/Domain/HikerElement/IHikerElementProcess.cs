using Domain.HikerElement.Dtos;

namespace Domain.HikerElement;
using Entities;

public interface IHikerElementProcess
{
    public Task<int> AddHikerElementAsync(HikerElement hikerElement);

    public Task<int> UpdateHikerElementAsync(HikerElement hikerElement, HikerElementUpdateDto hikerElementUpdateDto);

    public Task<HikerElement?> GetHikerElementByIdAsync(int id);

    public Task<IList<HikerElement?>> GetHikerElementsAsync();

    public Task<int> DeleteHikerElementASync(int id);
}
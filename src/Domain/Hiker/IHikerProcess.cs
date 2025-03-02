using Domain.Hiker.Dtos;

namespace Domain.Hiker;
using Entities;

public interface IHikerProcess
{
    public Task<int> AddHikerAsync(Hiker hiker);

    public Task<int> UpdateHikerAsync(Hiker hiker, HikerUpdateDto hikerUpdateDto);

    public Task<Hiker?> GetHikerByIdAsync(int id);

    public Task<IList<Hiker?>> GetHikersAsync();

    public Task<int> DeleteHikerASync(int id);
}
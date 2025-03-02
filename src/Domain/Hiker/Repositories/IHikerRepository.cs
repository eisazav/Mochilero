namespace Domain.Hiker.Repositories;

public interface IHikerRepository
{
    public Task<int> AddHikerAsync(Entities.Hiker hiker);
    public Task<Entities.Hiker?> GetHikerByIdAsync(int id);
    public Task<IList<Entities.Hiker?>> GetHikersAsync();
    public Task<int> DeleteHikerAsync(Entities.Hiker hiker);
    public Task<int> UpdatedHikerAsync(Entities.Hiker hiker);
}

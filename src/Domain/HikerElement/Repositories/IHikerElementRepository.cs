namespace Domain.HikerElement.Repositories;

public interface IHikerElementRepository
{
    public Task<int> AddHikerElementAsync(Entities.HikerElement hikerElement);
    public Task<Entities.HikerElement?> GetHikerElementByIdAsync(int id);
    public Task<IList<Entities.HikerElement?>> GetHikerElementsAsync();
    public Task<int> DeleteHikerElementAsync(Entities.HikerElement hikerElement);
    public Task<int> UpdatedHikerElementAsync(Entities.HikerElement hikerElement);
}

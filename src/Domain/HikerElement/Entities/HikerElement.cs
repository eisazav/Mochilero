using Domain.Common;
using Domain.HikerElement.Dtos;

namespace Domain.HikerElement.Entities;

public class HikerElement: BaseAuditableEntity
{
    public string Name { get;set; }
    public int Weight { get;set; }
    public int Calories { get;set; }
    
    public static HikerElement FromHikerElementDtoToHikerElement(HikerElementDto hikerElementDto)
    {
        return new HikerElement
        {
            Name = hikerElementDto.Name,
            Weight = hikerElementDto.Weight,
            Calories = hikerElementDto.Calories
        };
    }

    public void Update(HikerElementUpdateDto hikerElementUpdateDto)
    {
        Name = hikerElementUpdateDto.Name;
        Calories = hikerElementUpdateDto.Calories;
        Weight = hikerElementUpdateDto.Weight;
        LastModified = DateTime.Now;
    }
}

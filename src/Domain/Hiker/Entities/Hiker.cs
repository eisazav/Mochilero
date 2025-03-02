using Domain.Common;
using Domain.Hiker.Dtos;

namespace Domain.Hiker.Entities;

public class Hiker: BaseAuditableEntity
{
    public string Name { get;set; }
    public string HikerElements { get;set; }
    
    public static Hiker FromHikerDtoToHiker(HikerDto hikerDto)
    {
        return new Hiker
        {
            Name = hikerDto.Name,
            HikerElements = hikerDto.HikerElements
        };
    }

    public void Update(HikerUpdateDto hikerUpdateDto)
    {
        Name = hikerUpdateDto.Name;
        HikerElements = hikerUpdateDto.HikerElements;
        LastModified = DateTime.Now;
    }
}

using Domain.HikerElement;
using Domain.HikerElement.Dtos;
using Domain.HikerElement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HikerElementController: ControllerBase
{
    private readonly IHikerElementProcess _hikerElementProcess;
    private readonly ILogger<HikerElementController> _logger;
    public HikerElementController(ILogger<HikerElementController> iLogger, IHikerElementProcess hikerElementProcess)
    {
        _hikerElementProcess = hikerElementProcess;
        _logger = iLogger;
    }

    [HttpGet]
    public async Task<IEnumerable<HikerElement?>> Get() => await _hikerElementProcess.GetHikerElementsAsync();
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(HikerElement), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var hikerElement = await _hikerElementProcess.GetHikerElementByIdAsync(id);
        return hikerElement == null ? NotFound() : Ok(hikerElement);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(HikerElement), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(HikerElementDto hikerElement)
    {
        var id = await _hikerElementProcess.AddHikerElementAsync(HikerElement.FromHikerElementDtoToHikerElement(hikerElement));
        return CreatedAtAction(nameof(GetById), new { id}, id);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(HikerElement), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(HikerElementUpdateDto hikerElementUpdateDto,int id)
    {
        var hikerElement = await _hikerElementProcess.GetHikerElementByIdAsync(id);
        if (hikerElement is null)
        {
            return NotFound();
        }
        await _hikerElementProcess.UpdateHikerElementAsync(hikerElement,hikerElementUpdateDto);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(HikerElement), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _hikerElementProcess.DeleteHikerElementASync(id);
        return NoContent();
    }
}
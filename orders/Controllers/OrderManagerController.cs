using Microsoft.AspNetCore.Mvc;
using orders.Services;

namespace orders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderManagerController : ControllerBase
{

    private readonly IOrderManagerService _service;

    public OrderManagerController(IOrderManagerService service)
    {
        _service = service;
    }

    [HttpPost("{id:string}/authorize")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Authorize(string id)
    {
        try
        {
            return Ok(await _service.Authorize(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return NoContent();
        }
    }

    [HttpPost("{id:string}/cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Authorize(string id)
    {
        try
        {
            return Ok(await _service.Authorize(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return NoContent();
        }
    }

    [HttpPost("{id:string}/settle")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Authorize(string id)
    {
        try
        {
            return Ok(await _service.Authorize(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using orders.Domain;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Create([FromBody] Payment payment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _service.CreatePayment(payment);

            return Created($"api/order/{payment.Id}", payment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return UnprocessableEntity(e.Message);
        }
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
    public async Task<ActionResult> Cancel(string id)
    {
        try
        {
            return Ok(await _service.Cancel(id));
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
    public async Task<ActionResult> Settle(string id)
    {
        try
        {
            return Ok(await _service.Settle(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using orders.Domain;
using orders.Services;

namespace orders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{

    private readonly IPaymentService _service;

    public PaymentController(IPaymentService service)
    {
        _service = service;
    }

    [HttpGet("{id:string}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(string id)
    {
        try
        {
            return Ok(await _service.GetPaymentById(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return NoContent();
        }
    }



    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Update([FromBody] Payment payment)
    {
        try
        {
            return Ok(await _service.UpdatePayment(payment));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return UnprocessableEntity(e.Message);
        }
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
            _service.SavePayment(payment);

            //return Created($"api/contacts/{contact.Id}", contact);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return UnprocessableEntity(e.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var orders = await _service.GetPayments();

            if (orders.Any())
            {
                return Ok(orders);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            throw;
        }
    }
}
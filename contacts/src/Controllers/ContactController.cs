using System.Net.Mime;
using contacts.Domain;
using contacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace contacts.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class ContactController: Controller
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Create([FromBody] Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            _service.SaveContact(contact);
            
            return Created($"api/contacts/{contact.Id}", contact);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return UnprocessableEntity(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            return Ok(await _service.GetContactById(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return NoContent();
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var contacts = await _service.GetContacts();
            
            if (contacts.Any())
            {
                return Ok(contacts);
            }
            
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            throw;
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Update([FromBody] Contact contact)
    {
        try
        {
            return Ok(await _service.UpdateContact(contact));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return UnprocessableEntity(e.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteContact(id);
            
            return Accepted();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return UnprocessableEntity(e.Message);
        }
    }
}
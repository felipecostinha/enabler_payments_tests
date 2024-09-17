using System.Net.Mime;
using contacts.Domain;
using contacts.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace contacts.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]
[Produces(MediaTypeNames.Application.Json)]
public class ZipCodeController: Controller
{
    private readonly IZipCodeService _service;

    public ZipCodeController(IZipCodeService service)
    {
        _service = service;
    }

    [HttpGet("{zipCode}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Consult(String zipCode)
    {
        try
        {
            return Ok(await _service.Consult(zipCode));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return NoContent();
        }
    }
}
using contacts.Application.Exceptions;
using contacts.Domain;
using contacts.Repository;

namespace contacts.Services.Impl;

public class ZipCodeServiceImpl: IZipCodeService
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://viacep.com.br/ws/"),
    };
    
    public async Task<ZipCode> Consult(string zipCode)
    {
        var zipCodeResponse = await HttpClient.GetFromJsonAsync<ZipCode>($"{zipCode}/json");

        if (zipCodeResponse is null)
        {
            throw new NotFoundException("ZipCode not found");
        }

        return zipCodeResponse;
    }
}
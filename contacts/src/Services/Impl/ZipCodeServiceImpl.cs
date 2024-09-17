using contacts.Application.Exceptions;
using contacts.Domain;
using contacts.Repository;

namespace contacts.Services.Impl;

public class ZipCodeServiceImpl(HttpClient httpClient) : IZipCodeService
{
    public async Task<ZipCode> Consult(string zipCode)
    {
        var zipCodeResponse = await httpClient.GetFromJsonAsync<ZipCode>($"{zipCode}/json");

        if (zipCodeResponse is null)
        {
            throw new NotFoundException("ZipCode not found");
        }

        return zipCodeResponse;
    }
}
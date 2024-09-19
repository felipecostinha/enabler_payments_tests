using System.Net.Http.Json;
using System.Threading.Tasks;
using contacts.Domain;
using contacts.integratedTest.Config;
using Xunit;

namespace contacts.integratedTest.FixtureTests;

public class FixturesTest
{
    [Theory(DisplayName = "ZipCode consultation")]
    [InlineData("09520310")]
    [InlineData("18520005")]
    public async Task ZipCode_Contult_Api(string zipCode)
    {
        await using var application = new ContactsAppFactory();

        var uri = $"/api/ZipCode/{zipCode}";
        var client = application.CreateClient();
        var zipCodeResponse = await client.GetFromJsonAsync<ZipCode>(uri);

        Assert.NotNull(zipCodeResponse);
        Assert.Equal(zipCode, zipCodeResponse.Cep);
    }


    [Theory(DisplayName = "ZipCode consultation")]
    [InlineData("00000000")]
    [InlineData("18520005")]
    public async Task ZipCode_Contult_Mock_Api(string zipCode)
    {
        await using var application = new ContactsAppMockFactory();

        var uri = $"/api/ZipCode/{zipCode}";

        var client = application.CreateClient();

        var zipCodeResponse = await client.GetFromJsonAsync<ZipCode>(uri);

        if (zipCode == "00000000")
        {
            Assert.Equal("Mock City", zipCodeResponse.Localidade);
        }

        Assert.NotNull(zipCodeResponse);
    }
}
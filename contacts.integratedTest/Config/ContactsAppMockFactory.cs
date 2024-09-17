using contacts.Application.Context;
using contacts.Services;
using contacts.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Writers;
using RichardSzalay.MockHttp;

namespace contacts.integratedTest.Config;

public class ContactsAppMockFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<DatabaseContext>));

            services.AddDbContext<DatabaseContext>(options =>
                options.UseInMemoryDatabase("IntegratedTest", root));

            services.RemoveAll(typeof(HttpClient));

            services
                .AddHttpClient<IZipCodeService, ZipCodeServiceImpl>
                    (client => client.BaseAddress = new Uri("https://viacep.com.br/ws/"))
                .ConfigurePrimaryHttpMessageHandler(handlerBuilder => CreateMockHttp());
        });

        return base.CreateHost(builder);
    }

    private static MockHttpMessageHandler CreateMockHttp()
    {
        var msgHandler = new MockHttpMessageHandler();

        msgHandler
            .When("https://viacep.com.br/ws/00000000/json")
            .Respond("application/json", @"{
                    ""cep"": ""18520-005"",
                    ""logradouro"": ""Avenida Francisco da Silva Pontes"",
                    ""complemento"": ""até 805/806"",
                    ""unidade"": """",
                    ""bairro"": ""Centro"",
                    ""localidade"": ""Mock City"",
                    ""uf"": ""SP"",
                    ""estado"": ""São Paulo"",
                    ""regiao"": ""Sudeste"",
                    ""ibge"": ""3511508"",
                    ""gia"": ""2653"",
                    ""ddd"": ""15"",
                    ""siafi"": ""6331""
                }"
            );

        return msgHandler;
    }
}
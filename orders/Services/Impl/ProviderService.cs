using orders.Domain;
using orders.Repository;

namespace orders.Services.Impl;

public class ProviderService
{
    private readonly IProviderRepository _providerRepository;

    public ProviderService(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async void CreateProvider(Provider provider)
    {
        _providerRepository.SaveProvider(provider);

    }
}
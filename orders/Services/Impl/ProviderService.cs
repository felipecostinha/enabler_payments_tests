using orders.Domain;
using orders.Repository;

namespace orders.Services.Impl;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _repository;

    public ProviderService(IProviderRepository providerRepository)
    {
        _repository = providerRepository;
    }

    public void SaveProvider(Provider provider)
    {
        _repository.SaveProvider(provider);

    }

    public Task<Provider?> GetProviderById(string id)
    {
        return _repository.GetProviderById(id);
    }

    public Task<List<Provider>> GetProviders()
    {
        return _repository.GetProviders();
    }

    public void UpdateProvider(Provider provider)
    {
        _repository.UpdateProvider(provider);
    }
}
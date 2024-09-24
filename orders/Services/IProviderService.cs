using orders.Domain;

namespace orders.Services;

public interface IProviderService
{
    void SaveProvider(Provider provider);
    Task<Provider?> GetProviderById(string id);
    Task<List<Provider>> GetProviders();
    void UpdateProvider(Provider provider);
}
using orders.Domain;

namespace orders.Repository;

public interface IProviderRepository
{
    void SaveProvider(Provider provider);
    Task<Provider?> GetProviderById(string id);
    Task<List<Provider>> GetProviders();
    void UpdateProvider(Provider provider);
}
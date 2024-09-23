using orders.Domain;

namespace orders.Repository;

public interface IProviderRepository
{
    void SaveProvider(Provider contact);
    Task<Provider?> GetProviderById(int id);
    Task<List<Provider>> GetProviders();
    void UpdateProvider(Provider contact);
}
using orders.Domain;

namespace orders.Services;

public interface IOrderManagerService
{
    public Task<Payment> Authorize(string paymentId);

    public Task<Payment> Cancel(string paymentId);

    public Task<Payment> Settle(string paymentId);
}
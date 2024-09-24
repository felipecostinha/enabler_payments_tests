using orders.Domain;

namespace orders.Services;

public interface IPaymentService
{
    public void SavePayment(Payment payment);

    public void UpdatePayment(Payment payment);

    public Task<List<Payment>> GetPayments();

    public Task<Payment?> GetPaymentById(string id);
}
using orders.Domain;

namespace orders.Repository;

public interface IPaymentRepository
{
    void SavePayment(Payment payment);
    Task<Payment?> GetPaymentById(string id);
    Task<List<Payment>> GetPayments();
    void UpdatePayment(Payment contact);
}
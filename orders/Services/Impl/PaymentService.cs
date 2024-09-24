using orders.Domain;
using orders.Repository;

namespace orders.Services.Impl;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _repository = paymentRepository;
    }

    public Task<Payment?> GetPaymentById(string id)
    {
        return _repository.GetPaymentById(id);
    }

    public Task<List<Payment>> GetPayments()
    {
        return _repository.GetPayments();
    }

    public void SavePayment(Payment payment)
    {
        _repository.SavePayment(payment);
    }

    public void UpdatePayment(Payment payment)
    {
        _repository.UpdatePayment(payment);
    }
}
using orders.Repository;

namespace orders.Services.Impl;

public class OrderManagerService : IOrderManagerService
{
    private readonly IPaymentRepository _paymentRepository;

    public OrderManagerService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async void CreateOrder()
    {

    }

    public async void Authorize()
    {

    }

    public async void Cancel()
    {

    }
}
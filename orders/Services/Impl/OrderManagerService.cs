using orders.Domain;

namespace orders.Services.Impl;

public class OrderManagerService : IOrderManagerService
{
    private readonly IPaymentService _paymentService;
    private readonly IProviderService _providerService;

    public OrderManagerService(IPaymentService paymentService, IProviderService providerService)
    {
        _paymentService = paymentService;
        _providerService = providerService;
    }

    public async Task<Payment> Authorize(string paymentId)
    {
        var payment = await _paymentService.GetPaymentById(paymentId);
        if (payment == null)
        {
            throw new Exception("Payment not found");
        }

        var provider = await _providerService.GetProviderById(payment.ProviderId);

        if (provider == null)
        {
            throw new Exception("Provider not found");
        }

        provider.OnAuthorize(payment);

        _paymentService.UpdatePayment(payment);

        return payment;
    }

    public async Task<Payment> Cancel(string paymentId)
    {
        var payment = await _paymentService.GetPaymentById(paymentId);
        if (payment == null)
        {
            throw new Exception("Payment not found");
        }

        var provider = await _providerService.GetProviderById(payment.ProviderId);

        if (provider == null)
        {
            throw new Exception("Provider not found");
        }

        provider.OnCancel(payment);

        _paymentService.UpdatePayment(payment);

        return payment;
    }

    public async Task<Payment> Settle(string paymentId)
    {
        var payment = await _paymentService.GetPaymentById(paymentId);
        if (payment == null)
        {
            throw new Exception("Payment not found");
        }

        var provider = await _providerService.GetProviderById(payment.ProviderId);

        if (provider == null)
        {
            throw new Exception("Provider not found");
        }

        provider.OnSettle(payment);

        _paymentService.UpdatePayment(payment);

        return payment;
    }
}
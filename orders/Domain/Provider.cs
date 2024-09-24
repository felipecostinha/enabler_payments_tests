namespace orders.Domain;

public class AutoSettleDelayOptions
{
    public int Minimum;
    public int Maximum;
}

public class ProviderFields
{
    public required List<string> PaymentSystem;

    public AutoSettleDelayOptions? AutoSettleDelayOptions;
}

public class Provider
{
    public string Id { get; set; }
    public required string Name
    {
        get; set;
    }

    public ProviderFields? Fields { get; set; }

    public bool ImplementsSplit;

    public bool UsesAutoSettleOptions { get; set; }

    public bool IsDelivered { get; set; }

    private readonly int DEFAULT_DELAY_TO_SETTLE = 5000;

    public void validateProvider(Provider input)
    {
        if (input.Name == null)
        {
            throw new ArgumentNullException($"The field name is required");
        }
    }

    private void ScheduleJob(int delay, Action<Payment> callbackF, List<object> args)
    {
        /* Cria um job que será executado em {delay}s*/
    }

    public bool isValidCustomDelayToAutoSettle(int delay)
    {
        if (UsesAutoSettleOptions)
        {
            var min = Fields?.AutoSettleDelayOptions?.Minimum ?? 0;
            var max = Fields?.AutoSettleDelayOptions?.Minimum ?? 0;

            if (delay > min || delay < max)
            {
                return true;
            }
        }

        return false;
    }

    public void OnAuthorize(Payment payment)
    {
        if (payment.Value > 10)
        {
            payment.Status = PaymentStatus.Authorized;
            var delayToSettle = isValidCustomDelayToAutoSettle(payment.DelayToSettle) ?
                payment.DelayToSettle : DEFAULT_DELAY_TO_SETTLE;
            ScheduleJob(delayToSettle, OnSettle, [payment]);
        }
        ScheduleJob(payment.DelayToCancel, OnCancel, [payment]);
    }

    public void OnSettle(Payment payment)
    {
        payment.Status = PaymentStatus.Settled;
    }

    public void OnCancel(Payment payment)
    {
        payment.Status = PaymentStatus.Cancelled;
    }
}
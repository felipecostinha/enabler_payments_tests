using orders.Domain;

namespace orders.after;

public class ProviderActionFlow : Provider
{
    public void OnAuthorize(Payment payment)
    {
        if (payment.Value > 10)
        {
            payment.Status = PaymentStatus.Authorized;
            var delayToSettle = isValidCustomDelayToAutoSettle(payment.DelayToSettle) ?
                payment.DelayToSettle : ProviderUtils.DEFAULT_DELAY_TO_SETTLE;
            ProviderUtils.ScheduleJob(delayToSettle, OnSettle, [payment]);
        }
        ProviderUtils.ScheduleJob(payment.DelayToCancel, OnCancel, [payment]);
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
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

        // Comportamento adicionado - PIX após aprovado será capturado após 5min
        if (payment.PaymentSystem == "PIX" && payment.Value < 5)
        {
            payment.Status = PaymentStatus.Authorized;
            ProviderUtils.ScheduleJob(
                ProviderUtils.PIX_DEFAULT_DELAY_TO_SETTLE, 
                OnSettle, 
                [payment]
            );
        }
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
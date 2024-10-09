using orders.Domain;

namespace orders.after;

public interface IProviderActionFlow
{
    public void OnAuthorize(Provider provider, Payment payment);

    public void OnSettle(Payment payment);

    public void OnCancel(Payment payment);
}

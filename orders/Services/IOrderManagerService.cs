namespace orders.Services;

public interface IOrderManagerService
{
    public void Authorize(string paymentId);

    public void Cancel(string paymentId);

    public void Settle(string paymentId);
}
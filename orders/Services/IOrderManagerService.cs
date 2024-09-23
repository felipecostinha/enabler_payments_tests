namespace orders.Services;

public interface IOrderManagerService
{
    public void CreateOrder();

    public void Authorize();

    public void Cancel();
}
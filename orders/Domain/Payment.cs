namespace orders.Domain;

public enum PaymentStatus
{
    Started,
    Authorizing,
    Authorized,
    Settled,
    Cancelled
}

public class Payment
{
    public string Id { get; set; }

    public double Value { get; set; }

    public PaymentStatus Status { get; set; }

    public string ProviderId { get; set; }

    public string PaymentSystem { get; set; }

    public int DelayToCancel { get; set; }

    public int DelayToSettle { get; set; }

    public DateTime createdAt { get; set; }
}
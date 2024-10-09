namespace orders.after;

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
    public string Id;
    public required string Name
    {
        get; set;
    }

    public ProviderFields? Fields { get; set; }

    public bool ImplementsSplit;

    public bool UsesAutoSettleOptions { get; set; }

    public bool IsDelivered { get; set; }
}
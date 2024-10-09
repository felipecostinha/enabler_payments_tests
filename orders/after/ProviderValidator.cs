namespace orders.after;

public class ProviderValidator
{
    public static bool isValidCustomDelayToAutoSettle(int delay, Provider provider)
    {
        if (provider.UsesAutoSettleOptions)
        {
            var min = provider.Fields?.AutoSettleDelayOptions?.Minimum ?? 0;
            var max = provider.Fields?.AutoSettleDelayOptions?.Minimum ?? 0;

            if (delay > min || delay < max)
            {
                return true;
            }
        }

        return false;
    }

    public void validateProvider(Provider input)
    {
        if (input.Name == null)
        {
            throw new ArgumentNullException($"The field name is required");
        }
    }
}

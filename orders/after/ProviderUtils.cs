using orders.Domain;

namespace orders.after;

public class ProviderUtils
{
    public static readonly int DEFAULT_DELAY_TO_SETTLE = 5000;

    public void validateProvider(Provider input)
    {
        if (input.Name == null)
        {
            throw new ArgumentNullException($"The field name is required");
        }
    }

    public static void ScheduleJob(int delay, Action<Payment> callbackF, List<Object> args)
    {
        /* Cria um job que será executado em {delay}s*/
    }
}
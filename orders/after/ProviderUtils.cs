using orders.Domain;

namespace orders.after;

public class ProviderUtils
{
    public static readonly int DEFAULT_DELAY_TO_SETTLE = 5000;
    public static readonly int PIX_DEFAULT_DELAY_TO_SETTLE = 300;

    public static void ScheduleJob(int delay, Action<Payment> callbackF, List<Object> args)
    {
        /* Cria um job que será executado em {delay}s*/
    }
}
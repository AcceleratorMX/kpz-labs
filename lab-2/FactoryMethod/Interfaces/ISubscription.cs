using FactoryMethod.Enums;

namespace FactoryMethod.Interfaces;

public interface ISubscription
{
    SubscriptionType Type { get; }
    decimal MonthlyFee { get; }
    int MinimalPeriod { get; }
    List<string> Channels { get; }
    string GetDetails();
}
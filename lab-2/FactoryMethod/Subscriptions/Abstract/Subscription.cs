using System.Text;
using FactoryMethod.Enums;
using FactoryMethod.Interfaces;

namespace FactoryMethod.Subscriptions.Abstract;

public abstract class Subscription(SubscriptionType type, decimal monthlyFee, int minimalPeriod, List<string> channels)
    : ISubscription
{
    public SubscriptionType Type { get; } = type;
    public decimal MonthlyFee { get; } = monthlyFee;
    public int MinimalPeriod { get; } = minimalPeriod;
    public List<string> Channels { get; } = channels;

    public virtual string GetDetails()
    {
        return new StringBuilder()
            .AppendLine($"Type: {Type}")
            .AppendLine($"Monthly fee: {MonthlyFee}")
            .AppendLine($"Minimal period: {MinimalPeriod}")
            .AppendLine($"Channels: {string.Join(", ", Channels)}")
            .ToString();
    }
}
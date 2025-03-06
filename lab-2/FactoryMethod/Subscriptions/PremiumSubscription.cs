using System.Text;
using FactoryMethod.Enums;
using FactoryMethod.Interfaces;
using FactoryMethod.Subscriptions.Abstract;

namespace FactoryMethod.Subscriptions;

public class PremiumSubscription()
    : Subscription(
        SubscriptionType.Premium,
        29.99m,
        1,
        ["All basic channels", "Exclusive Channels"]
    ), IPremiumSubscription
{
    public bool Includes4KStreaming { get; } = true;

    public override string GetDetails()
    {
        return new StringBuilder(base.GetDetails())
            .AppendLine($"Includes 4K streaming: {Includes4KStreaming}")
            .ToString();
    }
}
using System.Text;
using FactoryMethod.Enums;
using FactoryMethod.Interfaces;
using FactoryMethod.Subscriptions.Abstract;

namespace FactoryMethod.Subscriptions;

public class DomesticSubscription()
    : Subscription(
        SubscriptionType.Domestic,
        10.99m, 
        3,
        ["News", "Sports", "Entertainment"]
    ), IDomesticSubscription
{
    public bool HasLocalChannels { get; } = true;

    public override string GetDetails()
    {
        return new StringBuilder(base.GetDetails())
            .AppendLine($"Has local channels: {HasLocalChannels}")
            .ToString();
    }
}
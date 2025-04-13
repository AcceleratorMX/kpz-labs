using FactoryMethod.Enums;
using FactoryMethod.Interfaces;
using FactoryMethod.Subscriptions;
using static FactoryMethod.Enums.SubscriptionType;

namespace FactoryMethod.Factories;

public class SubscriptionFactory
{
    public virtual ISubscription CreateSubscription(SubscriptionType type)
    {
        return type switch
        {
            Domestic => new DomesticSubscription(),
            Educational => new EducationalSubscription(),
            Premium => new PremiumSubscription(),
            _ => throw new NotSupportedException($"Subscription {type} is not supported!")
        };
    }
}
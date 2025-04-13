using FactoryMethod.Enums;
using FactoryMethod.Interfaces;
using FactoryMethod.Services;

namespace FactoryMethod.Factories;

public class ManagerCall : SubscriptionFactory
{
    public override ISubscription CreateSubscription(SubscriptionType type)
    {
        var subscription = base.CreateSubscription(type);
        FactoryService.ConsoleLogSubscriptionCreation(GetType().Name, type);
        return subscription;
    }
}
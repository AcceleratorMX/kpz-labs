using System.Text;
using FactoryMethod.Enums;
using FactoryMethod.Interfaces;
using FactoryMethod.Subscriptions.Abstract;

namespace FactoryMethod.Subscriptions;

public class EducationalSubscription()
    : Subscription(
        SubscriptionType.Educational,
        5.99m, 
        6,
        ["Discovery", "History", "Science"]
    ), IEducationalSubscription
{
    public int MaxStudents { get; } = 30;

    public override string GetDetails()
    {
        return new StringBuilder(base.GetDetails())
            .AppendLine($"Max students: {MaxStudents}")
            .ToString();
    }
}
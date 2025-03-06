namespace FactoryMethod.Interfaces;

public interface IPremiumSubscription : ISubscription
{
    bool Includes4KStreaming { get; }
}
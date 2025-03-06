namespace FactoryMethod.Interfaces;

public interface IDomesticSubscription : ISubscription
{
    bool HasLocalChannels { get; }
}
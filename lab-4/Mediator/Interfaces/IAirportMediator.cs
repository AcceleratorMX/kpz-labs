namespace Mediator.Interfaces;

public interface IAirportMediator
{
    void Notify(object sender, string @event);
}
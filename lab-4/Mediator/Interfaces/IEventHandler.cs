namespace Mediator.Interfaces;

public interface IEventHandler
{
    bool CanHandle(object sender, string @event);
    void Handle(object sender, string @event);
}
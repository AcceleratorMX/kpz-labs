using Mediator.Enums;
using Mediator.Interfaces;

namespace Mediator.Events;

public class RunwayEventHandler : IEventHandler
{
    public bool CanHandle(object sender, string @event)
    {
        return sender is Runway && @event is nameof(Event.HighlightRed) or nameof(Event.HighlightGreen);
    }

    public void Handle(object sender, string @event)
    {
        var runway = (Runway)sender;

        switch (@event)
        {
            case nameof(Event.HighlightRed):
                Console.WriteLine($"Runway {runway.Id} is busy!");
                break;
            case nameof(Event.HighlightGreen):
                Console.WriteLine($"Runway {runway.Id} is free!");
                break;
        }
    }
}
using Mediator.Events;
using Mediator.Interfaces;

namespace Mediator;

public class CommandCentre : IAirportMediator
{
    private readonly List<Runway> _runways;
    private readonly Dictionary<Runway, Aircraft?> _runwayStatus;
    private readonly List<IEventHandler> _eventHandlers = [];

    private CommandCentre(IEnumerable<Runway> runways)
    {
        _runways = new List<Runway>(runways);
        _runwayStatus = _runways.ToDictionary(r => r, Aircraft? (r) => null);
        _runways.ForEach(r => r.Mediator = this);
    }

    public static CommandCentre Initialize(IEnumerable<Runway> runways)
    {
        var commandCentre = new CommandCentre(runways);
        commandCentre.RegisterEventHandlers();
        return commandCentre;
    }

    public void Notify(object sender, string @event)
    {
        foreach (var handler in _eventHandlers.Where(handler => handler.CanHandle(sender, @event)))
        {
            handler.Handle(sender, @event);
            return;
        }

        Console.WriteLine($"No handler found for event {@event} from {sender}");
    }
    
    private void RegisterEventHandlers()
    {
        _eventHandlers.Add(new AircraftEventHandler(_runways, _runwayStatus));
        _eventHandlers.Add(new RunwayEventHandler());
    }
}
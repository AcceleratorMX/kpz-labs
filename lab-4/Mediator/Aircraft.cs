using Mediator.Enums;
using Mediator.Interfaces;

namespace Mediator;

public class Aircraft(string name, IAirportMediator mediator)
{
    public string Name { get; } = name;
    public bool IsTakingOff { get; set; } =  true;
    public void RequestLanding()
    {
        Console.WriteLine($"\nAircraft {Name} requesting landing...");
        mediator.Notify(this, nameof(Event.LandingRequest));
    }

    public void RequestTakeOff()
    {
        Console.WriteLine($"\nAircraft {Name} requesting takeoff...");
        mediator.Notify(this, nameof(Event.TakeOffRequest));
    }
}
using Mediator.Enums;
using Mediator.Interfaces;

namespace Mediator.Events;

public class AircraftEventHandler(List<Runway> runways, Dictionary<Runway, Aircraft?> runwayStatus)
    : IEventHandler
{
    public bool CanHandle(object sender, string @event)
    {
        return sender is Aircraft && @event is nameof(Event.LandingRequest) or nameof(Event.TakeOffRequest);
    }

    public void Handle(object sender, string @event)
    {
        var aircraft = (Aircraft)sender;

        switch (@event)
        {
            case nameof(Event.LandingRequest):
                HandleLandingRequest(aircraft);
                break;
            case nameof(Event.TakeOffRequest):
                HandleTakeOffRequest(aircraft);
                break;
        }
    }

    private void HandleLandingRequest(Aircraft aircraft)
    {
        if (!aircraft.IsTakingOff)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is already on a runway.");
            return;
        }
        
        foreach (var runway in runways)
        {
            Console.WriteLine("Checking runway...");
            if (runwayStatus[runway] == null)
            {
                runway.HighLightGreen();
                Console.WriteLine($"Aircraft {aircraft.Name} is landing on runway {runway.Id}.");
                runwayStatus[runway] = aircraft;
                aircraft.IsTakingOff = false;
                return;
            }

            runway.HighLightRed();
        }

        Console.WriteLine($"No free runways for aircraft {aircraft.Name}.");
    }

    private void HandleTakeOffRequest(Aircraft aircraft)
    {
        foreach (var runway in runways.Where(runway => runwayStatus[runway] == aircraft))
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {runway.Id}.");
            runwayStatus[runway] = null;
            aircraft.IsTakingOff = true;
            runway.HighLightGreen();
            return;
        }

        Console.WriteLine($"Aircraft {aircraft.Name} is not on any runway.");
    }
}
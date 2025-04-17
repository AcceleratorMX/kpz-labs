using Mediator.Enums;
using Mediator.Interfaces;

namespace Mediator;

public class Runway
{
    public IAirportMediator? Mediator { get; set; }
    public readonly Guid Id = Guid.NewGuid();

    public void HighLightRed() => Mediator?.Notify(this, nameof(Event.HighlightRed));
    public void HighLightGreen() => Mediator?.Notify(this, nameof(Event.HighlightGreen));
}
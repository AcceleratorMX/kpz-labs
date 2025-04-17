namespace Composite;
public delegate void EventHandler(LightElementNode sender, EventArgs args);

public class LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    : LightNode
{
    public string TagName { get; } = tagName;
    private string DisplayType { get; } = displayType;
    private string ClosingType { get; } = closingType;
    private List<string> CssClasses { get; } = cssClasses;
    public List<LightNode> Children { get; } = [];
    
    private readonly Dictionary<string, List<EventHandler>> _eventListeners = new Dictionary<string, List<EventHandler>>();

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }
    
    public void AddEventListener(string eventType, EventHandler handler)
    {
        if (!_eventListeners.ContainsKey(eventType))
        {
            _eventListeners[eventType] = [];
        }
        _eventListeners[eventType].Add(handler);
    }
    
    public void DispatchEvent(string eventType, EventArgs args)
    {
        if (!_eventListeners.TryGetValue(eventType, out var listeners)) return;
        foreach (var handler in listeners.ToList())
        {
            handler(this, args);
        }
    }

    public override string OuterHtml
    {
        get
        {
            var classAttribute = CssClasses.Count != 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
            var displayAttribute = $" display=\"{DisplayType}\"";
            var attributes = classAttribute + displayAttribute;
            var result = $"<{TagName}{attributes}>";

            if (ClosingType == "closing")
            {
                result += InnerHtml;
                result += $"</{TagName}>";
            }
            else
            {
                result = $"<{TagName}{attributes} />";
            }

            return result;
        }
    }

    public override string InnerHtml
    {
        get
        {
            return Children.Aggregate("", (current, child) => current + child.OuterHtml);
        }
    }
}
using Composite.Iterator;
using Composite.State;

namespace Composite;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    private string DisplayType { get; }
    private string ClosingType { get; }
    private List<string> CssClasses { get; }
    public List<LightNode> Children { get; }
    
    public IElementState State { get; private set; } = new VisibleState();

    public override string OuterHtml
    {
        get
        {
            var rawHtml = GenerateRawHtml();
            return State.ModifyOuterHtml(this, rawHtml);
        }
    }

    public override string InnerHtml
    {
        get
        {
            return Children.Aggregate("", (current, child) => current + child.OuterHtml);
        }
    }
    
    private string GenerateRawHtml()
    {
        var result = $"<{TagName} class=\"{string.Join(" ", CssClasses)}\" display=\"{DisplayType}\">";
        if (ClosingType == "closing")
        {
            result += InnerHtml;
            result += $"</{TagName}>";
        }
        else
        {
            result = $"<{TagName} class=\"{string.Join(" ", CssClasses)}\" display=\"{DisplayType}\" />";
        }
        return result;
    }
    
    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
        CssClasses = cssClasses;
        Children = [];
        OnCreated();
    }
    
    public void AddChild(LightNode child)
    {
        Children.Add(child);
        Console.WriteLine($"Added child element to {TagName}");
    }
    
    public void RemoveChild(LightNode child)
    {
        if (!Children.Contains(child)) return;
        child.Remove();
        Children.Remove(child);
        Console.WriteLine($"Removed child element from {TagName}");
    }
    
    protected override void OnCreated()
    {
        Console.WriteLine($"ElementNode created: <{TagName}>");
    }
    
    protected override void OnBeforeRender()
    {
        Console.WriteLine($"ElementNode preparing to render: <{TagName}>");
    }
    
    protected override void OnAfterRender()
    {
        Console.WriteLine($"ElementNode render completed: <{TagName}>");
    }
    
    protected override void OnRemoved()
    {
        Console.WriteLine($"ElementNode removed: <{TagName}>");
        
        foreach (var child in Children.ToList())
        {
            RemoveChild(child);
        }
    }
    
    public override List<LightNode> GetChildren() => Children;
    
    public ILightNodeIterator CreateDepthFirstIterator() => new DepthFirstIterator(this);

    public ILightNodeIterator CreateBreadthFirstIterator() => new BreadthFirstIterator(this);
    
    public void SetState(IElementState state)
    {
        State = state;
        Console.WriteLine($"State of <{TagName}> changed to {state.GetType().Name}.");
    }
}
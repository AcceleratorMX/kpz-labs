namespace Flyweight;

public class LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    : LightNode
{
    public string TagName { get; } = tagName;
    public string DisplayType { get; } = displayType;
    public string ClosingType { get; } = closingType;
    public List<string> CssClasses { get; } = cssClasses;
    public List<LightNode> Children { get; } = [];

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }

    public override string OuterHtml
    {
        get
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
    }

    public override string InnerHtml
    {
        get
        {
            return Children.Aggregate("", (current, child) => current + child.OuterHtml);
        }
    }
}
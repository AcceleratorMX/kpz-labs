using Composite.Strategy;

namespace Composite;

public class LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses, string? href = null)
    : LightNode
{
    public string TagName { get; } = tagName;
    public string DisplayType { get; } = displayType;
    private string ClosingType { get; } = closingType;
    public List<string> CssClasses { get; } = cssClasses;
    public List<LightNode> Children { get; } = [];
    public string? Href { get; } = href;
    private IImageLoadStrategy? _imageLoadStrategy;

    public void AddChild(LightNode child) => Children.Add(child);
    
    public void SetImageLoadStrategy(IImageLoadStrategy strategy) => _imageLoadStrategy = strategy;

    public override string OuterHtml
    {
        get
        {
            var classAttribute = CssClasses.Any() ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
            var displayAttribute = $" display=\"{DisplayType}\"";
            var hrefAttribute = Href != null ? $" href=\"{Href}\"" : "";
            var attributes = classAttribute + displayAttribute + hrefAttribute;

            if (TagName.Equals("img", StringComparison.CurrentCultureIgnoreCase))
            {
                var imageSource = _imageLoadStrategy?.LoadImage(Href ?? "");
                return $"<{TagName}{attributes}>{imageSource ?? ""}</{TagName}>";
            }
            else
            {
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
    }

    public override string InnerHtml
    {
        get
        {
            return Children.Aggregate("", (current, child) => current + child.OuterHtml);
        }
    }
}
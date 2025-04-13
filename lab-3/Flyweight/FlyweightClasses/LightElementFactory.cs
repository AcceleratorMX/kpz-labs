namespace Flyweight.FlyweightClasses;

public class LightElementFactory
{
    private readonly Dictionary<string, LightElementNode> _elements = [];

    public LightElementNode GetElement(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        var key = $"{tagName}|{displayType}|{closingType}|{string.Join(",", cssClasses)}";

        if (!_elements.ContainsKey(key))
        {
            _elements[key] = new LightElementNode(tagName, displayType, closingType, cssClasses);
        }

        return new LightElementNode(tagName, displayType, closingType, cssClasses);
    }

    public int GetElementCount() => _elements.Count;
}
namespace Flyweight.FlyweightClasses;

public class LightTextFactory
{
    private readonly Dictionary<string, LightTextNode> _textNodes = [];

    public LightTextNode GetTextNode(string text)
    {
        if (_textNodes.TryGetValue(text, out var value)) return value;
        value = new LightTextNode(text);
        _textNodes[text] = value;

        return value;
    }

    public int GetTextNodeCount() => _textNodes.Count;
}
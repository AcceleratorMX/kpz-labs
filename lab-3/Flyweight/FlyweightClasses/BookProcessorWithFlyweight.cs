namespace Flyweight.FlyweightClasses;

public class BookProcessorWithFlyweight
{
    private readonly LightElementFactory _elementFactory = new();
    private readonly LightTextFactory _textFactory = new();

    public LightNode ProcessBook(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var rootElement = _elementFactory.GetElement("div", "block", "closing", ["book-container"]);

        if (lines.Length <= 0) return rootElement;

        var h1 = _elementFactory.GetElement("h1", "block", "closing", ["book-title"]);
        h1.AddChild(_textFactory.GetTextNode(lines[0]));
        rootElement.AddChild(h1);

        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            LightElementNode element;

            if (line.Length < 20)
            {
                element = _elementFactory.GetElement("h2", "block", "closing", ["section-title"]);
            }
            else if (line.StartsWith(" ") || line.StartsWith("\t"))
            {
                element = _elementFactory.GetElement("blockquote", "block", "closing", ["quote"]);
            }
            else
            {
                element = _elementFactory.GetElement("p", "block", "closing", ["paragraph"]);
            }

            element.AddChild(_textFactory.GetTextNode(line));
            rootElement.AddChild(element);
        }

        return rootElement;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Element factory contains {_elementFactory.GetElementCount()} unique elements");
        Console.WriteLine($"Text node factory contains {_textFactory.GetTextNodeCount()} unique text nodes");
    }
}
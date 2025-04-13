namespace Flyweight.FlyweightClasses;

public class DefaultBookProcessor
{
    public LightNode ProcessBook(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var rootElement = new LightElementNode("div", "block", "closing", ["book-container"]);

        if (lines.Length <= 0) return rootElement;

        var h1 = new LightElementNode("h1", "block", "closing", ["book-title"]);
        h1.AddChild(new LightTextNode(lines[0]));
        rootElement.AddChild(h1);


        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            LightElementNode element;

            if (line.Length < 20)
            {
                element = new LightElementNode("h2", "block", "closing", ["section-title"]);
            }
            else if (line.StartsWith(" ") || line.StartsWith("\t"))
            {
                element = new LightElementNode("blockquote", "block", "closing", ["quote"]);
            }
            else
            {
                element = new LightElementNode("p", "block", "closing", ["paragraph"]);
            }

            element.AddChild(new LightTextNode(line));
            rootElement.AddChild(element);
        }

        return rootElement;
    }
}
using Composite;
using Composite.Strategy;

var header = new LightElementNode("h1", "block", "closing", ["header"]);
header.AddChild(new LightTextNode("Welcome to LightHTML!"));

var paragraph = new LightElementNode("p", "block", "closing", ["text"]);
paragraph.AddChild(new LightTextNode("Lorem ipsum dolor sit amet."));

var list = new LightElementNode("ul", "block", "closing", ["list"]);

var item1 = new LightElementNode("li", "block", "closing", []);
item1.AddChild(new LightTextNode("First item"));

var item2 = new LightElementNode("li", "block", "closing", []);
item2.AddChild(new LightTextNode("Second item"));

var item3 = new LightElementNode("li", "block", "closing", []);
item3.AddChild(new LightTextNode("Third item"));

list.AddChild(item1);
list.AddChild(item2);
list.AddChild(item3);

var fileImage = new LightElementNode("img", "inline", "self-closing", ["image"], "local/image.png");
fileImage.SetImageLoadStrategy(new FileLoadStrategy());

var networkImage = new LightElementNode("img", "inline", "self-closing", ["image"], "https://example.com/image.jpg");
networkImage.SetImageLoadStrategy(new NetworkLoadStrategy());

var page = new LightElementNode("div", "block", "closing", ["container"]);
page.AddChild(header);
page.AddChild(paragraph);
page.AddChild(list);
page.AddChild(fileImage);
page.AddChild(networkImage);

Console.WriteLine("=== OuterHTML ===");
Console.WriteLine(page.OuterHtml);

Console.WriteLine("\n=== InnerHTML ===");
Console.WriteLine(page.InnerHtml);

Console.WriteLine("\n=== Full Page Structure ===");
PrintNode(page, 0);
return;

static void PrintNode(LightNode node, int indent)
{
    var indentStr = new string(' ', indent * 2);

    switch (node)
    {
        case LightElementNode elementNode:
        {
            var attributes = new List<string>();
            if (elementNode.CssClasses.Count != 0)
            {
                attributes.Add($"class=\"{string.Join(" ", elementNode.CssClasses)}\"");
            }
            attributes.Add($"display=\"{elementNode.DisplayType}\"");
            if (elementNode.Href != null)
            {
                attributes.Add($"href=\"{elementNode.Href}\"");
            }

            var attributesString = attributes.Count != 0 ? " " + string.Join(" ", attributes) : "";

            Console.WriteLine($"{indentStr}<{elementNode.TagName}{attributesString}>");
            foreach (var child in elementNode.Children)
            {
                PrintNode(child, indent + 1);
            }

            Console.WriteLine($"{indentStr}</{elementNode.TagName}>");
            break;
        }
        case LightTextNode textNode:
            Console.WriteLine($"{indentStr}\"{textNode.OuterHtml}\"");
            break;
    }
}
using Composite;

var header = new LightElementNode("h1", "block", "closing", ["header"]);
header.AddChild(new LightTextNode("Welcome to LightHTML!"));

header.AddEventListener("mouseover", (sender, e) =>
{
    Console.WriteLine($"Mouse cursor is over the header! Text: \"{sender.Children.OfType<LightTextNode>().FirstOrDefault()?.OuterHtml}\"");
});

var paragraph = new LightElementNode("p", "block", "closing", ["text"]);
paragraph.AddChild(new LightTextNode("Lorem ipsum dolor sit amet."));

paragraph.AddEventListener("click", (sender, e) =>
{
    Console.WriteLine($"Paragraph is clicked! Text: \"{sender.Children.OfType<LightTextNode>().FirstOrDefault()?.OuterHtml}\"");
});

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

item2.AddEventListener("click", (sender, e) =>
{
    Console.WriteLine($"Second list item was clicked! Text: \"{sender.Children.OfType<LightTextNode>().FirstOrDefault()?.OuterHtml}\"");
});

var image = new LightElementNode("img", "inline", "self-closing", ["image"]);

var page = new LightElementNode("div", "block", "closing", ["container"]);
page.AddChild(header);
page.AddChild(paragraph);
page.AddChild(list);
page.AddChild(image);

Console.WriteLine("=== OuterHTML ===");
Console.WriteLine(page.OuterHtml);

Console.WriteLine("\n=== InnerHTML ===");
Console.WriteLine(page.InnerHtml);

Console.WriteLine("\n=== Demonstrating Events ===");
Console.WriteLine("Simulating 'click' event on the paragraph:");
paragraph.DispatchEvent("click", EventArgs.Empty);

Console.WriteLine("\nSimulating 'click' event on the second list item:");
item2.DispatchEvent("click", EventArgs.Empty);

Console.WriteLine("\nSimulating 'mouseover' event on the header:");
header.DispatchEvent("mouseover", EventArgs.Empty);

Console.WriteLine("\n=== Full Page Structure ===");
PrintNode(page, 0);
return;

static void PrintNode(LightNode node, int indent)
{
    var indentStr = new string(' ', indent * 2);

    if (node is LightElementNode elementNode)
    {
        Console.WriteLine($"{indentStr}<{elementNode.TagName}>");
        foreach (var child in elementNode.Children)
        {
            PrintNode(child, indent + 1);
        }

        Console.WriteLine($"{indentStr}</{elementNode.TagName}>");
    }
    else if (node is LightTextNode textNode)
    {
        Console.WriteLine($"{indentStr}\"{textNode.OuterHtml}\"");
    }
}
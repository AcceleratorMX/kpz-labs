﻿using Composite;
using Composite.Command;
using Composite.State;
using Composite.Visitor;

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

var image = new LightElementNode("img", "inline", "self-closing", ["image"]);

var page = new LightElementNode("div", "block", "closing", ["container"]);
page.AddChild(header);
page.AddChild(paragraph);
page.AddChild(list);
page.AddChild(image);

// Console.WriteLine("\n=== DFS ===");
// var depthIterator = page.CreateDepthFirstIterator();
// while (depthIterator.HasNext())
// {
//     var node = depthIterator.Next();
//     switch (node)
//     {
//         case LightElementNode elementNode:
//             Console.WriteLine($"Element: <{elementNode.TagName}>");
//             break;
//         case LightTextNode textNode:
//             Console.WriteLine($"Text: {textNode.OuterHtml}");
//             break;
//     }
// }

// Console.WriteLine("\n=== BFS ===");
// var breadthIterator = page.CreateBreadthFirstIterator();
// while (breadthIterator.HasNext())
// {
//     var node = breadthIterator.Next();
//     switch (node)
//     {
//         case LightElementNode elementNode:
//             Console.WriteLine($"Element: <{elementNode.TagName}>");
//             break;
//         case LightTextNode textNode:
//             Console.WriteLine($"Text: {textNode.OuterHtml}");
//             break;
//     }
// }

// page.SetState(new HiddenState());
// Console.WriteLine("\n=== After Hidden State ===");
// Console.WriteLine(page.OuterHtml);
//
// page.SetState(new DisabledState());
// Console.WriteLine("\n=== After Disabled State ===");
// Console.WriteLine(page.OuterHtml);
//
// page.SetState(new VisibleState());
// Console.WriteLine("\n=== After Visible State ===");
// Console.WriteLine(page.OuterHtml);

// var commandManager = new CommandManager();
// var newParagraph = new LightTextNode("New paragraph content");
// var addCommand = new AddChildCommand(page, newParagraph);
// commandManager.ExecuteCommand(addCommand);
// Console.WriteLine("\n=== After Adding Paragraph ===");
// Console.WriteLine(page.OuterHtml);
//
// commandManager.UndoLastCommand();
// Console.WriteLine("\n=== After Undo ===");
// Console.WriteLine(page.OuterHtml);

var counter = new NodeCounterVisitor();
page.Accept(counter);
Console.WriteLine($"\n=== Node Count ===");
Console.WriteLine($"Elements: {counter.ElementCount}, Text Nodes: {counter.TextCount}");

// Console.WriteLine("\n=== Page rendering ===");
// var renderedPage = page.Render();

// Console.WriteLine("\n=== OuterHTML ===");
// Console.WriteLine(renderedPage);
//
// Console.WriteLine("\n=== InnerHTML ===");
// Console.WriteLine(page.InnerHtml);

// Console.WriteLine("\n=== Removing list ===");
// page.RemoveChild(list);
//
// Console.WriteLine("\n=== Page structure after removing list ===");
// PrintNode(page, 0);
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
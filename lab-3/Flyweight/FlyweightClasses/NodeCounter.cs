namespace Flyweight.FlyweightClasses;

public static class NodeCounter
{
    public static int CountNodes(LightNode node)
    {
        var count = 1;

        if (node is not LightElementNode elementNode) return count;
        count += elementNode.Children.Sum(CountNodes);

        return count;
    }
}
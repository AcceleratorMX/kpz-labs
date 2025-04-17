namespace Composite.Strategy;

public class NetworkLoadStrategy : IImageLoadStrategy
{
    public string LoadImage(string href) => $"[Image from the network {href}]";
}
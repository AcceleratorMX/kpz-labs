namespace Composite.Strategy;

public class FileLoadStrategy : IImageLoadStrategy
{
    public string LoadImage(string href) => $"[Image from the file: {href}]";
}
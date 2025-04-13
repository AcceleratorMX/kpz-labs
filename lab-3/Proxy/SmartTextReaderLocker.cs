using System.Text.RegularExpressions;

namespace Proxy;

public class SmartTextReaderLocker(string pattern) : ISmartTextReader
{
    private readonly SmartTextReader _reader = new();

    public char[][] ReadText(string filePath)
    {
        if (!Regex.IsMatch(filePath, pattern)) return _reader.ReadText(filePath);
        Console.WriteLine("Access denied!");
        return [];
    }
}
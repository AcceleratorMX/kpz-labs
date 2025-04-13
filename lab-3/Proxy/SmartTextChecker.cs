namespace Proxy;

public class SmartTextChecker : ISmartTextReader
{
    private readonly SmartTextReader _reader = new();

    public char[][] ReadText(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        Console.WriteLine($"Trying to open file: {fileName}");

        char[][] textArray;

        try
        {
            textArray = _reader.ReadText(filePath);
            Console.WriteLine("File has been read successfully.");

            var rowCount = textArray.Length;
            var charCount = textArray.Sum(line => line.Length);

            Console.WriteLine($"Rows: {rowCount}");
            Console.WriteLine($"Characters: {charCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"File reading error: {ex.Message}");
            throw;
        }
        finally
        {
            Console.WriteLine($"Closing file: {fileName}");
        }

        return textArray;
    }
}
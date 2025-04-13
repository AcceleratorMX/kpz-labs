using System.Text;
using Proxy;

Console.OutputEncoding = Encoding.UTF8;

var projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "files");
var normalFilePath = Path.Combine(projectRoot, "normal.txt");
var restrictedFilePath = Path.Combine(projectRoot, "secret.txt");

File.WriteAllText(normalFilePath, "Hello\nWorld\nTest");
File.WriteAllText(restrictedFilePath, "Top\nSecret\nData");

ISmartTextReader basicReader = new SmartTextReader();
Console.WriteLine("Basic SmartTextReader:");
var basicResult = basicReader.ReadText(normalFilePath);
PrintArray(basicResult);

ISmartTextReader checker = new SmartTextChecker();
Console.WriteLine("\nSmartTextChecker test:");
var checkedResult = checker.ReadText(normalFilePath);
PrintArray(checkedResult);

ISmartTextReader locker = new SmartTextReaderLocker("secret");
Console.WriteLine("\nSmartTextReaderLocker test (allowed file):");
var allowedResult = locker.ReadText(normalFilePath);
PrintArray(allowedResult);

Console.WriteLine("\nSmartTextReaderLocker test (restricted file):");
var restrictedResult = locker.ReadText(restrictedFilePath);
PrintArray(restrictedResult);
return;

static void PrintArray(char[][] array)
{
    if (array.Length == 0)
    {
        Console.WriteLine("Array is empty.");
        return;
    }

    Console.WriteLine("Content:");
    for (var i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Row {i + 1}: {new string(array[i])}");
    }
}
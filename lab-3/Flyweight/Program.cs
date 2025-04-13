using Flyweight.FlyweightClasses;

var bookPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "data", "book.txt"));
if (!File.Exists(bookPath))
{
    throw new FileNotFoundException("Book file not found");
}

Console.WriteLine("Processing the book in a standard way...");
var standardMemory = MemoryMeasurer.MeasureMemoryUsage(() =>
{
    var processor = new DefaultBookProcessor();
    var bookElement = processor.ProcessBook(bookPath);
    Console.WriteLine($"The standard approach created HTML with {NodeCounter.CountNodes(bookElement)} nodes");

    Console.WriteLine("Sample standard HTML output:");
    Console.WriteLine(bookElement.OuterHtml[..Math.Min(500, bookElement.OuterHtml.Length)] + "...");
});

Console.WriteLine("\nProcessing the book using the Flyweight pattern...");
var flyweightMemory = MemoryMeasurer.MeasureMemoryUsage(() =>
{
    var processor = new BookProcessorWithFlyweight();
    var bookElement = processor.ProcessBook(bookPath);
    Console.WriteLine($"The Flyweight approach created HTML with {NodeCounter.CountNodes(bookElement)} nodes");
    processor.ShowStats();

    Console.WriteLine("Sample HTML output using the Flyweight:");
    Console.WriteLine(bookElement.OuterHtml[..Math.Min(500, bookElement.OuterHtml.Length)] + "...");
});

Console.WriteLine("\nMemory usage comparison:");
Console.WriteLine($"Standard approach: {standardMemory:N0} bytes");
Console.WriteLine($"Flyweight approach: {flyweightMemory:N0} bytes");
Console.WriteLine($"Memory savings: {standardMemory - flyweightMemory:N0} bytes " +
                  $"({(standardMemory > 0 ? (1 - (double)flyweightMemory / standardMemory) * 100 : 0):F2}%)");
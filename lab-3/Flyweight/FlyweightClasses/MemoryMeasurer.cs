namespace Flyweight.FlyweightClasses;

public static class MemoryMeasurer
{
    public static long MeasureMemoryUsage(Action action)
    {
        MeasureMemory();

        var startMemory = GC.GetTotalMemory(true);

        action();

        MeasureMemory();

        var endMemory = GC.GetTotalMemory(true);

        return endMemory - startMemory;
    }

    private static void MeasureMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Thread.Sleep(100);
    }
}
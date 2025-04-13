using FactoryMethod.Enums;

namespace FactoryMethod.Services;

public static class FactoryService
{
    public static void ConsoleLogSubscriptionCreation(string typeName, SubscriptionType type)
    {
        Console.WriteLine($"{typeName}: {type} subscription has been created.");
    }
}
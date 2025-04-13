using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.IProne;

public class IProneNetbook : INetbook
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
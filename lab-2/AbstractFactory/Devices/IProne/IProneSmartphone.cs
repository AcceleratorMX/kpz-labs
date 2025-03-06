using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.IProne;

public class IProneSmartphone : ISmartphone
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
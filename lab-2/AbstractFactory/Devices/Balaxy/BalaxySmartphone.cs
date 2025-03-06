using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Balaxy;

public class BalaxySmartphone : ISmartphone
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Balaxy;

public class BalaxyNetbook : INetbook
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
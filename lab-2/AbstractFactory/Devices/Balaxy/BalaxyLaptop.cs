using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Balaxy;

public class BalaxyLaptop : ILaptop
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
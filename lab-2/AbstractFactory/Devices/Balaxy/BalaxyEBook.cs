using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Balaxy;

public class BalaxyEBook : IEBook
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
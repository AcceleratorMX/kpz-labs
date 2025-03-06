using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Kiaomi;

public class KiaomiLaptop : ILaptop
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
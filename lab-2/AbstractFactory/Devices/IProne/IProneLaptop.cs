using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.IProne;

public class IProneLaptop : ILaptop
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
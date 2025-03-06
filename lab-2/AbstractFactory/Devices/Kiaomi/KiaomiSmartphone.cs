using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Kiaomi;

public class KiaomiSmartphone : ISmartphone
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
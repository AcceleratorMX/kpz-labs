using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Kiaomi;

public class KiaomiNetbook : INetbook
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
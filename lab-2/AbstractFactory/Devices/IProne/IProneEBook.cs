using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.IProne;

public class IProneEBook : IEBook
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
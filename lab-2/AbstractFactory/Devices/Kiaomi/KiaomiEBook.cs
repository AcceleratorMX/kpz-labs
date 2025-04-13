using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Devices.Kiaomi;

public class KiaomiEBook : IEBook
{
    public void GetDetails()
    {
        Console.WriteLine($"I am a {GetType().Name}.");
    }
}
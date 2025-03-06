using AbstractFactory.Devices.Kiaomi;
using AbstractFactory.Interfaces.Devices;
using AbstractFactory.Interfaces.Factory;

namespace AbstractFactory.Factories;

public class KiaomiFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new KiaomiLaptop();
    public INetbook CreateNetbook() => new KiaomiNetbook();
    public IEBook CreateEBook() => new KiaomiEBook();
    public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
}
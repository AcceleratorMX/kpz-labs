using AbstractFactory.Devices.Balaxy;
using AbstractFactory.Interfaces.Devices;
using AbstractFactory.Interfaces.Factory;

namespace AbstractFactory.Factories;

public class BalaxyFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public INetbook CreateNetbook() => new BalaxyNetbook();
    public IEBook CreateEBook() => new BalaxyEBook();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
}
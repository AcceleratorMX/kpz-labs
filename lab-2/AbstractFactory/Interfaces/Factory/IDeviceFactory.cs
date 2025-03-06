using AbstractFactory.Interfaces.Devices;

namespace AbstractFactory.Interfaces.Factory;

public interface IDeviceFactory
{
    ILaptop CreateLaptop();
    INetbook CreateNetbook();
    IEBook CreateEBook();
    ISmartphone CreateSmartphone();
}
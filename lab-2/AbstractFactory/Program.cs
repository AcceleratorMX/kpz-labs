using AbstractFactory.Factories;
using AbstractFactory.Interfaces.Factory;

IDeviceFactory iproneFactory = new IProneFactory();
IDeviceFactory kiaomiFactory = new KiaomiFactory();
IDeviceFactory balaxyFactory = new BalaxyFactory();

Console.WriteLine("IProne Devices:");
iproneFactory.CreateLaptop().GetDetails();
iproneFactory.CreateNetbook().GetDetails();
iproneFactory.CreateEBook().GetDetails();
iproneFactory.CreateSmartphone().GetDetails();

Console.WriteLine("\nKiaomi Devices:");
kiaomiFactory.CreateLaptop().GetDetails();
kiaomiFactory.CreateNetbook().GetDetails();
kiaomiFactory.CreateEBook().GetDetails();
kiaomiFactory.CreateSmartphone().GetDetails();

Console.WriteLine("\nBalaxy Devices:");
balaxyFactory.CreateLaptop().GetDetails();
balaxyFactory.CreateNetbook().GetDetails();
balaxyFactory.CreateEBook().GetDetails();
balaxyFactory.CreateSmartphone().GetDetails();

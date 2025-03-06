using AbstractFactory.Devices.Balaxy;
using AbstractFactory.Devices.IProne;
using AbstractFactory.Devices.Kiaomi;
using AbstractFactory.Factories;

namespace FactoryMethod.Test;

public class AbstractFactoryTests
{
    [Fact]
    public void CreateLaptop_ShouldReturnIProneLaptop()
    {
        // Arrange
        var factory = new IProneFactory();

        // Act
        var laptop = factory.CreateLaptop();

        // Assert
        Assert.IsType<IProneLaptop>(laptop);
    }

    [Fact]
    public void CreateNetbook_ShouldReturnIProneNetbook()
    {
        // Arrange
        var factory = new IProneFactory();

        // Act
        var netbook = factory.CreateNetbook();

        // Assert
        Assert.IsType<IProneNetbook>(netbook);
    }

    [Fact]
    public void CreateEBook_ShouldReturnIProneEBook()
    {
        // Arrange
        var factory = new IProneFactory();

        // Act
        var eBook = factory.CreateEBook();

        // Assert
        Assert.IsType<IProneEBook>(eBook);
    }

    [Fact]
    public void CreateSmartphone_ShouldReturnIProneSmartphone()
    {
        // Arrange
        var factory = new IProneFactory();

        // Act
        var smartphone = factory.CreateSmartphone();

        // Assert
        Assert.IsType<IProneSmartphone>(smartphone);
    }
    
    [Fact]
    public void CreateLaptop_ShouldReturnKiaomiLaptop()
    {
        // Arrange
        var factory = new KiaomiFactory();

        // Act
        var laptop = factory.CreateLaptop();

        // Assert
        Assert.IsType<KiaomiLaptop>(laptop);
    }

    [Fact]
    public void CreateNetbook_ShouldReturnKiaomiNetbook()
    {
        // Arrange
        var factory = new KiaomiFactory();

        // Act
        var netbook = factory.CreateNetbook();

        // Assert
        Assert.IsType<KiaomiNetbook>(netbook);
    }

    [Fact]
    public void CreateEBook_ShouldReturnKiaomiEBook()
    {
        // Arrange
        var factory = new KiaomiFactory();

        // Act
        var eBook = factory.CreateEBook();

        // Assert
        Assert.IsType<KiaomiEBook>(eBook);
    }

    [Fact]
    public void CreateSmartphone_ShouldReturnKiaomiSmartphone()
    {
        // Arrange
        var factory = new KiaomiFactory();

        // Act
        var smartphone = factory.CreateSmartphone();

        // Assert
        Assert.IsType<KiaomiSmartphone>(smartphone);
    }
    
    [Fact]
    public void CreateLaptop_ShouldReturnBalaxyLaptop()
    {
        // Arrange
        var factory = new BalaxyFactory();

        // Act
        var laptop = factory.CreateLaptop();

        // Assert
        Assert.IsType<BalaxyLaptop>(laptop);
    }

    [Fact]
    public void CreateNetbook_ShouldReturnBalaxyNetbook()
    {
        // Arrange
        var factory = new BalaxyFactory();

        // Act
        var netbook = factory.CreateNetbook();

        // Assert
        Assert.IsType<BalaxyNetbook>(netbook);
    }

    [Fact]
    public void CreateEBook_ShouldReturnBalaxyEBook()
    {
        // Arrange
        var factory = new BalaxyFactory();

        // Act
        var eBook = factory.CreateEBook();

        // Assert
        Assert.IsType<BalaxyEBook>(eBook);
    }

    [Fact]
    public void CreateSmartphone_ShouldReturnBalaxySmartphone()
    {
        // Arrange
        var factory = new BalaxyFactory();

        // Act
        var smartphone = factory.CreateSmartphone();

        // Assert
        Assert.IsType<BalaxySmartphone>(smartphone);
    }
}
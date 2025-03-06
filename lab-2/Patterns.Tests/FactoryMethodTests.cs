using FactoryMethod.Enums;
using FactoryMethod.Factories;
using FactoryMethod.Subscriptions;
using static FactoryMethod.Enums.SubscriptionType;

namespace FactoryMethod.Test;

public class FactoryMethodTests
{
    [Fact]
    public void CreateSubscription_Domestic_ReturnsDomesticSubscription()
    {
        // Arrange
        var factory = new SubscriptionFactory();

        // Act
        var subscription = factory.CreateSubscription(Domestic);

        // Assert
        Assert.IsType<DomesticSubscription>(subscription);
    }

    [Fact]
    public void CreateSubscription_Educational_ReturnsEducationalSubscription()
    {
        // Arrange
        var factory = new SubscriptionFactory();

        // Act
        var subscription = factory.CreateSubscription(Educational);

        // Assert
        Assert.IsType<EducationalSubscription>(subscription);
    }

    [Fact]
    public void CreateSubscription_Premium_ReturnsPremiumSubscription()
    {
        // Arrange
        var factory = new SubscriptionFactory();

        // Act
        var subscription = factory.CreateSubscription(Premium);

        // Assert
        Assert.IsType<PremiumSubscription>(subscription);
    }

    [Fact]
    public void CreateSubscription_UnknownType_ThrowsNotSupportedException()
    {
        // Arrange
        var factory = new SubscriptionFactory();

        // Act and Assert
        Assert.Throws<NotSupportedException>(() => factory.CreateSubscription((SubscriptionType)100));
    }

    [Fact]
    public void WebSite_CreateSubscription_Domestic_ReturnsDomesticSubscription()
    {
        // Arrange
        var factory = new WebSite();

        // Act
        var subscription = factory.CreateSubscription(Domestic);

        // Assert
        Assert.IsType<DomesticSubscription>(subscription);
    }

    [Fact]
    public void MobileApp_CreateSubscription_Domestic_ReturnsDomesticSubscription()
    {
        // Arrange
        var factory = new MobileApp();

        // Act
        var subscription = factory.CreateSubscription(Domestic);

        // Assert
        Assert.IsType<DomesticSubscription>(subscription);
    }

    [Fact]
    public void ManagerCall_CreateSubscription_Domestic_ReturnsDomesticSubscription()
    {
        // Arrange
        var factory = new ManagerCall();

        // Act
        var subscription = factory.CreateSubscription(Domestic);

        // Assert
        Assert.IsType<DomesticSubscription>(subscription);
    }
}
using Singleton;

namespace FactoryMethod.Test;

public class SingletonTests
{
    [Fact]
    public void GetInstance_ShouldReturnSameInstance()
    {
        // Arrange & Act
        var instance1 = Authenticator.GetInstance;
        var instance2 = Authenticator.GetInstance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Authenticate_ShouldNotThrowExceptions()
    {
        // Arrange
        var authenticator = Authenticator.GetInstance;

        // Act & Assert
        var exception = Record.Exception(() => authenticator.Authenticate("User"));
        Assert.Null(exception);
    }

    [Fact]
    public void ParallelCalls_ShouldReturnSameInstance()
    {
        // Arrange
        var instances = new Authenticator[5];

        // Act
        Parallel.For(0, 5, i =>
        {
            instances[i] = Authenticator.GetInstance;
        });

        // Assert
        for (var i = 1; i < instances.Length; i++)
        {
            Assert.Same(instances[0], instances[i]);
        }
    }
    
    [Fact]
    public async Task Instance_ShouldBeThreadSafe()
    {
        // Arrange
        Authenticator instance1 = null!;
        Authenticator instance2 = null!;

        // Act
        var task1 = Task.Run(() => instance1 = Authenticator.GetInstance);
        var task2 = Task.Run(() => instance2 = Authenticator.GetInstance);
        await Task.WhenAll(task1, task2);

        // Assert
        Assert.Same(instance1, instance2);
    }

}
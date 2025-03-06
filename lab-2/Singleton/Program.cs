using Singleton;

Parallel.For(0, 10, i =>
{
    Authenticator.GetInstance.Authenticate($"{i}");
});

var instance1 = Authenticator.GetInstance;
var instance2 = Authenticator.GetInstance;

Console.WriteLine($"Is Singleton working: {IsSingletonWorking(instance1, instance2)}");
return;

static bool IsSingletonWorking(Authenticator auth1, Authenticator auth2)
{
    return auth1 == auth2;
}
namespace Singleton;

public class Authenticator
{
    private static readonly Lazy<Authenticator> Instance = new(() => new Authenticator());
    
    private Authenticator()
    {
        Console.WriteLine("Instance created.");
    }
    
    public static Authenticator GetInstance => Instance.Value;
    
    public void Authenticate(string username)
    {
        Console.WriteLine($"User '{username}' authenticated in thread '{Environment.CurrentManagedThreadId}'.");
    }
}
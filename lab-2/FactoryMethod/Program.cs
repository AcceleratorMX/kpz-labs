using FactoryMethod.Factories;
using static FactoryMethod.Enums.SubscriptionType;

SubscriptionFactory webSite = new WebSite();
SubscriptionFactory mobileApp = new MobileApp();
SubscriptionFactory managerCall = new ManagerCall();

var webSiteSubscription = webSite.CreateSubscription(Domestic);
var mobileAppSubscription = mobileApp.CreateSubscription(Educational);
var managerCallSubscription = managerCall.CreateSubscription(Premium);
var managerCallSubscription1 = managerCall.CreateSubscription(Domestic);

Console.WriteLine("\n--> Subscriptions <--");
Console.WriteLine(webSiteSubscription.GetDetails());
Console.WriteLine(mobileAppSubscription.GetDetails());
Console.WriteLine(managerCallSubscription.GetDetails());
using System.Globalization;
using lab_1.Entities.Abstract;
using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities.Animal.Abstract;

public abstract class Animal : Entity, IAnimal, IFeedable, IInventoryable
{
    public string Species { get; }
    public FoodType Diet { get; }
    public IEnclosure Enclosure { get; set; }
    private DateTime _lastFeedingTime;

    protected Animal(string name, string species, FoodType diet, IEnclosure enclosure)
        : base(name)
    {
        if (string.IsNullOrWhiteSpace(species))
            throw new ArgumentException("Species cannot be null or empty", nameof(species));

        Species = species;
        Diet = diet;
        Enclosure = enclosure;
        _lastFeedingTime = DateTime.MinValue;
    }

    public virtual void Feed(IFood food)
    {
        if (food.Type != Diet)
            throw new ArgumentException($"{Name} cannot eat {food.Type} food", nameof(food));

        _lastFeedingTime = DateTime.Now;

        Console.WriteLine($"{Name} has been fed with {food.Type}");
    }

    public string GetInventoryInfo()
    {
        return $"{Name}, Species: {Species}, Diet: {Diet}, " +
               $"{Enclosure?.Name ?? "Not assigned"}, " +
               $"{(_lastFeedingTime == DateTime.MinValue ? "Never" : _lastFeedingTime.ToString(CultureInfo.InvariantCulture))}";
    }
}
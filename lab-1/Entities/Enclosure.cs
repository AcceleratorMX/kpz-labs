using System.Globalization;
using lab_1.Entities.Abstract;
using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities;

public class Enclosure : Entity, IEnclosure, IMaintainable, IInventoryable
{
    public double Area { get; }
    public EnclosureType Type { get; }
    public int MaxCapacity { get; }
    private readonly List<IAnimal> _animals = [];
    public ICollection<IAnimal> Animals => _animals.AsReadOnly();
    private DateTime _lastMaintenanceDate;

    public Enclosure(string name, double area, EnclosureType type, int maxCapacity)
        : base(name)
    {
        if (area <= 0)
            throw new ArgumentException("Area must be positive", nameof(area));
        if (maxCapacity <= 0)
            throw new ArgumentException("Maximum capacity must be positive", nameof(maxCapacity));

        Area = area;
        Type = type;
        MaxCapacity = maxCapacity;
        _lastMaintenanceDate = DateTime.MinValue;
    }

    public bool AddAnimal(IAnimal animal)
    {
        if (_animals.Count >= MaxCapacity)
        {
            Console.WriteLine($"Cannot add {animal.Name} to {Name}. Enclosure is at maximum capacity.");
            return false;
        }

        _animals.Add(animal);
        animal.Enclosure = this;
        Console.WriteLine($"{animal.Name} added to {Name}");
        return true;
    }

    public bool RemoveAnimal(IAnimal animal)
    {
        var removed = _animals.Remove(animal);
        if (!removed) return removed;

        animal.Enclosure = null!;
        Console.WriteLine($"{animal.Name} removed from {Name}");
        return removed;
    }

    public void Maintain()
    {
        _lastMaintenanceDate = DateTime.Now;
        Console.WriteLine($"Enclosure {Name} has been maintained");
    }

    public string GetInventoryInfo()
    {
        return $"{Name}, Type: {Type}, Area: {Area}m², Capacity: {_animals.Count}/{MaxCapacity}, " +
               $"Last maintenance: {(_lastMaintenanceDate == DateTime.MinValue ? "Never" : _lastMaintenanceDate.ToString(CultureInfo.InvariantCulture))}";
    }
}
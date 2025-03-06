namespace Prototype;

public class Virus(string name, int age, double weight, string species) : ICloneable
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public double Weight { get; set; } = weight;
    public string Species { get; set; } = species;
    public List<Virus> Children { get; set; } = [];

    public object Clone()
    {
        var clone = new Virus(Name, Age, Weight, Species)
        {
            Children = Children.Select(child => (Virus)child.Clone()).ToList()
        };
        return clone;
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public void GetFamilyInfo(int level = 0)
    {
        var indent = new string('.', level * 2);
        Console.WriteLine(
            $"{indent}Virus: {Name}, Age: {Age}, Weight: {Weight}, ({Species}), Children: {Children.Count}");
        foreach (var child in Children)
        {
            child.GetFamilyInfo(level + 1);
        }
    }
}
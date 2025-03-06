using Prototype;

var grandparent = new Virus("AlphaVirus", 10, 1.0, "Type1");

var parent1 = new Virus("Parent1",5, 0.8, "Type2");
var parent2 = new Virus("Parent2",6, 0.9, "Type3");
grandparent.AddChild(parent1);
grandparent.AddChild(parent2);

var child1 = new Virus("Child1", 2, 0.5, "Type4");
var child2 = new Virus("Child2", 3, 0.6, "Type5");
parent1.AddChild(child1);
parent1.AddChild(child2);

var child3 = new Virus("Child3", 4, 0.7,  "Type6");
parent2.AddChild(child3);

Console.WriteLine("---> Original virus family <---");
grandparent.GetFamilyInfo();

var clonedGrandparent = (Virus)grandparent.Clone();

grandparent.Name = "NewAlphaVirus";
grandparent.Children[0].Name = "NewParent1";
grandparent.Children[0].Children[0].Name = "NewChild1";

Console.WriteLine("\n---> Cloned virus family <---");
clonedGrandparent.GetFamilyInfo();

Console.WriteLine("\n---> Changed original family <---");
grandparent.GetFamilyInfo();

Console.WriteLine("\n---> Independence check <---");
Console.WriteLine($"grandparent == clonedGrandparent: {ReferenceEquals(grandparent, clonedGrandparent)}");
Console.WriteLine($"grandparent.Children[0] == clonedGrandparent.Children[0]: {ReferenceEquals(grandparent.Children[0], clonedGrandparent.Children[0])}");
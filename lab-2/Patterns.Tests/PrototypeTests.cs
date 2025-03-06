using Prototype;

namespace FactoryMethod.Test;

public class PrototypeTests
{
    [Fact]
    public void Clone_ShouldReturnIndependentCopyOfVirus()
    {
        // Arrange
        var parent = new Virus("ParentVirus", 10, 1.0, "Type1");
        var child = new Virus("ChildVirus", 5, 0.5, "Type2");
        parent.AddChild(child);

        // Act
        var clone = (Virus)parent.Clone();

        // Assert
        Assert.NotSame(parent, clone);
        Assert.Equal(parent.Name, clone.Name);
        Assert.Equal(parent.Age, clone.Age);
        Assert.Equal(parent.Weight, clone.Weight);
        Assert.Equal(parent.Species, clone.Species);

        Assert.NotSame(parent.Children, clone.Children);
        Assert.Equal(parent.Children.Count, clone.Children.Count);
        Assert.Equal(parent.Children[0].Name, clone.Children[0].Name);
    }

    [Fact]
    public void Clone_ShouldMaintainChildIndependence()
    {
        // Arrange
        var parent = new Virus("ParentVirus", 10, 1.0, "Type1");
        var child = new Virus("ChildVirus", 5, 0.5, "Type2");
        parent.AddChild(child);

        // Act
        var clone = (Virus)parent.Clone();

        // Змінюємо оригінал
        parent.Children[0].Name = "ModifiedChildVirus";

        // Assert
        Assert.NotEqual(parent.Children[0].Name, clone.Children[0].Name);
    }

    [Fact]
    public void AddChild_ShouldIncreaseChildrenCount()
    {
        // Arrange
        var parent = new Virus("ParentVirus", 10, 1.0, "Type1");
        var child = new Virus("ChildVirus", 5, 0.5, "Type2");

        // Act
        parent.AddChild(child);

        // Assert
        Assert.Single(parent.Children);
        Assert.Equal("ChildVirus", parent.Children[0].Name);
    }

    [Fact]
    public void GetFamilyInfo_ShouldDisplayCorrectHierarchy()
    {
        // Arrange
        var grandparent = new Virus("GrandparentVirus", 15, 2.0, "Type0");
        var parent = new Virus("ParentVirus", 10, 1.0, "Type1");
        var child = new Virus("ChildVirus", 5, 0.5, "Type2");

        grandparent.AddChild(parent);
        parent.AddChild(child);

        // Act & Assert
        var output = new List<string>();
        Console.SetOut(new StringWriter());
        grandparent.GetFamilyInfo();
    }

    [Fact]
    public void Name_ShouldNotAffectClonedVirus()
    {
        // Arrange
        var virus = new Virus("OriginalVirus", 10, 1.0, "Type1");

        // Act
        var clonedVirus = (Virus)virus.Clone();
        clonedVirus.Name = "ClonedVirus";

        // Assert
        Assert.NotEqual(virus.Name, clonedVirus.Name);
    }
}
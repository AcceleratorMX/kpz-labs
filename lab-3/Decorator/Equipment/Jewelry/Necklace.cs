using Decorator.Interfaces;

namespace Decorator.Equipment.Jewelry;

public class Necklace(ICharacter character) : Decorator(character)
{
    private readonly ICharacter _character = character;
    public override List<string> GetEquipment() => [.._character.GetEquipment(), GetType().Name];
    public override int GetMDef() => _character.GetMDef() + 7;

}
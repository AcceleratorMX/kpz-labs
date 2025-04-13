using Decorator.Interfaces;

namespace Decorator.Equipment.Armor;

public class HeavyArmor(ICharacter character) : Decorator(character)
{
    private readonly ICharacter _character = character;
    public override List<string> GetEquipment() => [.._character.GetEquipment(), GetType().Name.SplitPascalCase()];
    public override int GetPDef() => _character.GetPDef() + 40;
}
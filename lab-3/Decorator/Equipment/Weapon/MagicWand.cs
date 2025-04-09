using Decorator.Interfaces;

namespace Decorator.Equipment.Weapon;

public class MagicWand(ICharacter character) : Decorator(character)
{
    private readonly ICharacter _character = character;
    public override List<string> GetEquipment() => [.._character.GetEquipment(), GetType().Name.SplitPascalCase()];
    public override int GetPAttack() => _character.GetPAttack() + 25;
    public override int GetMAttack() => _character.GetMAttack() + 50;
}
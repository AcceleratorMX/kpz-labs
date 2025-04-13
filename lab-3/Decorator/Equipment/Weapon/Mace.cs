using Decorator.Interfaces;

namespace Decorator.Equipment.Weapon;

public class Mace(ICharacter character) : Decorator(character)
{
    private readonly ICharacter _character = character;
    public override List<string> GetEquipment() => [.._character.GetEquipment(), GetType().Name];
    public override int GetPAttack() => _character.GetPAttack() + 40;
    public override int GetMAttack() => _character.GetMAttack() + 35;
}
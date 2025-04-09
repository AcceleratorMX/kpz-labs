using Decorator.Interfaces;

namespace Decorator.Equipment.Weapon;

public class Sword(ICharacter character) : Decorator(character)
{
    private readonly ICharacter _character = character;
    // public override string GetCharClass() => $"{_character.GetCharClass()} + {GetType().Name}";

    public override List<string> GetEquipment() => [.._character.GetEquipment(), GetType().Name];
    public override int GetPAttack() => _character.GetPAttack() + 50;
    public override int GetMAttack() => _character.GetMAttack() + 25;
}
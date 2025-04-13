using Builder.Entities;
using Builder.Enums;

namespace Builder.Interfaces;

public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetCharClass(CharacterClass charClass);
    ICharacterBuilder SetAttackType(AttackType attackType);
    ICharacterBuilder SetSpecialAbility(string specialAbility);
    Character Build();
}
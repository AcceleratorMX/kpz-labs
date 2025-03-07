using Builder.Entities;
using Builder.Enums;
using Builder.Interfaces;

namespace Builder.Builder;

public class EnemyBuilder : ICharacterBuilder
{
    private readonly Character _character = new Character();

    public ICharacterBuilder SetName(string name)
    {
        _character.Name = name;
        return this;
    }

    public ICharacterBuilder SetCharClass(CharacterClass charClass)
    {
        _character.CharClass = charClass;
        return this;
    }

    public ICharacterBuilder SetAttackType(AttackType attackType)
    {
        _character.AttackType = attackType;
        return this;
    }
    
    public ICharacterBuilder SetSpecialAbility(string debuff)
    {
        _character.Debuff = debuff;
        return this;
    }

    public Character Build() => _character;
}
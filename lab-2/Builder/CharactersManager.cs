using Builder.Entities;
using Builder.Enums;
using Builder.Interfaces;

namespace Builder;

public class CharactersManager(ICharacterBuilder builder)
{
    public Character CreateHero()
    {
        return builder
            .SetName("Hero")
            .SetCharClass(CharacterClass.Paladin)
            .SetAttackType(AttackType.Melee)
            .SetSpecialAbility("Heroic Valor")
            .Build();
    }

    public Character CreateEnemy()
    {
        return builder
            .SetName("Enemy")
            .SetCharClass(CharacterClass.Warlock)
            .SetAttackType(AttackType.Magic)
            .SetSpecialAbility("Disable Starlink terminals")
            .Build();
    }
}
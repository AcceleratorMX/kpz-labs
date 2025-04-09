using Decorator.Enums;
using Decorator.Interfaces;

namespace Decorator.Characters;

public class Warrior : ICharacter
{
    public string GetCharClass() => CharClass.Warrior.ToString();
    public List<string> GetEquipment() => [];
    public int GetPAttack() => 10;
    public int GetMAttack() => 5;
    public int GetPDef() => 8;
    public int GetMDef() => 5;

}
using Decorator.Enums;
using Decorator.Interfaces;

namespace Decorator.Characters;

public class Paladin : ICharacter
{
    public string GetCharClass() => CharClass.Paladin.ToString();
    public List<string> GetEquipment() => [];
    public int GetPAttack() => 8;
    public int GetMAttack() => 7;
    public int GetPDef() => 10;
    public int GetMDef() => 30;
}
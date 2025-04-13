using Decorator.Enums;
using Decorator.Interfaces;

namespace Decorator.Characters;

public class Mage : ICharacter
{
    public string GetCharClass() => CharClass.Mage.ToString();
    public List<string> GetEquipment() => [];
    public int GetPAttack() => 5;
    public int GetMAttack() => 10;
    public int GetPDef() => 5;
    public int GetMDef() => 15; 
}
using Decorator.Interfaces;

namespace Decorator.Equipment;

public class Decorator(ICharacter character) : ICharacter
{
    public virtual string GetCharClass() => character.GetCharClass();
    public virtual List<string> GetEquipment() => character.GetEquipment();
    public virtual int GetPAttack() => character.GetPAttack();
    public virtual int GetMAttack() => character.GetMAttack();
    public virtual int GetPDef() => character.GetPDef();
    public virtual int GetMDef() => character.GetMDef(); 
}
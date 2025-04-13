using System.Text;
using Builder.Enums;

namespace Builder.Entities;

public class Character
{
    public string Name { get; set; } = string.Empty;
    public CharacterClass CharClass { get; set; }
    public AttackType AttackType { get; set; }
    public string Buff { get; set; } = string.Empty;
    public string Debuff { get; set; } = string.Empty;

    public override string ToString()
    {
        var sb = new StringBuilder()
            .AppendLine($"Name: {Name}")
            .AppendLine($"Class: {CharClass}")
            .AppendLine($"Attack Type: {AttackType}");

        if (!string.IsNullOrEmpty(Buff))
            sb.AppendLine($"Buff: {Buff}");

        if (!string.IsNullOrEmpty(Debuff))
            sb.AppendLine($"Debuff: {Debuff}");

        return sb.ToString();
    }
}
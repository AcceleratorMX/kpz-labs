using Builder;
using Builder.Builder;
using Builder.Entities;
using Builder.Enums;

namespace FactoryMethod.Test;

public class BuilderTests
{
    [Fact]
    public void Character_SetValues_AreSet()
    {
        // Arrange
        var character = new Character
        {
            Name = "Test",
            CharClass = CharacterClass.Paladin,
            AttackType = AttackType.Melee,
            Buff = "Buff",
            Debuff = "Debuff"
        };

        // Assert
        Assert.Equal("Test", character.Name);
        Assert.Equal(CharacterClass.Paladin, character.CharClass);
        Assert.Equal(AttackType.Melee, character.AttackType);
        Assert.Equal("Buff", character.Buff);
        Assert.Equal("Debuff", character.Debuff);
    }

    [Fact]
    public void Character_ToString_ReturnsCorrectString()
    {
        // Arrange
        var character = new Character
        {
            Name = "Test",
            CharClass = CharacterClass.Paladin,
            AttackType = AttackType.Melee,
            Buff = "Buff",
            Debuff = "Debuff"
        };

        // Act
        var result = character.ToString();

        // Assert
        Assert.Contains("Name: Test", result);
        Assert.Contains("Class: Paladin", result);
        Assert.Contains("Attack Type: Melee", result);
        Assert.Contains("Buff: Buff", result);
        Assert.Contains("Debuff: Debuff", result);
    }
    
    [Fact]
    public void HeroBuilder_SetName_SetsName()
    {
        // Arrange
        var builder = new HeroBuilder();

        // Act
        builder.SetName("Test");

        // Assert
        Assert.Equal("Test", builder.Build().Name);
    }

    [Fact]
    public void HeroBuilder_SetCharClass_SetsCharClass()
    {
        // Arrange
        var builder = new HeroBuilder();

        // Act
        builder.SetCharClass(CharacterClass.Paladin);

        // Assert
        Assert.Equal(CharacterClass.Paladin, builder.Build().CharClass);
    }

    [Fact]
    public void HeroBuilder_SetAttackType_SetsAttackType()
    {
        // Arrange
        var builder = new HeroBuilder();

        // Act
        builder.SetAttackType(AttackType.Melee);

        // Assert
        Assert.Equal(AttackType.Melee, builder.Build().AttackType);
    }

    [Fact]
    public void HeroBuilder_SetSpecialAbility_SetsBuff()
    {
        // Arrange
        var builder = new HeroBuilder();

        // Act
        builder.SetSpecialAbility("Buff");

        // Assert
        Assert.Equal("Buff", builder.Build().Buff);
    }

    [Fact]
    public void HeroBuilder_Build_ReturnsCharacter()
    {
        // Arrange
        var builder = new HeroBuilder();

        // Act
        var character = builder.Build();

        // Assert
        Assert.IsType<Character>(character);
    }
    
    [Fact]
    public void EnemyBuilder_SetName_SetsName()
    {
        // Arrange
        var builder = new EnemyBuilder();

        // Act
        builder.SetName("Test");

        // Assert
        Assert.Equal("Test", builder.Build().Name);
    }

    [Fact]
    public void EnemyBuilder_SetCharClass_SetsCharClass()
    {
        // Arrange
        var builder = new EnemyBuilder();

        // Act
        builder.SetCharClass(CharacterClass.Warlock);

        // Assert
        Assert.Equal(CharacterClass.Warlock, builder.Build().CharClass);
    }

    [Fact]
    public void EnemyBuilder_SetAttackType_SetsAttackType()
    {
        // Arrange
        var builder = new EnemyBuilder();

        // Act
        builder.SetAttackType(AttackType.Magic);

        // Assert
        Assert.Equal(AttackType.Magic, builder.Build().AttackType);
    }

    [Fact]
    public void EnemyBuilder_SetSpecialAbility_SetsDebuff()
    {
        // Arrange
        var builder = new EnemyBuilder();

        // Act
        builder.SetSpecialAbility("Debuff");

        // Assert
        Assert.Equal("Debuff", builder.Build().Debuff);
    }
    
    [Fact]
    public void EnemyBuilder_Build_ReturnsCharacter()
    {
        // Arrange
        var builder = new EnemyBuilder();

        // Act
        var character = builder.Build();

        // Assert
        Assert.IsType<Character>(character);
    }

    [Fact]
    public void CharactersManager_CreateHero_ReturnsHero()
    {
        // Arrange
        var builder = new HeroBuilder();
        var manager = new CharactersManager(builder);

        // Act
        var hero = manager.CreateHero();

        // Assert
        Assert.IsType<Character>(hero);
        Assert.Equal("Hero", hero.Name);
        Assert.Equal(CharacterClass.Paladin, hero.CharClass);
        Assert.Equal(AttackType.Melee, hero.AttackType);
        Assert.Equal("Heroic Valor", hero.Buff);
    }

    [Fact]
    public void CharactersManager_CreateEnemy_ReturnsEnemy()
    {
        // Arrange
        var builder = new EnemyBuilder();
        var manager = new CharactersManager(builder);

        // Act
        var enemy = manager.CreateEnemy();

        // Assert
        Assert.IsType<Character>(enemy);
        Assert.Equal("Enemy", enemy.Name);
        Assert.Equal(CharacterClass.Warlock, enemy.CharClass);
        Assert.Equal(AttackType.Magic, enemy.AttackType);
        Assert.Equal("Disable Starlink terminals", enemy.Debuff);
    }
}
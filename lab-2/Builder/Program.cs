using Builder;
using Builder.Builder;

var heroManager = new CharactersManager(new HeroBuilder());
var enemyManager = new CharactersManager(new EnemyBuilder());

var hero = heroManager.CreateHero();
var enemy = enemyManager.CreateEnemy();

Console.WriteLine(hero);
Console.WriteLine(enemy);
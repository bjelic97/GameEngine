using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact(Skip = "No need to run this")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie King", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie King", true);

            // Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");


            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new();

            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new();

            Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));
        }
    }
}

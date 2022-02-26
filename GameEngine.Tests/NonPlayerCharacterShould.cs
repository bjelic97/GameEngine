using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamageInternal(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamageExternal(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        [HealthDamageData]
        public void TakeDamageCustomAttribute(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}

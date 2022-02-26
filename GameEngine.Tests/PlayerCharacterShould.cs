using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;
        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _sut = new PlayerCharacter();
            _output = output;
            _output.WriteLine("Creating character");
        }
        public void Dispose()
        {
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
            //_sut.Dispose();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Brale";
            _sut.LastName = "Braletic";

            Assert.Equal("Brale Braletic", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {

            _sut.FirstName = "Brale";
            _sut.LastName = "Braletic";

            Assert.StartsWith("Brale", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.FirstName = "Brale";
            _sut.LastName = "Braletic";

            Assert.EndsWith("Braletic", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            _sut.FirstName = "BRALE";
            _sut.LastName = "BRALETIC";

            Assert.Equal("Brale Braletic", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _sut.FirstName = "Brale";
            _sut.LastName = "Braletic";

            Assert.Contains("le Br", _sut.FullName);
        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Brale";
            _sut.LastName = "Braletic";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep();

            // Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_sut.NickName);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            // Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }
    }
}
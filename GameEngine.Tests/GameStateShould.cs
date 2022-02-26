using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStatefixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStatefixture, ITestOutputHelper output)
        {
            _gameStatefixture = gameStatefixture;
            _output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID = {_gameStatefixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStatefixture.State.Players.Add(player1);
            _gameStatefixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            _gameStatefixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID = {_gameStatefixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStatefixture.State.Players.Add(player1);
            _gameStatefixture.State.Players.Add(player2);

            _gameStatefixture.State.Reset();
            Assert.Empty(_gameStatefixture.State.Players);
        }
    }
}

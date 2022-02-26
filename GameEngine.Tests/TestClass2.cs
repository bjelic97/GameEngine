using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    public class TestClass2
    {
        private readonly GameStateFixture _gameStatefixture;
        private readonly ITestOutputHelper _output;

        public TestClass2(GameStateFixture gameStatefixture, ITestOutputHelper output)
        {
            _gameStatefixture = gameStatefixture;
            _output = output;
        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"GameState ID = {_gameStatefixture.State.Id}");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"GameState ID = {_gameStatefixture.State.Id}");
        }
    }
}

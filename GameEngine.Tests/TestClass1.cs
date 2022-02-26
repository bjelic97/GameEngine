using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    public class TestClass1
    {
        private readonly GameStateFixture _gameStatefixture;
        private readonly ITestOutputHelper _output;

        public TestClass1(GameStateFixture gameStatefixture, ITestOutputHelper output)
        {
            _gameStatefixture = gameStatefixture;
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            _output.WriteLine($"GameState ID = {_gameStatefixture.State.Id}");
        }

        [Fact]
        public void Test2()
        {
            _output.WriteLine($"GameState ID = {_gameStatefixture.State.Id}");
        }
    }
}

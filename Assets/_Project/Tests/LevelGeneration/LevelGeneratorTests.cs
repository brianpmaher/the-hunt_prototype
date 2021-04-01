using NUnit.Framework;
using TheHunt.LevelGeneration;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Pass;

namespace Tests.LevelGeneration
{
    [TestFixture]
    public class LevelGeneratorTests
    {
        [Test]
        public void ShouldGenerateALevel()
        {
            var gridLevel = new GridLevel(5, 5);
            var levelGenerator = new LevelGenerator(gridLevel);
            var playerPlacementGenerationPass = new PlayerPlacementGenerationPass();

            var level = levelGenerator.RunPass(playerPlacementGenerationPass);
            
            Assert.NotNull(level);
        }
    }
}
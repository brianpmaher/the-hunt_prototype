using TheHunt.LevelGeneration.Level;

namespace TheHunt.LevelGeneration.Pass
{
    public interface IGenerationPass
    {
        public ILevel RunPass(ILevel level);
    }
}
using TheHunt.LevelGeneration.Pass;

namespace TheHunt.LevelGeneration
{
    public class LevelGenerator
    {
        private readonly ILevel _level;
        
        public LevelGenerator(ILevel level) 
        {
            _level = level;
        }

        public LevelGenerator RunPass(IGenerationPass generationPass)
        {
            generationPass.RunPass(_level);

            return this;
        }
    }
}
namespace TheHunt.LevelGeneration
{
    public interface IGenerationPass
    {
        public ILevel RunPass(ILevel level);
    }
}
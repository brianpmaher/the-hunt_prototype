namespace TheHunt.LevelGeneration
{
    public interface ILevel
    {
        public IRoom[] GetRooms();
        public IRoomConnection[][] GetConnections();
    }
}
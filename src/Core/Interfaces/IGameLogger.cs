using BoardgameRecommender.Core;

public interface IGameLogger
{
    public void StartSession(string serialNumber);
    public void EndSession(string serialNumber);
    public void LogEntry(Boardgame boardgame);
}
using BoardgameRecommender.Core;
public class JsonLogger : IGameLogger
{
    public void EndSession(string serialNumber)
    {
        
    }

    public void LogEntry(Boardgame boardgame)
    {
        Console.WriteLine(boardgame.Title);
    }

    public void StartSession(string serialNumber)
    {
        
    }
}
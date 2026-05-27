using BoardgameRecommender.Core;

public interface IGameLogger
{
    public string SaveGame(Boardgame boardgame);
    public List<Boardgame> GetFullGamesList();
}
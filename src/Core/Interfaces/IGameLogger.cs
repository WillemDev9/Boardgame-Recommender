using BoardgameRecommender.Core;

public interface IGameLogger
{
    public SaveGameResult SaveGame(Boardgame boardgame);
    public DeleteGameResult DeleteGame(Boardgame boardgame);
    public List<Boardgame> GetFullGamesList();
}
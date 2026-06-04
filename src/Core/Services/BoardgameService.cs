using BoardgameRecommender.Core;

public class BoardgameService
{
    IGameLogger _gameLogger;


    public BoardgameService(IGameLogger gameLogger)
    {
        _gameLogger = gameLogger;

    }

    public SaveGameResult SaveNewGame(Boardgame boardgame)
    {
        return _gameLogger.SaveGame(boardgame);

    }
    public List<Boardgame> GetFullGameList() => _gameLogger.GetFullGamesList();

}
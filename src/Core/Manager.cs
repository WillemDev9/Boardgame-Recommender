using BoardgameRecommender.Core;

public class Manager
{
    IGameLogger _gameLogger;


    public Manager(IGameLogger gameLogger)
    {
        _gameLogger = gameLogger;

    }

    public void SaveNewGame(IUiOutputTarget uiOutputTarget, Boardgame boardgame)
    {
        string successMessage = _gameLogger.SaveGame(boardgame);

        uiOutputTarget.DisplayMessage(successMessage);
    }
    public List<Boardgame> GetFullGameList() => _gameLogger.GetFullGamesList();

}
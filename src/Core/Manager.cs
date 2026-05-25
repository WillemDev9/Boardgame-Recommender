using System.Diagnostics.Contracts;
using BoardgameRecommender.Core;

public class Manager
{
    IGameLogger _gameLogger;
    IUiInputSource _uiInputSource;
    IUiOutputTarget _uiOutputTarget;

    public Manager(IGameLogger gameLogger, IUiInputSource uiInputSource, IUiOutputTarget uiOutputTarget)
    {
        _gameLogger = gameLogger;
        _uiInputSource = uiInputSource;
        _uiOutputTarget = uiOutputTarget;

        _uiInputSource.BoardgameCreated += LogNewGame;
    }

    private void LogNewGame(Boardgame boardgame)
    {
        _gameLogger.LogEntry(boardgame);
    }
}
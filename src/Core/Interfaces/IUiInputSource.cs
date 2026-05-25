using BoardgameRecommender.Core;

public interface IUiInputSource
{
    public event Action<Boardgame>? BoardgameCreated;
    public void Launch();
}
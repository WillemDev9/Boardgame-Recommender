 using BoardgameRecommender.Core;
public interface IUiOutputTarget
{
    public void DisplayGames(List<Boardgame> boardgameList);
}
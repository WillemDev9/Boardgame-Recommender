using BoardgameRecommender.Core;

public class ConsoleUI : IUiInputSource, IUiOutputTarget
{
    public event Action<Boardgame>? BoardgameCreated;

    public void DisplayGames(List<Boardgame> boardgameList)
    {
        
    }

    public void Launch()
    {
        Boardgame testGame = new ("dinoIsland", "Dinosaur Island", 1, 4, new List<Tag>()
        {
            new Tag("theme_dino", "Theme: Dinosaur", TagCategory.Theme),
            new Tag("mech_worker","Mechanic: Worker Placement", TagCategory.Mechanic)
        });

        BoardgameCreated?.Invoke(testGame);
    }
}


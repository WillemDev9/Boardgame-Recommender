using BoardgameRecommender.Core;

public class GetCatalogCommand : IConsoleCommand
{
    Manager _manager;
    ConsoleUI _consoleUI;
    public GetCatalogCommand(ConsoleUI consoleUI, Manager manager)
    {
        _manager = manager;
        _consoleUI = consoleUI;
    }
    public string menuText => "Get Entire Catalog";

    public void Execute()
    {
        Console.Clear();
        List<Boardgame> gameList = _manager.GetFullGameList();

        foreach(Boardgame game in gameList)
        {
            Console.WriteLine(game.Title + "\n");
        }
    }
}
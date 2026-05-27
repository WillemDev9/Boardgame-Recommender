using BoardgameRecommender.Core;

public class ConsoleUI : IUiInputSource, IUiOutputTarget
{
    private List<IConsoleCommand> _consoleCommandList;
    public event Action<Boardgame>? BoardgameCreated;
    public ConsoleUI(Manager manager)
    {
        _consoleCommandList = [
            new AddGameCommand(this, manager),
            new GetRecommendationCommand(this, manager),
            new GetCatalogCommand(this, manager)
        ];
    }
    
    public void AddNewBoardgame(Boardgame newGame)
    {
        BoardgameCreated?.Invoke(newGame);
    }
    public void Launch()
    {
        while(true)
        {
            int option = ShowMenu();
            _consoleCommandList[option-1].Execute();
        }
    }

    private int ShowMenu()
    {
        for (int i = 0; i < _consoleCommandList.Count; i++)
        {
            Console.WriteLine($"{i+1} {_consoleCommandList[i].menuText}");
        }

        return MenuSelection(1,_consoleCommandList.Count);

    }

    private int MenuSelection(int minValue, int maxValue)
    {
        while(true)
        {
            string? input = Console.ReadLine();

            if(input == null) continue;

            if(int.TryParse(input, out int result))
            {
                if(result >= minValue && result <= maxValue)
                {
                    return result;
                }
            }

            Console.WriteLine("Please select a valid number and hit Enter");
        }
    }
    public void DisplayGames(List<Boardgame> boardgameList) 
    {
        
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}


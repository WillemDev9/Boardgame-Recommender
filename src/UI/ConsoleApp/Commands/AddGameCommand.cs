using BoardgameRecommender.Core;

public class AddGameCommand : IConsoleCommand
{
    Manager _manager;
    ConsoleUI _consoleUI;
    public AddGameCommand(ConsoleUI consoleUI, Manager manager)
    {
        _consoleUI = consoleUI;
        _manager = manager;
    }
    public string menuText => "Add new game to catalog";

    public void Execute()
    {
        string id;
        string title;
        int minPlayerCount;
        int maxPlayerCount;
        GameDurationEnum gameDuration;

        Console.Clear();
        
        Console.WriteLine("---ADD NEW GAME---\n\n");

        title = ReadString("Enter name of game:\n");
        id = BuildID(title);

        minPlayerCount = ReadInt("Enter Minimum Number of Players");
        maxPlayerCount = ReadInt("Enter Maximum number of Players", minPlayerCount);

        gameDuration = ReadSelection("Select the Rough Duration of the Game",Enum.GetValues<GameDurationEnum>().Length);

        Boardgame newGame = new(id, title, minPlayerCount, maxPlayerCount, gameDuration);

        _manager.SaveNewGame(_consoleUI, newGame);
    }

    private GameDurationEnum ReadSelection(string message, int options)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);

            for (int i = 0; i < options; i++)
            {
                Console.WriteLine($"{i+1} {(GameDurationEnum)i}");
            }

            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid entry. Press any key to try again");
                Console.ReadKey();

                continue;
            }

            if(int.TryParse(input, out int result))
            {
                int choiceIndex = result -1;

                if(choiceIndex >=0 && result < options)
                {
                    return (GameDurationEnum)choiceIndex;
                }
            }
            else
            {
                Console.WriteLine("Please enter the number of the option you'd liek to choose");
                Console.ReadKey();
            }
        }
    }

    private int ReadInt(string message, int minValue = 1)
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            
            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid entry. Press any key to try again");
                Console.ReadKey();

                continue;
            }

            if(int.TryParse(input, out int result))
            {
                if(result >= minValue )
                {
                    return result;
                }
                Console.WriteLine($"Entry must be at least {minValue}. Hit any key and try again");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter a valid whole number. Hit any key to try again");
                Console.ReadKey();
            }
        }
    }

    private string BuildID(string title)
    {
        string titleWithUnderscores = title.Replace(' ', '_');
        
        var cleanChars = titleWithUnderscores.Where(c => char.IsLetterOrDigit(c) || c ==' ');
        string gameId = string.Concat(cleanChars).ToLowerInvariant();

        return gameId;
    }

    private string ReadString(string message)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine(message);
            
            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid entry. Press any key to try again");
                Console.ReadKey();

                continue;
            }

            
            return input.Trim();
        }

    }
}
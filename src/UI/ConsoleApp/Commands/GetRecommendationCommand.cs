using BoardgameRecommender.Core;

public class GetRecommendationCommand : IConsoleCommand
{
    ConsoleUI _consoleUI;
    BoardgameService _manager;
    public GetRecommendationCommand(ConsoleUI consoleUi, BoardgameService manager)
    {
        _consoleUI = consoleUi;
        _manager = manager;
    }
    public string menuText => "Get Game Recommendations";

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("---Game Recommendation---\n\n");

        List<Boardgame> gameList = _manager.GetFullGameList();

        int playerCount = ReadPlayerCount();
        GameDurationEnum duration = ReadDuration();

        List<Boardgame> recommendedList = GenerateGameRecommendations(gameList, playerCount, duration);

        Console.Clear();

        if(recommendedList.Count > 0)
        {

            for (int i = 0; i < recommendedList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {recommendedList[i].Title}, Players: {recommendedList[i].MinPlayerCount} - {recommendedList[i].MaxPlayerCount}, Duration: {recommendedList[i].GameDuration}");
                
            }

            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("There are no games that fit the criteria in your collection");
        }
    }

    private int ReadPlayerCount()
    {
        while(true)
        {    
            Console.WriteLine("How Many Players are plying?");
            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please Enter a valid entry. Press any key to try again.");
                Console.ReadKey();

                continue;
            }

            if(int.TryParse(input, out int result))
            {
                if(result > 0)
                {
                    return result;
                }

                Console.WriteLine("Please Enter a whole number larger than 0");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter a valid whoel number. Hit any key to try again.");
            }
        }
    }

    private GameDurationEnum ReadDuration()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Please select the desired duration");

            for(int i = 0; i < Enum.GetValues<GameDurationEnum>().Length; i++)
            {
                Console.WriteLine($"{i+1} {(GameDurationEnum)i}");
            }

            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please select a valid entry. Hit anhy key to try again");
                Console.ReadKey();
            }

            if(int.TryParse(input, out int result))
            {
                int choiceIndex = result -1;

                if(choiceIndex >=0 && choiceIndex < Enum.GetValues<GameDurationEnum>().Length)
                {
                    return (GameDurationEnum)choiceIndex;
                }
            }
            else
            {
                Console.WriteLine("Please enter the number of the option you'd like");
            }
        }
    }
    private List<Boardgame> GenerateGameRecommendations(List<Boardgame> gameList, int playerCount, GameDurationEnum duration)
    {
        List<Boardgame> allMatchesList = new();

        foreach(Boardgame game in gameList)
        {
            if(playerCount >= game.MinPlayerCount && playerCount <= game.MaxPlayerCount)
            {
                if(game.GameDuration == duration)
                {
                    allMatchesList.Add(game);
                }
            }
        }

        Random random = new();

        List<Boardgame> randomizedTop5 = allMatchesList.OrderBy(_ => random.Next()).Take(5).ToList();

        return randomizedTop5;
    }
}
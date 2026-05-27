public class GetRecommendationCommand : IConsoleCommand
{
    ConsoleUI _consoleUI;
    public GetRecommendationCommand(ConsoleUI consoleUi, Manager manager)
    {
        _consoleUI = consoleUi;
    }
    public string menuText => "Get Game Recommendations";

    public void Execute()
    {
        Console.WriteLine("Getting Game Recommendations!");
    }
}
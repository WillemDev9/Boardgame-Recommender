public class GetCatalogCommand : IConsoleCommand
{
    ConsoleUI _consoleUI;
    public GetCatalogCommand(ConsoleUI consoleUI)
    {
        _consoleUI = consoleUI;
    }
    public string menuText => "Get Entire Catalog";

    public void Execute()
    {
        Console.WriteLine("Getting Entire Catalog!");
    }
}
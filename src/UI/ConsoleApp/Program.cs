
Console.WriteLine("=== Boardgame Recommender Startup ===");

IGameLogger logger = new JsonLogger(Microsoft.Extensions.Logging.Abstractions.NullLogger<JsonLogger>.Instance);
BoardgameService manager = new(logger);
ConsoleUI consoleUI = new(manager);


Console.WriteLine("Launching UI and firing test event");
consoleUI.Launch();

Console.WriteLine("Execution Finished");

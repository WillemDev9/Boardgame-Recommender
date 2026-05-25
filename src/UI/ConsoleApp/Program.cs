
Console.WriteLine("=== Boardgame Recommender Startup ===");

ConsoleUI consoleUI = new();
JsonLogger jsonLogger = new();

Manager manager = new(jsonLogger, consoleUI, consoleUI);

Console.WriteLine("Launching UI and firing test event");
consoleUI.Launch();

Console.WriteLine("Exceution Finished");


Console.WriteLine("=== Boardgame Recommender Startup ===");

JsonLogger jsonLogger = new();
Manager manager = new(jsonLogger);
ConsoleUI consoleUI = new(manager);


Console.WriteLine("Launching UI and firing test event");
consoleUI.Launch();

Console.WriteLine("Exceution Finished");

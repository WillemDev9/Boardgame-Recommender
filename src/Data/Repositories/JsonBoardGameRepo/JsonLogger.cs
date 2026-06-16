using System.Text.Json;
using BoardgameRecommender.Core;
using Microsoft.Extensions.Logging;
public class JsonLogger : IGameLogger
{
    public readonly string _filePath;
    List<Boardgame> _boardgameList;

    private readonly ILogger<JsonLogger> _logger;

    public JsonLogger(ILogger<JsonLogger> logger)
    {
        _logger = logger;

        string _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = Path.Combine(_appDataPath, "BoardgameRecommender");

        _filePath = Path.Combine(appFolder, "games.json");

        if(!Directory.Exists(appFolder))
        {
            _logger.LogInformation("The folder doesn't exist, creating new folder at {}", appFolder);
            Directory.CreateDirectory(appFolder);
        }
        _boardgameList = GetListFromFile();

        // JsonSeeder seeder = new(this);
        // seeder.SeedCatalog(50);
        

    }

    public List<Boardgame> GetFullGamesList()
    {
        return _boardgameList;
    }

    public SaveGameResult SaveGame(Boardgame boardgame)
    {
        bool idExists = _boardgameList.Any(g =>g.ID.Equals(boardgame.ID, StringComparison.OrdinalIgnoreCase));
        string resultMessage = "";
        bool isSuccess = false;

        if(!idExists)
        {
            _boardgameList.Add(boardgame);
            if(SaveListToFile())
            {
                resultMessage = $"{boardgame.Title} added to the catalog";
                isSuccess = true;
            }
            else
            {
                resultMessage = "An error occured while saving the file";

            }

        }
        else
        {
            resultMessage = $"{boardgame.Title} is already in your catalog";

        }

        return new SaveGameResult(isSuccess, resultMessage);

    }
    public DeleteGameResult DeleteGame(Boardgame boardgame)
    {
        string resultMessage = "";
        bool isSuccess = false;

        var itemToRemove = _boardgameList.FirstOrDefault(g => g.ID == boardgame.ID);

        if(itemToRemove != null)
        {
            _boardgameList.Remove(itemToRemove);
        }

        if(SaveListToFile())
        {
            resultMessage = $"{boardgame.Title} removed from teh catalog";
            isSuccess = true;
        }
        else
        {
            resultMessage = "An error occured while updating the file";
        }

        return new DeleteGameResult(isSuccess, resultMessage);
    }

    private List<Boardgame> GetListFromFile()
    {
        if(!File.Exists(_filePath))
        {
            Console.WriteLine("There is no existing catalog, creating new catalog");
            return new List<Boardgame>();
        }

        string jsonString = File.ReadAllText(_filePath);

        List<Boardgame>? catalog = JsonSerializer.Deserialize<List<Boardgame>>(jsonString);

        return catalog ?? new List<Boardgame>();
    }

    private bool SaveListToFile()
    {
        try
        {
            JsonSerializerOptions options = new(){WriteIndented = true};
            string jsonString = JsonSerializer.Serialize(_boardgameList, options);
            File.WriteAllText(_filePath, jsonString);
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }


}
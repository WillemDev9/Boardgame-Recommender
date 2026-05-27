using System.Text.Json;
using System.Threading.Channels;
using BoardgameRecommender.Core;
public class JsonLogger : IGameLogger
{
    public readonly string _filePath;
    List<Boardgame> _boardgameList;

    public JsonLogger()
    {
        string _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = Path.Combine(_appDataPath, "BoardgameRecommender");

        _filePath = Path.Combine(appFolder, "games.json");

        if(!Directory.Exists(appFolder))
        {
            Console.WriteLine("The folder doesn't exist, creating new folder");
            Directory.CreateDirectory(appFolder);
        }

        _boardgameList = GetListFromFile();
    }

    public List<Boardgame> GetFullGamesList()
    {
        return _boardgameList;
    }

    public string SaveGame(Boardgame boardgame)
    {
        bool idExists = _boardgameList.Any(g =>g.ID.Equals(boardgame.ID, StringComparison.OrdinalIgnoreCase));

        if(!idExists)
        {
            _boardgameList.Add(boardgame);
            if(SaveListToFile())
            {
                return $"{boardgame.Title} added to the catalog";
            }

            return "An error occured when saving gthe file"; 

        }
        else
        {
            return $"{boardgame.Title} already in catalog";
        }

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
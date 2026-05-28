using BoardgameRecommender.Core;

public class JsonSeeder
{
    JsonLogger _logger;
    Random _random = new();
    private readonly string[] _adjectives =
    [
        "Cosmic", "Ancient", "Gloom", "Cyberpunk", "Medieval", 
        "Terraforming", "Shadow", "Galactic", "Forbidden", "Iron", 
        "Subterranean", "Imperial", "Mystic", "Radiant", "Eldritch", 
        "Neon", "Atomic", "Lost", "Runic", "Savage"
    ];
    private readonly string[] _nouns = 
    [
        "Mars", "Haven", "Island", "Empire", "Dungeon", 
        "Galaxy", "Cthulhu", "Kingdom", "Horizon", "Odyssey", 
        "Citadel", "Alliance", "Reckoning", "Dominion", "Wasteland", 
        "Chronicles", "Labyrinth", "Summit", "Outpost", "Eclipse"
    ];
    private readonly string[] _mechanics =
    [
        "The Card Game", "Legacy", "Imperial Edition", "The Dice Game", 
        "Chronicles", "Definitive Edition", "Showdown", "Rivals", 
        "The Board Game", "Deluxe", "Unbound", "Invasion"
    ];
    public JsonSeeder(JsonLogger logger)
    {
        _logger = logger;
    }

    public void SeedCatalog(int totalGamesToGenerate)
    {
        for (int i = 0; i < totalGamesToGenerate; i++)
        {
            string gameName = BuildGameName();
            string gameID = BuildGameID(gameName);
            int minPlayers = GenerateMinPlayers();
            int maxPlayers = GenerateMaxPlayers(minPlayers);
            GameDurationEnum duration = SelectGameDuration();

            Boardgame newGame = new(gameID, gameName, minPlayers, maxPlayers, duration);
            _logger.SaveGame(newGame);
        }

    }

    private string BuildGameName()
    {
        string adjective = _adjectives[_random.Next(_adjectives.Length)];
        string noun = _nouns[_random.Next(_nouns.Length)];
        string mechanic = _mechanics[_random.Next(_mechanics.Length)];

        return $"{adjective} {noun}: {mechanic}";
    }

    private string BuildGameID(string gameName)
    {
        string titleWithUnderscores = gameName.Replace(' ', '_');
        
        var cleanChars = titleWithUnderscores.Where(c => char.IsLetterOrDigit(c) || c =='_');
        string gameId = string.Concat(cleanChars).ToLowerInvariant();

        return gameId;
    }
    private int GenerateMinPlayers()
    {
        return _random.Next(1,8);
    }

    private int GenerateMaxPlayers(int minPlayers)
    {
        return minPlayers + _random.Next(1,4);
    }
    private GameDurationEnum SelectGameDuration()
    {
        GameDurationEnum[] durationValues = Enum.GetValues<GameDurationEnum>();

        return durationValues[_random.Next(durationValues.Length)]; 
    }


}
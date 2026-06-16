using BoardgameRecommender.Core;

public class BggCsvParser
{
    private readonly string _filePath;
    private List<Boardgame> _mastercatalog;
    public BggCsvParser()
    {
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "master_game_list.csv");

        _mastercatalog = ParseMasterCatalog();
    }
    public List<Boardgame> SearchGameList(string query)
    {
        if(string.IsNullOrWhiteSpace(query)) return new List<Boardgame>();

        return _mastercatalog
                .Where(game =>game.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Take(10)
                .ToList();
    }

    private List<Boardgame> ParseMasterCatalog()
    {
        var masterList = new List<Boardgame>();

        if(!File.Exists(_filePath)) return masterList;

        using var reader = new StreamReader(_filePath);

        reader.ReadLine();

        string? line;

        while((line = reader.ReadLine()) != null)
        {
            string[] fields = line.Split(',');

            string title = fields[2];
            int.TryParse(fields[4], out int minPlayers);
            int.TryParse(fields[5], out int maxPlayers);
            int.TryParse(fields[6], out int durationValue);

            GameDurationEnum duration = durationValue switch
            {
                  <= 60 => GameDurationEnum.Short,
                  <= 120 => GameDurationEnum.Medium,
                  <= 180 => GameDurationEnum.Long,
                  _ => GameDurationEnum.SuperLong
            };

            Boardgame game = new(title, minPlayers, maxPlayers, duration);

            masterList.Add(game);
        }

        return masterList;
    }
}
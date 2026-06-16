using BoardgameRecommender.Core;

namespace BoardgameRecommender.Core;
public class Boardgame
{
    public string ID {get; set;} = string.Empty;
    public string Title {get; set;}
    public int MinPlayerCount {get; set;}
    public int MaxPlayerCount {get; set;}
    public GameDurationEnum GameDuration {get; set;}
    // public List<Tag> TagList {get; set;}

    public Boardgame(string title, int minPlayerCount, int maxPlayerCount, GameDurationEnum gameDuration)
    {
        Title = title;
        MinPlayerCount = minPlayerCount;
        MaxPlayerCount = maxPlayerCount;
        GameDuration = gameDuration;

        // TagList = tagList != null ? new(tagList) : new();
    }

    public void BuildID()
    {
        string titleWithUnderscores = Title.Replace(' ', '_');
        
        var cleanChars = titleWithUnderscores.Where(c => char.IsLetterOrDigit(c) || c =='_');
        string gameId = string.Concat(cleanChars).ToLowerInvariant();

        ID = gameId;
    }


}
using BoardgameRecommender.Core;

namespace BoardgameRecommender.Core;
public class Boardgame
{
    public string ID {get; set;}
    public string Title {get; set;}
    public int MinPlayerCount {get; set;}
    public int MaxPlayerCount {get; set;}
    public List<Tag> TagList {get; set;}

    public Boardgame(string id, string title, int minPlayerCount, int maxPlayerCount, List<Tag> tagList)
    {
        ID = id;
        Title = title;
        MinPlayerCount = minPlayerCount;
        MaxPlayerCount = maxPlayerCount;

        TagList = tagList != null ? new(tagList) : new();
    }


}
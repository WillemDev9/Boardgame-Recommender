using BoardgameRecommender.Core;

public static class GameTags
{
    public static class Themes
    {
        public static readonly Tag SciFi = new("theme_scifi", "Sci-Fi", TagCategory.Theme);
        //Add more Themes here
    }
    public static class Mechanics
    {
        public static readonly Tag WorkerPlacement = new("mech-worker", "Worker Placement", TagCategory.Mechanic);
        //Add more mechanics here
    }
    public static class Component
    {
        public static readonly Tag Dice = new("comp-dice", "Dice Rolling", TagCategory.Component);
        //Add more components here
    }
}
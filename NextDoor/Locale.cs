namespace NextDoor
{
    public class Locale
    {
        public Locale(string file)
        {
            Data = Yaml.Deserialize(file);
            Authors = Data["Metadata"]["Authors"];
            Title = Data["Metadata"]["Title"];
        }

        public readonly string Authors;
        public readonly string Title;
        public readonly Dictionary<string, Dictionary<string, string>> Data;
    }
}
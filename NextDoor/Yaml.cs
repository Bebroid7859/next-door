namespace NextDoor
{
    public class Yaml
    {
        public static Dictionary<string, Dictionary<string, string>> Deserialize(string file)
        {
            var data = new Dictionary<string, Dictionary<string, string>>();

            foreach (var obj in File.ReadAllText(file).Split("\n"))
            {
                if (obj.Split(":")[1].Length < 1) data.Add(obj.Replace(":", ""), new Dictionary<string, string>());
                else data.ElementAt(data.Count() - 1).Value.Add(obj.Split(": ")[0].Replace(" ", "".Replace(" ", "")), obj.Split(": ")[1].Replace("\"", ""));
            }

            return data;
        }
    }
}
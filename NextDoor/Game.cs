namespace NextDoor
{
    public static class Game
    {
        public static Logger Logger = new(true);
        public static readonly Dictionary<string, Locale> Locales = new();

        static void Main()
        {
            try
            {
                Logger.Write(LogType.Info, "Initialization...");
                Initialize();
                Logger.Write(LogType.Info, "All done!");
            }
            catch (Exception exception)
            {
                Logger.Write(LogType.Crash, "Initialization failed! Look at the ./crash-log.txt");
                Logger.HandleCrash(exception);
                Environment.Exit(0);
            }
            Run();
        }

        static void Initialize()
        {
            LoadLocales();
        }

        static void Run()
        {
            try
            {
                Logger.Write(LogType.Info, "The game is running.");
                while (true)
                {
                    // здесь что-то играется...
                }
            }
            catch (Exception exception)
            {
                Logger.Write(LogType.Crash, "Something went wrong! Look at the ./crash-log.txt");
                Logger.HandleCrash(exception);
                Environment.Exit(0);
            }
        }

        static void LoadLocales()
        {
            var files = Directory
                .GetFiles("./Assets/Locales/", "*.*", SearchOption.AllDirectories)
                .Where((x) => x.EndsWith(".yaml"));

            foreach (var file in files)
            {
                Locales.Add(file.Replace(".yaml", ""), new Locale(file));
            }
        }
    }
}
namespace NextDoor
{
    public static class Game
    {
        public static Logger Logger = new(true);

        static void Main()
        {
            try
            {
                Logger.Write(LogType.Info, "Initialization...");
                Initialize();
                Logger.Write(LogType.Info, "All done!");
                Run();
            }
            catch (Exception exception)
            {
                Logger.Write(LogType.Crash, "Initialization failed! Look at the ./crash-log.txt");
                Logger.HandleCrash(exception);
            }
        }

        static void Initialize()
        {
            // здесь что-то загружается... 
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
            }
        }
    }
}
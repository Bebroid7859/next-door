namespace NextDoor
{
    public enum GameState { Running, Freezed, Stopping, Uninitialized }

    public static class Game
    {
        public static Logger Logger = new();
        public static GameState State = GameState.Uninitialized;

        static void Main()
        {
            try
            {
                Initialize();
                Logger.Write(LogType.Info, "Всё готово.");
                Run();
            }
            catch (Exception exception)
            {
                Logger.Write(LogType.Crash, "Программа вышла из строя, подробнее в crash-log.txt");
                HandleCrash(exception);
            }
        }

        static void Initialize()
        {

        }

        static void Run()
        {
            State = GameState.Running;
            while (State != GameState.Stopping)
            {
                Graphics.Renderer.Update();
            }
        }

        static void HandleCrash(Exception exception)
        {
            State = GameState.Stopping;
            File.WriteAllText("./crash-log.txt", exception.ToString());
            Environment.Exit(69);
        }
    }
}
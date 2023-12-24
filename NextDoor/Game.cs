using NextDoor.Input;
using NextDoor.Widgets;
using NextDoor.Graphics;
using NetCoreAudio;

namespace NextDoor
{
    public enum GameState { Running, Freezed, Stopping, Uninitialized }

    public static class Game
    {
        public static Logger Logger = new();
        public static GameState State = GameState.Uninitialized;
        public static Overlay Overlay = new Overlay();
        public static IInputHandler InputHandler = new DefaultInputHandler();

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
            Renderer.Initialize();
            Overlay = new MenuOverlay();
            Overlay.Load();
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
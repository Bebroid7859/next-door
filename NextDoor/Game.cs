namespace NextDoor
{
    public static class Game
    {
        public static Logger Logger = new();

        public static void Main()
        {
            Logger.Write(LogType.Info, "Запустилось!");
        }
    }
}
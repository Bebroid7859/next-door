namespace NextDoor
{
    public static class Game
    {
        public static Logger Logger = new(true);

        static void Main()
        {
            try
            {
                Logger.Write(LogType.Info, "Инициализация...");
                Initialize();
                Logger.Write(LogType.Info, "Всё в порядке, запуск игры.");
                Run();
            }
            catch (Exception exception)
            {
                Logger.Write(LogType.Crash, "Не всё в порядке. Записываю подробнее в файл ./crash-log.txt");
                File.WriteAllText("./crash-log.txt", exception.ToString());
            }
        }

        static void Initialize()
        {
            // здесь что-то загружается...
        }

        static void Run()
        {
            Logger.Write(LogType.Info, "Запустилось!");

            while (true)
            {

            }
        }
    }
}
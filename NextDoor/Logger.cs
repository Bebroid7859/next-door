namespace NextDoor
{
    public enum LogType : byte { Info = 0, Warn = 1, Error = 2, Crash = 3, Debug = 4 }

    public class Logger
    {
        public Logger(bool format = true)
        {
            Format = format;

            Colors.Add(0, ConsoleColor.Gray);
            Colors.Add(1, ConsoleColor.Yellow);
            Colors.Add(2, ConsoleColor.Red);
            Colors.Add(3, ConsoleColor.DarkRed);
            Colors.Add(4, ConsoleColor.Blue);
        }

        readonly Dictionary<byte, ConsoleColor> Colors = new();
        readonly bool Format;

        public void Write(LogType type, string text)
        {
            Console.ForegroundColor = Colors[(byte)type];

            string prefix = (Format) ? $"[{DateTime.Now.ToString("HH:mm:ss")}] " : "";
            Console.WriteLine($"{prefix}{text}");
        }

        public void HandleCrash(Exception exception)
        {
            File.WriteAllText("./crash-log.txt", $"Блин, похоже что-то пошло не так...\n\n{exception.ToString()}");
        }
    }
}
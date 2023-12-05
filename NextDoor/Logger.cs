namespace NextDoor
{
    public enum LogType : byte { Info = 0, Warn = 1, Error = 2, Crash = 3, Debug = 4 }

    public class Logger
    {
        public Logger()
        {
            Colors.Add(0, ConsoleColor.Gray);
            Colors.Add(1, ConsoleColor.Yellow);
            Colors.Add(2, ConsoleColor.Red);
            Colors.Add(3, ConsoleColor.DarkRed);
            Colors.Add(4, ConsoleColor.Blue);
        }

        public Dictionary<byte, ConsoleColor> Colors = new();

        public void Write(LogType type, string text)
        {
            Console.ForegroundColor = Colors[(byte)type];
            Console.WriteLine(text);
        }
    }
}
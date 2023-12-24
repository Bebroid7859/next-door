namespace NextDoor.Input
{
    public class Modifiers
    {
        public static bool Check(string key)
        {
            if (key == "LShift")
                return true;
            return false;
        }

        public string Key;

        public Modifiers(string key)
        {
            Key = key;
        }
    }
}
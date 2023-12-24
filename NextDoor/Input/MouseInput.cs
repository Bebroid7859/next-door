namespace NextDoor.Input
{
    public class MouseInput
    {
        public Vector2 Position { get; }
        public MouseButton Button { get; }

        public MouseInput(Vector2 position, string button)
        {
            Position = position;

            switch (button)
            {
                case "Left":
                    Button = MouseButton.LEFT;
                    break;
                case "Right":
                    Button = MouseButton.RIGHT;
                    break;
                case "Middle":
                    Button = MouseButton.MIDDLE;
                    break;
            }
        }
    }

    public enum MouseButton : int
    {
        LEFT = 0,
        RIGHT = 1,
        MIDDLE = 2
    }
}
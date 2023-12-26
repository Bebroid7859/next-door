using NextDoor.Input;
using SFML.Graphics;
using SFML.System;

namespace NextDoor.Widgets
{
    public class MainMenuWidget : Widget
    {
        public float Selected = 1;
        public MainMenuWidget(WidgetInfo info)
        {
            Id = info.Id;
            OverrideHover = info.OverrideHover;

            Add(info.IsChild);
        }

        public override void HandleKeyInput(KeyInput args)
        {
            // почему-то нажатие клавиш передаётся два раза, я не понял почему, да и пусть, это не на качество

            if (args.Unicode == "W") Selected -= 0.5f;
            if (args.Unicode == "S") Selected += 0.5f;
            if (Selected == 0) Selected = 4;
            if (Selected == 5) Selected = 1;

            Console.WriteLine(args.Unicode);
            if (Selected == 4 && args.Unicode == "Return")
            {
                Audio.music.Stop();
                Environment.Exit(69);
            }
        }
    }
}
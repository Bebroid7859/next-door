using SFML.Graphics;
using SFML.System;
using SFML.Window;
using NextDoor.Widgets;

namespace NextDoor.Graphics
{
    public interface BackgroundGraphics
    {
        public void Update();
    }

    public static class Renderer
    {
        public static RenderWindow Window = new(new VideoMode(1200, 800), "Next Door", Styles.Titlebar);
        public static BackgroundGraphics BackgroundGraphics = new MenuGraphics();

        public static void Update()
        {
            BackgroundGraphics.Update();
            foreach (var widget in Widget.Widgets.Values)
            {
                if (widget.Shape is RectangleShape) Window.Draw((RectangleShape)widget.Shape);
                else Window.Draw((Text)widget.Shape);
            }
            Window.Display();
        }
    }
}
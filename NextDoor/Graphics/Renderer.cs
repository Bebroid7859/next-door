using SFML.Graphics;
using SFML.System;
using SFML.Window;

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
            Window.Display();
        }
    }
}
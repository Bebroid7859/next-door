using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace NextDoor.Graphics
{
    class LevelGraphics : BackgroundGraphics
    {
        static AnimatedRGB Background = new();
        List<RectangleShape> colors = new();

        public static List<AnimatedVan> Vans = new();
        public static List<AnimatedVan> UnusedVans = new();

        public LevelGraphics()
        {
            Renderer.Window.SetFramerateLimit(60);
            for (int i = 0; i < Renderer.Window.Size.Y; i++)
            {
                int opacity = i;
                if (opacity > 15) opacity = 15;
                colors.Add(new RectangleShape(new Vector2f(Renderer.Window.Size.X, 1)) { Position = new Vector2f(0, i * 2), FillColor = new Color(0, 0, 0, Background.R) });
            }
        }

        public void Underlay()
        {
            Background.Update();
            Renderer.Window.DispatchEvents();
            Renderer.Window.Clear(new Color(Background.DarkG, Background.DarkG, Background.DarkG, 0));
        }

        public void Overlap()
        {
            foreach (var color in colors) { Renderer.Window.Draw(color); }
        }
    }
}
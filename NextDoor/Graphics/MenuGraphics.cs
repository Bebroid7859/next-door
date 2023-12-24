using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace NextDoor.Graphics
{
    class MenuGraphics : BackgroundGraphics
    {
        static AnimatedRGB Background = new();

        List<RectangleShape> colors1 = new();
        List<RectangleShape> colors2 = new();

        public static List<AnimatedVan> Vans = new();
        public static List<AnimatedVan> UnusedVans = new();

        public MenuGraphics()
        {
            Renderer.Window.SetFramerateLimit(30);
            for (int i = 0; i < Renderer.Window.Size.Y; i++)
            {
                int opacity = i;
                if (opacity > 205) opacity = 205;
                colors1.Add(new RectangleShape(new Vector2f(Renderer.Window.Size.X, 1 * (Renderer.Window.Size.Y / 255))) { Position = new Vector2f(0, i * (Renderer.Window.Size.Y / 255)), FillColor = new Color(0, 0, 0, Convert.ToByte(opacity)) });
            }
            for (int i = 0; i < Renderer.Window.Size.Y; i++)
            {
                int opacity = i;
                if (opacity > 15) opacity = 15;
                colors2.Add(new RectangleShape(new Vector2f(Renderer.Window.Size.X, 1)) { Position = new Vector2f(0, i * 2), FillColor = new Color(0, 0, 0, 200) });
            }

            Vans.Add(new AnimatedVanLeft());
            Vans.Add(new AnimatedVanRight());
        }

        public void Underlay()
        {
            Background.Update();
            Renderer.Window.DispatchEvents();
            Renderer.Window.Clear(new Color(Background.R, Background.G, Background.B, 100));

            for (int i = 0; i < UnusedVans.Count(); i++)
            {
                UnusedVans[i] = null!;
                GC.Collect();
            }

            UnusedVans.Clear();

            foreach (var color in colors1) { Renderer.Window.Draw(color); }

            foreach (var van in new List<AnimatedVan>(Vans))
            {
                van.Update();
                van.Van.Color = new Color(Background.B, Background.G, Background.R);
                van.Color();
                Renderer.Window.Draw(van.Van);
            }
        }

        public void Overlap()
        {
            foreach (var color in colors2) { Renderer.Window.Draw(color); }
        }
    }
}
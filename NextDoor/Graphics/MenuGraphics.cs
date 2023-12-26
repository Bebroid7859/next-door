using SFML.Graphics;
using SFML.System;
using SFML.Window;
using NextDoor.Widgets;

namespace NextDoor.Graphics
{
    class MenuGraphics : BackgroundGraphics
    {
        static AnimatedRGB Background = new();
        static AnimatedRotation Rotation = new();
        static AnimatedRotation3 RotationSex = new();
        static AnimatedRotation2 ClonesTimer = new();

        List<RectangleShape> colors1 = new();
        List<RectangleShape> colors2 = new();

        public static List<AnimatedVan> Vans = new();
        public static List<AnimatedVan> UnusedVans = new();

        public static List<RectangleShape> Clones = new();

        public static RectangleShape NextDoor = new(((Vector2f)new Texture("./Assets/Chrome/Menu/NextDoor.png").Size * 1.25f)) { Position = new Vector2f(Renderer.Window.Size.X / 2f - 16, 180), Texture = new Texture("./Assets/Chrome/Menu/NextDoor.png"), FillColor = new Color(0, 255, 255, 255), Origin = new Vector2f(new Texture("./Assets/Chrome/Menu/NextDoor.png").Size.X * 1.25f / 2, 0) };
        public static RectangleShape StartGame = new(((Vector2f)new Texture("./Assets/Chrome/Menu/StartGame.png").Size * 1.5f)) { Position = new Vector2f(Renderer.Window.Size.X / 2f, 370), Texture = new Texture("./Assets/Chrome/Menu/StartGame.png"), FillColor = new Color(0, 255, 255, 255), Origin = new Vector2f(new Texture("./Assets/Chrome/Menu/StartGame.png").Size.X * 1.5f / 2, 0) };
        public static RectangleShape Continue = new(((Vector2f)new Texture("./Assets/Chrome/Menu/Continue.png").Size * 1.5f)) { Position = new Vector2f(Renderer.Window.Size.X / 2f, 440), Texture = new Texture("./Assets/Chrome/Menu/Continue.png"), FillColor = new Color(0, 255, 255, 255), Origin = new Vector2f(new Texture("./Assets/Chrome/Menu/Continue.png").Size.X * 1.5f / 2, 0) };
        public static RectangleShape Options = new(((Vector2f)new Texture("./Assets/Chrome/Menu/Options.png").Size * 1.5f)) { Position = new Vector2f(Renderer.Window.Size.X / 2f, 510), Texture = new Texture("./Assets/Chrome/Menu/Options.png"), FillColor = new Color(0, 255, 255, 255), Origin = new Vector2f(new Texture("./Assets/Chrome/Menu/Options.png").Size.X * 1.5f / 2, 0) };
        public static RectangleShape ExitGame = new(((Vector2f)new Texture("./Assets/Chrome/Menu/ExitGame.png").Size * 1.5f)) { Position = new Vector2f(Renderer.Window.Size.X / 2f, 580), Texture = new Texture("./Assets/Chrome/Menu/ExitGame.png"), FillColor = new Color(0, 255, 255, 255), Origin = new Vector2f(new Texture("./Assets/Chrome/Menu/ExitGame.png").Size.X * 1.5f / 2, 0) };

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
            Rotation.Update();
            ClonesTimer.Update();
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

            // мне лень делать нормально, я потом сделаю

            StartGame.Rotation = Rotation.Rotation;
            Continue.Rotation = Rotation.Rotation;
            Options.Rotation = Rotation.Rotation;
            ExitGame.Rotation = Rotation.Rotation;

            NextDoor.Rotation = Rotation.Rotation / 2 * -1.5f;

            if (((MainMenuWidget)Widget.Widgets["MainMenuController"]).Selected == 1)
            {
                Renderer.Window.Draw(StartGame);
                StartGame.FillColor = new Color(255, 0, 255);
                Clones.Clear();
                for (int i = 1; i < ClonesTimer.Rotation; i++)
                {
                    Clones.Add(new RectangleShape(StartGame.Size)
                    {
                        Rotation = StartGame.Rotation,
                        FillColor = new Color(255, 255, 255),
                        Position = new Vector2f(StartGame.Position.X + i, StartGame.Position.Y),
                        Texture = StartGame.Texture,
                        Origin = StartGame.Origin
                    });

                    Clones.Add(new RectangleShape(StartGame.Size)
                    {
                        Rotation = StartGame.Rotation,
                        FillColor = new Color(Convert.ToByte(StartGame.FillColor.R), Convert.ToByte(StartGame.FillColor.G), Convert.ToByte(StartGame.FillColor.B), Convert.ToByte(255 - i * 8)),
                        Position = new Vector2f(StartGame.Position.X + i, StartGame.Position.Y),
                        Texture = StartGame.Texture,
                        Origin = StartGame.Origin
                    });
                }
                foreach (var clone in Clones) { Renderer.Window.Draw(clone); }
            }
            else
            {
                Renderer.Window.Draw(StartGame);
                StartGame.FillColor = new Color(0, 255, 255);
            }

            if (((MainMenuWidget)Widget.Widgets["MainMenuController"]).Selected == 2)
            {
                Renderer.Window.Draw(Continue);
                Continue.FillColor = new Color(255, 0, 255);
                Clones.Clear();
                for (int i = 1; i < ClonesTimer.Rotation; i++)
                {
                    Clones.Add(new RectangleShape(Continue.Size)
                    {
                        Rotation = Continue.Rotation,
                        FillColor = new Color(255, 255, 255),
                        Position = new Vector2f(Continue.Position.X + i, Continue.Position.Y),
                        Texture = Continue.Texture,
                        Origin = Continue.Origin
                    });

                    Clones.Add(new RectangleShape(Continue.Size)
                    {
                        Rotation = Continue.Rotation,
                        FillColor = new Color(Convert.ToByte(Continue.FillColor.R), Convert.ToByte(Continue.FillColor.G), Convert.ToByte(Continue.FillColor.B), Convert.ToByte(255 - i * 8)),
                        Position = new Vector2f(Continue.Position.X + i, Continue.Position.Y),
                        Texture = Continue.Texture,
                        Origin = Continue.Origin
                    });
                }
                foreach (var clone in Clones) { Renderer.Window.Draw(clone); }
            }
            else
            {
                Renderer.Window.Draw(Continue);
                Continue.FillColor = new Color(0, 255, 255);
            }

            if (((MainMenuWidget)Widget.Widgets["MainMenuController"]).Selected == 3)
            {
                Renderer.Window.Draw(Options);
                Options.FillColor = new Color(255, 0, 255);
                Clones.Clear();
                for (int i = 1; i < ClonesTimer.Rotation; i++)
                {
                    Clones.Add(new RectangleShape(Options.Size)
                    {
                        Rotation = Options.Rotation,
                        FillColor = new Color(255, 255, 255),
                        Position = new Vector2f(Options.Position.X + i, Options.Position.Y),
                        Texture = Options.Texture,
                        Origin = Options.Origin
                    });

                    Clones.Add(new RectangleShape(Options.Size)
                    {
                        Rotation = Options.Rotation,
                        FillColor = new Color(Convert.ToByte(Options.FillColor.R), Convert.ToByte(Options.FillColor.G), Convert.ToByte(Options.FillColor.B), Convert.ToByte(255 - i * 8)),
                        Position = new Vector2f(Options.Position.X + i, Options.Position.Y),
                        Texture = Options.Texture,
                        Origin = Options.Origin
                    });
                }
                foreach (var clone in Clones) { Renderer.Window.Draw(clone); }
            }
            else
            {
                Renderer.Window.Draw(Options);
                Options.FillColor = new Color(0, 255, 255);
            }

            if (((MainMenuWidget)Widget.Widgets["MainMenuController"]).Selected == 4)
            {
                Renderer.Window.Draw(ExitGame);
                ExitGame.FillColor = new Color(255, 0, 255);
                Clones.Clear();
                for (int i = 1; i < ClonesTimer.Rotation; i++)
                {
                    Clones.Add(new RectangleShape(ExitGame.Size)
                    {
                        Rotation = ExitGame.Rotation,
                        FillColor = new Color(255, 255, 255),
                        Position = new Vector2f(ExitGame.Position.X + i, ExitGame.Position.Y),
                        Texture = ExitGame.Texture,
                        Origin = ExitGame.Origin
                    });

                    Clones.Add(new RectangleShape(ExitGame.Size)
                    {
                        Rotation = ExitGame.Rotation,
                        FillColor = new Color(Convert.ToByte(ExitGame.FillColor.R), Convert.ToByte(ExitGame.FillColor.G), Convert.ToByte(ExitGame.FillColor.B), Convert.ToByte(255 - i * 8)),
                        Position = new Vector2f(ExitGame.Position.X + i, ExitGame.Position.Y),
                        Texture = ExitGame.Texture,
                        Origin = ExitGame.Origin
                    });
                }
                foreach (var clone in Clones) { Renderer.Window.Draw(clone); }
            }
            else
            {
                Renderer.Window.Draw(ExitGame);
                ExitGame.FillColor = new Color(0, 255, 255);
            }

            RotationSex.Update();

            if (((MainMenuWidget)Widget.Widgets["MainMenuController"]).Selected != 5)
            {
                Renderer.Window.Draw(NextDoor);
                NextDoor.FillColor = new Color(Background.R, Background.G, Background.B);
                Clones.Clear();

                var rnd = new Random();
                for (int i = 1; i < 15; i++)
                {
                    Clones.Add(new RectangleShape(NextDoor.Size)
                    {
                        Rotation = NextDoor.Rotation,
                        FillColor = new Color(255, 255, 255),
                        Position = new Vector2f(NextDoor.Position.X + i * RotationSex.sexx, NextDoor.Position.Y + i * RotationSex.sexx2),
                        Texture = NextDoor.Texture,
                        Origin = NextDoor.Origin
                    });

                    Clones.Add(new RectangleShape(NextDoor.Size)
                    {
                        Rotation = NextDoor.Rotation,
                        FillColor = new Color(Convert.ToByte(NextDoor.FillColor.R), Convert.ToByte(NextDoor.FillColor.G), Convert.ToByte(NextDoor.FillColor.B), Convert.ToByte(255 - i * 8)),
                        Position = new Vector2f(NextDoor.Position.X + i * RotationSex.sexx, NextDoor.Position.Y + i * RotationSex.sexx2),
                        Texture = NextDoor.Texture,
                        Origin = NextDoor.Origin
                    });
                }
                foreach (var clone in Clones) { Renderer.Window.Draw(clone); }
            }
        }

        public void Overlap()
        {
            foreach (var color in colors2) { Renderer.Window.Draw(color); }
        }
    }
}
using SFML.Graphics;
using SFML.System;

namespace NextDoor.Graphics
{
    public interface AnimatedVan
    {
        public Sprite Van { get; set; }
        public void Update() { }
        public void Color() { }
    }

    public sealed class AnimatedVanRight : AnimatedVan
    {
        public Sprite Van { get; set; } = new Sprite(new Texture("./Assets/Chrome/Menu/VanRight.png"));
        bool SpawnedVan;

        public AnimatedVanRight()
        {
            Van.Scale = new Vector2f(0.05f, 0.05f);
            Van.Position = new Vector2f(Renderer.Window.Size.X / 2 + Van.Texture.Size.X * 0.05f + 75, 225);
            Van.Origin = new Vector2f(Van.Texture.Size.X, 0);
        }

        public void Update()
        {
            Van.Position = new Vector2f(Van.Position.X + 1.75f + Van.Scale.X * 5, Van.Position.Y + 0.10f + Van.Scale.Y * 2);
            Van.Scale = new Vector2f(Van.Scale.X + 0.0025f, Van.Scale.Y + 0.0025f);
            Van.Rotation += 0.05f;
            if (Van.Position.Y > Renderer.Window.Size.Y / 3.3f && !SpawnedVan)
            {
                SpawnedVan = true;
                MenuGraphics.Vans.Add(new AnimatedVanRight());
            }
            if (Van.Position.X > Renderer.Window.Size.X + 300)
            {
                MenuGraphics.Vans.Remove(this);
                MenuGraphics.UnusedVans.Add(this);
            }
        }

        public void Color()
        {
            if (Van.Color.R * 2 > 255) Van.Color = new Color(255, Van.Color.G, Van.Color.B);
            else Van.Color = new Color(Convert.ToByte(Van.Color.R * 2), Van.Color.G, Van.Color.B);
            if (Van.Color.G * 2 > 255) Van.Color = new Color(Van.Color.R, 255, Van.Color.B);
            else Van.Color = new Color(Van.Color.R, Convert.ToByte(Van.Color.G * 2), Van.Color.B);
            if (Van.Color.B * 2 > 255) Van.Color = new Color(Van.Color.R, Van.Color.G, 255);
            else Van.Color = new Color(Van.Color.R, Van.Color.G, Convert.ToByte(Van.Color.B * 2));
        }
    }

    public sealed class AnimatedVanLeft : AnimatedVan
    {
        public Sprite Van { get; set; } = new Sprite(new Texture("./Assets/Chrome/Menu/VanLeft.png"));
        bool SpawnedVan;

        public AnimatedVanLeft()
        {
            Van.Scale = new Vector2f(0.05f, 0.05f);
            Van.Position = new Vector2f(Renderer.Window.Size.X / 2 - Van.Texture.Size.X * 0.05f - 75, 225);
        }

        public void Update()
        {
            Van.Position = new Vector2f(Van.Position.X - 1.75f - Van.Scale.X * 5, Van.Position.Y + 0.10f + Van.Scale.Y * 2);
            Van.Scale = new Vector2f(Van.Scale.X + 0.0025f, Van.Scale.Y + 0.0025f);
            Van.Rotation -= 0.05f;
            if (Van.Position.Y > Renderer.Window.Size.Y / 3.3f && !SpawnedVan)
            {
                SpawnedVan = true;
                MenuGraphics.Vans.Add(new AnimatedVanLeft());
            }
            if (Van.Position.X < -300)
            {
                MenuGraphics.Vans.Remove(this);
                MenuGraphics.UnusedVans.Add(this);
            }
        }

        public void Color()
        {
            if (Van.Color.R * 2 > 255) Van.Color = new Color(255, Van.Color.G, Van.Color.B);
            else Van.Color = new Color(Convert.ToByte(Van.Color.R * 2), Van.Color.G, Van.Color.B);
            if (Van.Color.G * 2 > 255) Van.Color = new Color(Van.Color.R, 255, Van.Color.B);
            else Van.Color = new Color(Van.Color.R, Convert.ToByte(Van.Color.G * 2), Van.Color.B);
            if (Van.Color.B * 2 > 255) Van.Color = new Color(Van.Color.R, Van.Color.G, 255);
            else Van.Color = new Color(Van.Color.R, Van.Color.G, Convert.ToByte(Van.Color.B * 2));
        }
    }
}
using SFML.Graphics;
using SFML.System;

namespace NextDoor.Graphics
{
    public class Sheet
    {
        public Texture Texture { get; private set; }
        public Vector2 Size { get; private set; }
        public Vector2 SpriteSize { get; private set; }
        public int SpritesCount { get; private set; }

        public Sheet(Texture texture, int spritesCount) { Texture = texture; Size = new Vector2(Convert.ToInt32(texture.Size.X), Convert.ToInt32(texture.Size.Y)); SpriteSize = new Vector2(Size.X / spritesCount, Size.Y); SpritesCount = spritesCount; }

        public static Sheet Create(string path)
        {
            return new Sheet(new Texture($"{path}.png"), Convert.ToInt32(File.ReadAllText($"{path}.yaml").Split(": ")[1]));
        }

        public RectangleShape GetShape(byte sprite, float size = 1)
        {
            return new RectangleShape(new Vector2f(SpriteSize.X * size, SpriteSize.Y * size))
            {
                Texture = this.Texture,
                TextureRect = new IntRect(Convert.ToInt32(SpriteSize.X * (sprite - 1)), 0, SpriteSize.X, SpriteSize.Y)
            };
        }

        public IntRect GetRect(byte sprite, float size = 1)
        {
            return new IntRect(Convert.ToInt32(SpriteSize.X * (sprite - 1)), 0, SpriteSize.X, SpriteSize.Y);
        }
    }
}
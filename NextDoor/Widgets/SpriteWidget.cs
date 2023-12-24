using SFML.Graphics;
using SFML.System;

namespace NextDoor.Widgets
{
    public class SpriteWidget : Widget
    {
        public SpriteWidget(Dictionary<string, string> yaml) : this(new WidgetInfo(yaml["Id"], yaml["OverrideHover"], yaml["IsChild"]), new RectangleShape(new Vector2f(new Texture(yaml["TexturePath"]).Size.X, new Texture(yaml["TexturePath"]).Size.Y)) { Texture = new Texture(yaml["TexturePath"]), Position = new Vector2f(Convert.ToInt32(yaml["X"]), Convert.ToInt32(yaml["Y"]))}) {}
        public SpriteWidget(WidgetInfo info, RectangleShape texture)
        {
            Id = info.Id;
            OverrideHover = info.OverrideHover;
            Shape = texture;
            
            Add(info.IsChild);
        }
    }
}
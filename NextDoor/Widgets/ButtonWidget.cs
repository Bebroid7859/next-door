using SFML.Graphics;
using SFML.System;
using NextDoor.Graphics;

namespace NextDoor.Widgets
{
    public enum ButtonState : byte { Unselected = 1, Selected = 2, Pressed = 3 }
    public class ButtonWidget : Widget
    {
        public ButtonState State
        {
            set
            {
                var shape = (RectangleShape)Shape;
                shape.Texture = Sheet.GetShape((byte)value).Texture;
                Shape = shape;
            }
        }
        public Sheet Sheet { get; }

        public ButtonWidget(Dictionary<string, string> yaml) : this(new WidgetInfo(yaml["Id"], yaml["OverrideHover"], yaml["IsChild"]), new Sheet(new Texture(yaml["Sheet"]), 3), yaml) { }
        public ButtonWidget(WidgetInfo info, Sheet sheet, Dictionary<string, string> yaml)
        {
            Id = info.Id;
            OverrideHover = info.OverrideHover;
            Sheet = new Sheet(new Texture(yaml["Sheet"]), 3);

            Shape = new RectangleShape(new Vector2f(Sheet.GetShape(1, 1).Texture.Size.X, Sheet.GetShape(1, 1).Texture.Size.Y))
            {
                Texture = Sheet.GetShape(1).Texture,
                Position = new Vector2f(Convert.ToInt32(yaml["X"]), Convert.ToInt32(yaml["Y"]))
            };

            Add(info.IsChild);
        }
    }
}
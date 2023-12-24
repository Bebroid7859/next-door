using SFML.Graphics;
using SFML.System;
using SFML.Window;
using NextDoor.Graphics;
using NextDoor.Input;

namespace NextDoor.Widgets
{
    public enum ButtonState : byte { Unselected = 1, Selected = 2, Pressed = 3 }
    public class ButtonWidget : Widget
    {
        public ButtonState State
        {
            set
            {
                ((RectangleShape)Shape).Texture = Sheet.Texture;
                ((RectangleShape)Shape).TextureRect = Sheet.GetRect(1);
            }
        }
        public Sheet Sheet { get; }
        public ButtonWidget(WidgetInfo info, Sheet sheet, Vector2 xy)
        {
            Id = info.Id;
            OverrideHover = info.OverrideHover;
            Sheet = sheet;

            Shape = new RectangleShape(new Vector2f(Sheet.GetShape(1, 1).Size.X, Sheet.GetShape(1, 1).Size.Y))
            {
                Texture = Sheet.GetShape(1).Texture,
                TextureRect = Sheet.GetShape(1).TextureRect,
                Position = xy.ToVector2f()
            };

            Add(info.IsChild);
        }

        public override void HandleKeyInput(KeyInput args)
        {
            
        }
    }
}
using SFML.Graphics;
using SFML.System;

namespace NextDoor.Widgets
{
    public class SpriteWidget : Widget
    {
        public SpriteWidget(WidgetInfo info, RectangleShape texture)
        {
            Id = info.Id;
            OverrideHover = info.OverrideHover;
            Shape = texture;
            
            Add(info.IsChild);
        }
    }
}
using NextDoor.Graphics;
using SFML.Graphics;

namespace NextDoor.Widgets
{
    // я очень хотел сделать это в yaml, но потерпел большие неудачи в виде IL2057: Unrecognized value passed to the parameter 'typeName' of method 'System.Type.GetType(String, Boolean)'

    public class Overlay
    {
        public virtual void Load()
        {
            foreach (var widget in new Dictionary<string, Widget>(Widget.Widgets))
            {
                Widget.Widgets[widget.Key] = null!;
                GC.Collect();
            }
            Widget.Widgets.Clear();
        }
    }

    public class MenuOverlay : Overlay
    {
        public override void Load()
        {
            base.Load();
            new ButtonWidget(new WidgetInfo("Test", "false", "false"), new Sheet(new Texture("./Assets/test.png"), 3), new Vector2(50, 50));
        }
    }
}
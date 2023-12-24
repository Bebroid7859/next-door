using SFML.Graphics;

namespace NextDoor.Widgets
{
    public class LabelWidget : Widget
    {
        public LabelWidget() : base() { }
        public LabelWidget(Dictionary<string, string> yaml) : this(new WidgetInfo(yaml["Id"], yaml["OverrideHover"], yaml["IsChild"]), yaml["Text"], yaml["FontPath"], Convert.ToUInt32(yaml["FontSize"]), new Color(Convert.ToByte(yaml["Color"].Split(",")[0].Replace(" ", "")), Convert.ToByte(yaml["Color"].Split(",")[1].Replace(" ", "")), Convert.ToByte(yaml["Color"].Split(",")[2].Replace(" ", ""))), new Vector2(yaml["X"], yaml["Y"])) { }
        public LabelWidget(WidgetInfo info, string text, string fontPath, uint fontSize, Color color, Vector2 position, bool visible = true) : base()
        {
            Id = info.Id;
            OverrideHover = info.OverrideHover;

            var shape = new Text(text, new Font(fontPath), fontSize);
            shape.FillColor = color;
            shape.Position = position.ToVector2f();
            Rect = new WidgetRect(new Vector2(Convert.ToInt32(fontSize) * (text.Count() - 1) / 2, Convert.ToInt32(fontSize)), position);
            Shape = shape;

            Visible = visible;

            Add(info.IsChild);
        }
    }
}
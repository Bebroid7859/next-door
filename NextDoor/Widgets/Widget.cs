using SFML.Graphics;
using NextDoor.Input;

namespace NextDoor.Widgets
{
    public class Widget
    {
        public List<Widget> ChildWidgets { get; protected set; } = new List<Widget>();
        public string? ParentWidgetId { get; protected set; }

        public string Id { get; protected set; }
        public bool Visible { get; internal set; }
        public bool OverrideHover { get; internal set; }
        public bool IsDestroyed { get; protected set; }
        public bool HasParent { get; protected set; }
        public bool HasChildren { get; protected set; }

        public Widget(string id, Vector2 rect, Vector2 position, bool overrideHover) { OverrideHover = overrideHover; Id = id; Rect = new WidgetRect(rect.X, rect.Y, position.X, position.Y); Shape = new RectangleShape(rect.ToVector2f()) { Position = position.ToVector2f() }; }
        public Widget(string id, Vector2 rect, Vector2 position, string parentWidgetId, bool overrideHover) : this(id, rect, position, overrideHover) { ParentWidgetId = parentWidgetId; HasParent = true; }

        public Widget() : this("", new Vector2("0,0"), new Vector2("0,0"), false) { }

        public static Dictionary<string, Widget> Widgets = new Dictionary<string, Widget>();
        public static Widget? SelectedWidget { get; protected set; }
        public static Widget? HoveredWidget { get; protected set; }

        public WidgetRect Rect { get; protected set; }
        public object Shape { get; protected set; }

        public void Destroy(bool destroyChildWidgets = true)
        {
            if (destroyChildWidgets)
                DestroyAllChildWidgets();
            else if (HasChildren)
                throw new Exception("A parent widget with child widgets cannot be destroyed without destroying the child widgets.");
            IsDestroyed = true;
            Widgets.Remove(Id);
        }

        public void Add(bool isChild)
        {
            if (!isChild) Widgets.Add(Id, this);
        }

        public void DestroyAllChildWidgets()
        {
            foreach (var widget in ChildWidgets) { widget.Destroy(); }
        }

        public virtual void HandleMouseClickInput(MouseInput args) { }
        public virtual void HandleMouseMovedInput(Vector2 args) { }
        public virtual void HandleKeyInput(KeyInput args) { }

        public void AddChildWidget(Widget widget)
        {
            ChildWidgets.Add(widget);
            HasChildren = true;
            widget.HasParent = true;
            widget.ParentWidgetId = Id;
            Widgets.Add(widget.Id, widget);
        }
    }

    public class WidgetRect
    {
        public int[,] Pixels { get; private set; }

        public WidgetRect(int width, int height, int x, int y)
        {
            Pixels = new int[width + x, height + y];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    Pixels[i + x, j + y] = 1;
        }
        public WidgetRect(Vector2 size, Vector2 position) : this(size.X, size.Y, position.X, position.Y) { }

        public static bool operator ==(WidgetRect me, WidgetRect other) { return (me == other); }
        public static bool operator !=(WidgetRect me, WidgetRect other) { return !(me == other); }

        public static bool operator ==(WidgetRect me, Vector2 other)
        {
            try { if (me.Pixels[other.X, other.Y] == 1) return true; } catch { return false; }
            return false;
        }
        public static bool operator !=(WidgetRect me, Vector2 other)
        {
            try { if (me.Pixels[other.X, other.Y] != 1) return true; } catch { return false; }
            return false;
        }

        public override int GetHashCode() { return Pixels.GetHashCode(); }
        public bool Equals(WidgetRect other) { return this == other; }
        public override bool Equals(object? obj) { return obj is WidgetRect vec && Equals(vec); }
    }

    public struct WidgetInfo
    {
        public readonly bool OverrideHover;
        public readonly bool IsChild;
        public readonly string Id;

        public WidgetInfo(string id, string overrideHover, string isChild)
        {
            Id = id;
            OverrideHover = Convert.ToBoolean(overrideHover);
            IsChild = Convert.ToBoolean(isChild);
        }
    }
}
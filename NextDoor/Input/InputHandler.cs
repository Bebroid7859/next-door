using NextDoor.Widgets;

namespace NextDoor.Input
{
    public interface IInputHandler
    {
        public void ModifierKeys(Modifiers modifiers) { }
        public void OnKeyInput(KeyInput input) { }
        public void OnMouseClickInput(MouseInput input) { }
        public void OnMouseMovedInput(Vector2 input) { }
    }

    public class NullInputHandler : IInputHandler
    {
        public void ModifierKeys(Modifiers modifiers) { }
        public void OnKeyInput(KeyInput input) { }
        public void OnMouseClickInput(MouseInput input) { }
        public void OnMouseMovedInput(Vector2 input) { }
    }

    public class DefaultInputHandler : IInputHandler
    {
        public void ModifierKeys(Modifiers modifiers) { } // у меня пока нет идей
        public void OnKeyInput(KeyInput input) { foreach (var widget in Widget.Widgets) { if (widget.Value.Visible) widget.Value.HandleKeyInput(input); } }
        public void OnMouseClickInput(MouseInput input) { foreach (var widget in Widget.Widgets) { if (widget.Value.Visible) widget.Value.HandleMouseClickInput(input); } }
        public void OnMouseMovedInput(Vector2 input) { foreach (var widget in Widget.Widgets) { if (widget.Value.Visible) widget.Value.HandleMouseMovedInput(input); } }
    }
}
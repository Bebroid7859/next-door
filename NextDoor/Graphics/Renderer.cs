using SFML.Graphics;
using SFML.System;
using SFML.Window;
using NextDoor.Widgets;
using NextDoor.Input;

namespace NextDoor.Graphics
{
    public interface BackgroundGraphics
    {
        public void Underlay();
        public void Overlap();
    }

    public static class SfmlInputHandler
    {
        public static void ModifierKeys(object? sender, KeyEventArgs args) { Game.InputHandler.OnKeyInput(new KeyInput(args.Code.ToString())); }
        // public static void OnKeyInput(object? sender, TextEventArgs args) { Game.InputHandler.OnKeyInput(new KeyInput(args.Unicode)); }
        public static void OnMouseClickInput(object? sender, MouseButtonEventArgs args) { Game.InputHandler.OnMouseClickInput(new MouseInput(new Vector2(args.X, args.Y), args.Button.ToString())); }
        public static void OnMouseMoveInput(object? sender, MouseMoveEventArgs args) { Game.InputHandler.OnMouseMovedInput(new Vector2(args.X, args.Y)); }
        public static void OnMouseReleaseInput(object? sender, MouseButtonEventArgs args) { Game.InputHandler.OnMouseMovedInput(new Vector2(args.X, args.Y)); }
    }

    public static class Renderer
    {
        public static RenderWindow Window = new(new VideoMode(1200, 800), "Next Door", Styles.Titlebar);
        public static BackgroundGraphics BackgroundGraphics = new MenuGraphics();

        public static void Initialize()
        {
            Window.MouseButtonReleased += SfmlInputHandler.OnMouseReleaseInput;
            Window.MouseButtonPressed += SfmlInputHandler.OnMouseClickInput;
           // Window.TextEntered += SfmlInputHandler.OnKeyInput;
            Window.KeyPressed += SfmlInputHandler.ModifierKeys;
            Window.MouseMoved += SfmlInputHandler.OnMouseMoveInput;
            Game.Logger.Write(LogType.Info, "Правила рендеринга установлены.");
        }

        public static void Update()
        {
            BackgroundGraphics.Underlay();
            foreach (var widget in new Dictionary<string, Widget>(Widget.Widgets).Values)
            {
                if (widget.Shape is RectangleShape) Window.Draw((RectangleShape)widget.Shape);
                else Window.Draw((Text)widget.Shape);
            }
            BackgroundGraphics.Overlap();
            Window.DispatchEvents();
            Window.Display();
        }
    }
}
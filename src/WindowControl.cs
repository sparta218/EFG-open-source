using Godot;
using System;

public class WindowControl : Node2D
{
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("Window_fullscr"))
        {
            switch (OS.WindowFullscreen)
            {
                case true:
                    OS.WindowFullscreen = false;
                    break;
                case false:
                    OS.WindowFullscreen = true;
                    break;
            }
        }

        if (Input.IsActionJustPressed("Window_exit"))
        {
            GetTree().Quit();
        }
    }
}

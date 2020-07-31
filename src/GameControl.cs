using Godot;
using System;

public class GameControl : Node2D
{
    private bool Debugging = true;
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
            GetTree().Quit();

        if (Input.IsActionPressed("Game_FastForward") && Debugging)
            Engine.TimeScale = 7;
        else
            Engine.TimeScale = 1;
    }
}

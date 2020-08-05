using Godot;
using System;

public class DayNight : Node2D
{
    public AnimationPlayer AnimationPlayer;

    public bool Afternoon = true;
    [Export] public int TimeOfDay = 12;
    
    public override void _Ready()
    {
        this.AnimationPlayer = (AnimationPlayer) GetNode("AnimationPlayer");
        AnimationPlayer.Play("Day-Night");
    }

    public override void _Process(float delta)
    {
        if (TimeOfDay > 12)
            Afternoon = true;
        else
            Afternoon = false;
    }
}

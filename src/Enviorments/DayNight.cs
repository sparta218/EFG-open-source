using Godot;
using System;

public class DayNight : Node2D
{
    private AnimationPlayer AnimationPlayer;

    public bool Afternoon = true;
    [Export] public int TimeOfDay = 12;
    
    public override void _Ready()
    {
        this.AnimationPlayer = (AnimationPlayer) GetNode("AnimationPlayer");

        //DayTimeTimer.WaitTime = this.AnimationPlayer.CurrentAnimationPosition * this.AnimationPlayer.PlaybackSpeed / 12;
        //DayTimeTimer.Start();
    }

    public override void _Process(float delta)
    {
        if (TimeOfDay > 12)
            Afternoon = true;
        else
            Afternoon = false;
    }
}

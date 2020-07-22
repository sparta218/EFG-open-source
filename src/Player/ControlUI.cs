using Godot;
using System;

public class ControlUI : Control
{

    private RichTextLabel ClockLabel;
    private Player Player;
    
    public override void _Ready()
    {
        ClockLabel = (RichTextLabel) GetNode("Clock");
    }

    public override void _Process(float delta)
    {
        if(Player.TimeNode != null)
            ClockLabel.BbcodeText = $"{Player.TimeNode.Time}";
            GD.Print(Player.TimeNode.Time);
    }

    public void Init(Player Player)
    {
        this.Player = Player;
    }
}

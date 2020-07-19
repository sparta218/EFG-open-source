using Godot;
using System;
using EvilFarmingGame.Items.Tools;

public class FarmLand : Area2D
{

    private bool PlayerColliding = false;

    private AnimatedSprite Sprite;
    private Player PlayerBody;
    
    public enum states
    {
        UnCropped = 0,
        Cropped = 1,
        Planted = 2,
        Grown = 3
    }

    public states State;

    public override void _Ready()
    {
        Sprite = (AnimatedSprite) GetNode("Sprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        switch (State)
        {
            case states.UnCropped:
                Sprite.Play("UnCropped");
                break;
            case states.Cropped:
                Sprite.Play("Cropped");
                break;
            case states.Planted:
                Sprite.Play("Planted");
                break;
            case states.Grown:
                Sprite.Play("Grown");
                break;
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (PlayerColliding)
        {
            if (Input.IsActionJustPressed("Player_Action") && PlayerBody.Inventory[PlayerBody.Inventory.HeldSlot] == Tools.BasicHoe)
            {
                if (State == states.UnCropped)
                {
                    State++;
                }
            }
        }
    }

    public void OnCollison(PhysicsBody2D Body)
    {
        if (Body.GetType() == typeof(Player))
        {
            PlayerColliding = true;
            PlayerBody = (Player) GetNode(Body.GetPath());
        }
    }

    public void OnCollisonExited(PhysicsBody2D Body)
    {
        if (Body.GetType() == typeof(Player))
        {
            PlayerColliding = false;
        }
    }
    
    
}

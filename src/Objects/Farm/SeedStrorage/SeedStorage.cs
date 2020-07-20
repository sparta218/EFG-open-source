using Godot;
using System;
using EvilFarmingGame.Items;
using EvilFarmingGame.Player;

public class SeedStorage : Area2D
{

    private bool PlayerColliding;

    private Player PlayerBody;

    public override void _PhysicsProcess(float delta)
    {
        if (PlayerColliding)
        {   
            if(Input.IsActionJustPressed("Player_Action"))
                PlayerBody.Inventory.Gain(Seeds.TestSeed);
        }
    }

    public void OnCollision(PhysicsBody2D Body)
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
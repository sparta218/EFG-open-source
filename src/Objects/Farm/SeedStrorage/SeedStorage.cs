using Godot;
using System;

public class SeedStorage : Area2D
{

    private bool PlayerColliding;

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        if (PlayerColliding)
        {
            
        }
    }

    public void OnCollison(PhysicsBody2D Body)
    {
        if (Body.GetType() == typeof(Player))
        {
            PlayerColliding = true;
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
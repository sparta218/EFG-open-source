using Godot;
using System;
using EvilFarmingGame.Player;

public class Player : KinematicBody2D
{
    private PlayerController Controller;
    
    public override void _Ready()
    {
        Controller = new PlayerController(this);
    }

    public override void _PhysicsProcess(float delta)
    {
        Controller.InputMovement(delta);
    }
}

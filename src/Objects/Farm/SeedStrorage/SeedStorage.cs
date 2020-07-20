using Godot;
using System;
using EvilFarmingGame.Items;
using EvilFarmingGame.Player;

public class SeedStorage : Area2D
{

	public bool PlayerColliding;
	public Polygon2D OutLine;
	public Player PlayerBody;

	public override void _Ready(){
		OutLine = GetNode<Polygon2D>("OutLine");
		OutLine.Visible = false;
	}

	public override void _PhysicsProcess(float delta)
	{
		if (PlayerColliding)
		{   
			if(Input.IsActionJustPressed("Player_Action"))
				PlayerBody.Inventory.Gain(Seeds.TestSeed);
		}
		OutLine.Visible = false;
		PlayerColliding = false;
	}

	
}

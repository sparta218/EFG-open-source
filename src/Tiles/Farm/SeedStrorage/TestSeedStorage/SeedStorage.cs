using Godot;
using System;
using EvilFarmingGame.Items;
using EvilFarmingGame.Player;
using EvilFarmingGame.Tiles;

public class SeedStorage : InteractableTile
{
	[Export] private int Seed;

	public override void _Ready()
	{
		InitTile();
	}

	public override void _PhysicsProcess(float delta)
	{
		if (PlayerColliding)
		{
			if (Input.IsActionJustPressed("Player_Action")) 
				PlayerBody.Inventory.Gain(Seeds.GetSeed(Seed));
		}
		UpdateTile();
	}

	
}

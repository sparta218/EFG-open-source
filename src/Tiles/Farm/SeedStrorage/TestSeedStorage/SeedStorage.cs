using Godot;
using System;
using EvilFarmingGame.Items;
using EvilFarmingGame.Player;

public class SeedStorage : Area2D
{

	public bool PlayerColliding;
	public Sprite OutLine;
	public Player PlayerBody;

	[Export] private int Seed;

	public override void _Ready()
	{
		OutLine = (Sprite)GetNode("OutLine");
		OutLine.Visible = false;
	}

	public override void _PhysicsProcess(float delta)
	{
		if (PlayerColliding)
		{
			if (Seed != null)
			{
				if (Input.IsActionJustPressed("Player_Action"))
				{
					var CurSeed = Seeds.GetSeed(Seed);
					if (PlayerBody.Money >= CurSeed.Price)
					{
						PlayerBody.Inventory.Gain(CurSeed);
						PlayerBody.Money -= CurSeed.Price;
					}
				}
			}
		}
		OutLine.Visible = false;
		PlayerColliding = false;
	}

	
}

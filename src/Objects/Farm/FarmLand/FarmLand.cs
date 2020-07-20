using Godot;
using System;
using EvilFarmingGame.Items;
using EvilFarmingGame.Items.Tools;
using EvilFarmingGame.Objects.Farm.Plants;

public class FarmLand : Area2D
{

	public bool PlayerColliding = false;
	private AnimatedSprite Sprite;
	private Sprite PlantSeedling;
	private Sprite PlantGrown;
	public Polygon2D OutLine;
	public Player PlayerBody;
	private Plant CurrentPlant;
	
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
		PlantSeedling = (Sprite) GetNode("Plant/Seedling");
		PlantGrown = (Sprite) GetNode("Plant/Grown");
		OutLine = GetNode<Polygon2D>("OutLine");
		OutLine.Visible = false;
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
				PlantGrown.Hide();
				PlantSeedling.Show();
				break;
			case states.Grown:
				PlantGrown.Show();
				PlantSeedling.Hide();
				break;
		}

		if (CurrentPlant != null)
		{
			switch (CurrentPlant.ID)
			{
				case 0:
					PlantSeedling.Texture = CurrentPlant.SeedlingTexture;
					PlantGrown.Texture = CurrentPlant.GrownTexture;
					break;
			}
		}
		OutLine.Visible = false;
		PlayerColliding = false;
	}

	public override void _Input(InputEvent @event)
	{
		if (PlayerColliding)
		{
			if (Input.IsActionJustPressed("Player_Action"))
			{
				if (PlayerBody.Inventory.HeldSlot < PlayerBody.Inventory.Items.Count)
				{
					if (PlayerBody.Inventory[PlayerBody.Inventory.HeldSlot] == Tools.BasicHoe)
					{
						State = states.Cropped;
					}

					if (PlayerBody.Inventory[PlayerBody.Inventory.HeldSlot].Type == Item.Types.Seed)
					{
						if (State == states.Cropped)
						{
							State = states.Planted;
							switch (PlayerBody.Inventory[PlayerBody.Inventory.HeldSlot].ID)
							{
								case 0:
									CurrentPlant = Plants.TestPlant;
									PlayerBody.Inventory.Remove(PlayerBody.Inventory[PlayerBody.Inventory.HeldSlot]);
									break;
							}
						}
					}
				}
			}
		}
	}


	
	
}

using Godot;
using System;
using System.Collections.Generic;
using EvilFarmingGame.Items;
using EvilFarmingGame.Items.Tools;
using EvilFarmingGame.Player;

public class Player : KinematicBody2D
{
	private PlayerController Controller;
	public Inventory Inventory;

	private Node2D RayPivot;

	private RichTextLabel Clock;
	public DayNight TimeNode;

	private ResourcePreloader Loader = new ResourcePreloader();

	public override void _Ready()
	{
		Controller = new PlayerController(this);

		RayPivot = (Node2D) GetNode("RayPivot");
		Clock = (RichTextLabel) GetNode("UI/ControlUI/Clock");

		Inventory = new Inventory();
		Inventory.Items.Add(Tools.BasicHoe);

		TimeNode = (DayNight) GetNode("DayNight");
	}

	public override void _PhysicsProcess(float delta)
	{
		Controller.InputMovement(delta, RayPivot);
		InventoryHandling();
		RayCasting();
		TimeHandling();
	}

	public void InventoryHandling()
	{
		for (int i = 0; i < Inventory.Items.Count; i++)
		{
			Sprite Icon = (Sprite) GetNode($"UI/Inventory/Inventory Slot{i + 1}/Item");
			Sprite SelectBox = (Sprite) GetNode($"UI/Inventory/Inventory Slot{i + 1}/Selection");

			if (Inventory[i] != null)
				Icon.Texture = Inventory[i].Icon;
		}

		for (int i = 0; i < Inventory.Items.Capacity; i++)
		{
			Sprite Icon = (Sprite) GetNode($"UI/Inventory/Inventory Slot{i + 1}/Item");
			Sprite SelectBox = (Sprite) GetNode($"UI/Inventory/Inventory Slot{i + 1}/Selection");

			if (i == Inventory.HeldSlot)
				SelectBox.Show();
			else
				SelectBox.Hide();

			if (Inventory.Items.Count <= i)
			{
				Icon.Texture = (Texture) GD.Load("res://src/NoTexture.png");
			}
		}

		if (Input.IsActionJustPressed("ui_right"))
		{
			if (Inventory.HeldSlot < Inventory.Items.Capacity - 1)
				Inventory.HeldSlot++;
		}
		else if (Input.IsActionJustPressed("ui_left"))
		{
			if (Inventory.HeldSlot > 0)
				Inventory.HeldSlot--;
		}


	}

	public void RayCasting()
	{
		foreach (RayCast2D RayCast in GetTree().GetNodesInGroup("PlayerRays"))
		{

			var collidedTile = RayCast.GetCollider();

			switch (collidedTile)
			{
				case FarmLand tile:

					var collidedFarmLand = (FarmLand) collidedTile;

					collidedFarmLand.OutLine.Visible = true;
					collidedFarmLand.PlayerColliding = true;
					collidedFarmLand.PlayerBody = this;
					break;

				case SeedStorage tile:

					var collidedSeedStorage = (SeedStorage) collidedTile;

					collidedSeedStorage.OutLine.Visible = true;
					collidedSeedStorage.PlayerColliding = true;
					collidedSeedStorage.PlayerBody = this;
					break;

			}
			if (collidedTile != null) break;
		}

	}

	public void TimeHandling()
	{
		if(TimeNode.Afternoon)
			Clock.BbcodeText = $"{TimeNode.TimeOfDay -12} PM";
		else
			Clock.BbcodeText = $"{TimeNode.TimeOfDay} AM";
	}
}

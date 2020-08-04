using Godot;
using System;
using EvilFarmingGame.Items;
using EvilFarmingGame.Items.Crops;
public class SellingBooth : Area2D
{
	public bool PlayerColliding;
	public Sprite OutLine;
	public Item HeldItem;
	public Player PlayerBody;
	public override void _Ready()
	{
		OutLine = GetNode<Sprite>("OutLine");
		OutLine.Visible = false;
	}

	public override void _PhysicsProcess(float delta)
	{
		if(PlayerColliding && Input.IsActionJustPressed("Player_Action"))
		{
			HeldItem = PlayerBody.Inventory[PlayerBody.Inventory.HeldSlot];
			if(HeldItem.Type == Item.Types.Crop)
			{
				PlayerBody.Money += Crops.GetCrops(HeldItem.ID).Price;
				PlayerBody.Inventory.Remove(HeldItem);
			}
		}
		OutLine.Visible = false;
		PlayerColliding = false;
	}


}

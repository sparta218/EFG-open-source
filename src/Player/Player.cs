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
    
    private ResourcePreloader Loader = new ResourcePreloader();
    public override void _Ready()
    {
        Controller = new PlayerController(this);
        
        Inventory = new Inventory();
        Inventory.Items.Add(Tools.BasicHoe);
    }

    public override void _PhysicsProcess(float delta)
    {
        Controller.InputMovement(delta);
        InventoryHandling();
    }

    public void InventoryHandling()
    {
        for (int i = 0; i < Inventory.Items.Count; i++)
        {
            Sprite Icon = (Sprite) GetNode($"UI/Inventory/Inventory Slot{i+1}/Item");
            Sprite SelectBox = (Sprite) GetNode($"UI/Inventory/Inventory Slot{i+1}/Selection");
            
            if(Inventory[i] != null)
                Icon.Texture = Inventory[i].Icon;

            if (i == Inventory.HeldSlot)
                SelectBox.Show();
            else
                SelectBox.Hide();
        }
        
        if (Input.IsActionJustPressed("ui_right"))
        {
            if (Inventory.HeldSlot < Inventory.Items.Count -1)
                Inventory.HeldSlot++;
        }
        else if (Input.IsActionJustPressed("ui_left"))
        {
            if (Inventory.HeldSlot > 0)
                Inventory.HeldSlot--;
        }

    }
}

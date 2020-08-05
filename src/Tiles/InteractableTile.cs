using Godot;
using System;
using EvilFarmingGame;

namespace EvilFarmingGame.Tiles
{
    public class InteractableTile: Area2D
    {
        public Sprite OutLine;
        public bool PlayerColliding = false;
        public global::Player PlayerBody;
        
        public void InitTile()
        {
            OutLine = (Sprite) GetNode("OutLine");
            OutLine.Visible = false;
        }

        public void UpdateTile()
        {
            OutLine.Visible = false;
            PlayerColliding = false;
        }
    }
}
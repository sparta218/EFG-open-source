using System;

namespace EvilFarmingGame.Items.Tools
{
    public struct Tools
    {
        private static Item[] tools =
        {
            new Item("Basic Hoe", "res://src/Items/Tools/Hoe/Texture.png", "Not the fanciest but gets the job done", 0, Item.Types.Tool)
        };
        
        public static Item GetTool(int ID)
        {
            foreach (Item item in tools)
            {
                if (item.ID == ID)
                    return item;
            }

            Console.WriteLine("Cannot find Item by ID");
            return null;
        }
    }
}
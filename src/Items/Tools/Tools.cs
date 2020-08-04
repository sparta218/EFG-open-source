using System;

namespace EvilFarmingGame.Items.Tools
{
    public struct Tools
    {
        private static Item[] tools =
        {
            //Basic Hoe
            new Item("Basic Hoe", "res://src/Items/Tools/Hoe/Texture.png", "Not the fanciest but gets the job done", 0, Item.Types.Tool, 0),
            //Basic Watering Can
            new Item("Basic Watering Can", "res://src/Items/Tools/Watering Can/Texture.png", "A basic watering can", 1, Item.Types.Tool, 0)
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
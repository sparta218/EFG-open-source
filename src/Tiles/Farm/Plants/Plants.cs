using EvilFarmingGame.Items.Crops;

namespace EvilFarmingGame.Objects.Farm.Plants
{
    public struct Plants
    {
        public static Plant TestPlant = new Plant("Test Plant", "A Plant seed used for testing and debugging purposes", 0, "res://src/Tiles/Farm/Plants/TestPlant/Texture1.png", "res://src/Tiles/Farm/Plants/TestPlant/Texture2.png", Crops.TestCrop);
        public static Plant TestPlant2 = new Plant("Test Plant2", "A Plant seed used for testing and debugging purposes", 1, "res://src/Tiles/Farm/Plants/TestPlant2/Texture1.png", "res://src/Tiles/Farm/Plants/TestPlant2/Texture2.png", Crops.TestCrop2);
    }
}
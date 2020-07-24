using EvilFarmingGame.Items.Crops;

namespace EvilFarmingGame.Objects.Farm.Plants
{
    public struct Plants
    {
        public static Plant TestPlant = new Plant("Test Plant", "A Simple seed used for testing and debugging purposes", 0, "res://src/Tiles/Farm/Plants/TestPlant/Texture1.png", "res://src/Tiles/Farm/Plants/TestPlant/Texture2.png", Crops.TestCrop);
    }
}
using Godot;

namespace EvilFarmingGame.Items
{
    public class Item
    {
        public string Name;
        public string IconPath;
        public string Discription;
        public int ID;
        public Texture Icon;

        public Item(string Name, string IconPath, string Discription, int ID)
        {
            this.Name = Name;
            this.IconPath = IconPath;
            this.Discription = Discription;
            this.ID = ID;

            this.Icon = (Texture)GD.Load(IconPath);
        }
        
    }
}
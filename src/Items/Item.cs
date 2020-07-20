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
        public Types Type;

        public enum Types
        {    
            Misselaniuos = 0,
            Tool,
            Seed,
            
        }

        public Item(string Name, string IconPath, string Discription, int ID, Types Type)
        {
            this.Name = Name;
            this.IconPath = IconPath;
            this.Discription = Discription;
            this.ID = ID;
            this.Type = Type;

            this.Icon = (Texture)GD.Load(IconPath);
        }
        
    }
}
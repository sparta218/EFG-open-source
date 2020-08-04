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
		public int Price;

		public enum Types
		{    
			Miscellaneous = 0,
			Tool,
			Seed,
			Crop
		}

		public Item(string Name, string IconPath, string Discription, int ID, Types Type, int Price)
		{
			this.Name = Name;
			this.IconPath = IconPath;
			this.Discription = Discription;
			this.ID = ID;
			this.Type = Type;
			this.Price = Price;

			this.Icon = (Texture)GD.Load(IconPath);
		}
		
	}
}

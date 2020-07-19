namespace EvilFarmingGame.Objects.Farm.Plants
{
    public class Plant
    {
        public string Name { get { return Name;} set{} }
        public string Discription { get { return Name;} set{} }
        public int ID { get { return ID;} set{} }
        
        public Plant(string Name, string Discription, int ID)
        {
            this.Name = Name;
            this.Discription = Discription;
            this.ID = ID;
        }
        
    }
}
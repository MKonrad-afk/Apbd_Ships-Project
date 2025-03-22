namespace Apbd_miniProject01
{
    public class ProductType
    {
        public string Name{set;get;}
        public int LowestTemperature{set;get;}

        public ProductType(string name, int lowestTemperature)
        {
            Name = name;
            LowestTemperature = lowestTemperature;
        }

        public override string ToString()
        {
            return  Name + "," + LowestTemperature;
        }
    }
}
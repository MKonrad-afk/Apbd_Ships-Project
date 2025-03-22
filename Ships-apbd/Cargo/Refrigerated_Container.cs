using System;

namespace Apbd_miniProject01
{
    
    
    public class Refrigerated_Container : Container
    {
        public ProductType ProductTy;
        public int CargoTemperature;

        public Refrigerated_Container(double heightCm, double tareWeightKg, double depthCm, double maxPayloadKg) 
            : base(heightCm, tareWeightKg, depthCm, maxPayloadKg, ContainerType.R)
        {
        }

        public override string ToString()
        {
            if (ProductTy == null)
            {
                return base.ToString() +$"Lowest Temperature {CargoTemperature}"; 
            }
            return base.ToString() +$", Product Type: {ProductTy}, Lowest Temperature {CargoTemperature}"; 
        }
        public override void loadCargo(double massKg)
        {
            base.loadCargo(massKg);
            Console.WriteLine("Provide me with product type:\n" +
                              "Name: (e.g Bananas)");
            String nameOfProduct = Console.ReadLine();
            Console.WriteLine("Lowest temperature of this product Type");
            int lowestTemperature = int.Parse(Console.ReadLine());
            ProductTy = new ProductType(nameOfProduct, lowestTemperature);
            CargoTemperature = lowestTemperature;
        }
        
        public override string showCargo()
        {
            if (ProductTy == null)
            {
                return base.showCargo() + ": Empty";
            }
            return base.showCargo() + ": Contains-"+ProductTy + ": Cargo Temperature-" + CargoTemperature;
        }

        public override void emptyCargo()
        {
            base.emptyCargo();
            ProductTy = null;
            CargoTemperature = 0;

        }
    }

}
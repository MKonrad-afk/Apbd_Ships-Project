using System;

namespace Apbd_miniProject01
{
    public class Container
    {
        //sum of the weight
        public double MassKg { get;  set; }
        //cargo weight
        public double CargoWeightItself { get;  set; }
        //container weight
        public double TareWeightKg { get;  set; }
        //how much we can load
        public double MaxPayloadKg { get;  set; }
        
        public double HeightCm { get; set; }

        public double DepthCm { get; set; }

        public SerialNumber SerialNumber { get; }
        
        public Container(double heightCm, double tareWeightKg,double depthCm, double maxPayloadKg)
        {
            MassKg = tareWeightKg;
            HeightCm = heightCm;
            TareWeightKg = tareWeightKg;
            DepthCm = depthCm;
            MaxPayloadKg = maxPayloadKg;
            SerialNumber = SerialNumberRegister.generateSerialNUmber();
            Console.WriteLine($"You have created -> Serial Number: {SerialNumber}");
        }
        // Emptying the cargo
        public virtual void emptyCargo()
        {
            if (CargoWeightItself.Equals(0))
            {
                Console.WriteLine("Cargo is already empty");
            }
            else
            {
                MassKg = TareWeightKg;
                CargoWeightItself = 0;
            }
        }
        // if the mass of the cargo is greater than the capacity of a given container, we should throw an OverfillException error
        public virtual void loadCargo(double massKg)
        {
            if (!CargoWeightItself.Equals(0))
            {
                Console.WriteLine("Cargo is not empty!");
                return;
            }
            if (massKg > MaxPayloadKg)
            {
                throw new OverfillException();
            }

            CargoWeightItself += massKg;
            MassKg += massKg;
        }

        public override string ToString()
        {
            return "> Serial Nubmer- " + SerialNumber;
        }

        public virtual string showCargo()
        {
            return  "> Serial Number- " + SerialNumber + " : Cargo Itself" + CargoWeightItself + " kg, : Tare Weight- " +TareWeightKg +" kg, Height- "+ HeightCm + " cm, : Depth- " + DepthCm + " cm,: Max Pay Load- " + MaxPayloadKg+ " kg : Current mass- " + MassKg +" kg";
        }
    }

}
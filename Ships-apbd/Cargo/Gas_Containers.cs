using System;

namespace Apbd_miniProject01
{
    public class Gas_Containers : Container, IHazardNotifier
    {
        public double Pressure { get; private set; }

        public Gas_Containers( double heightCm, double tareWeightKg, double depthCm, double maxPayloadKg ) 
            : base(heightCm, tareWeightKg, depthCm, maxPayloadKg, ContainerType.G)
        {
        }
        
        public void checkPayload(double massKg)
        {   
            if (massKg > MaxPayloadKg)
            {
                throw new OverfillException();
            }
            
        }

        public override void emptyCargo()
        {
            base.emptyCargo();
            Pressure = 0;
        }

        public override void loadCargo(double massKg)
        {
            base.loadCargo(massKg);
            checkPayload(massKg);
            Console.WriteLine("Pressure in atmosphere:");
            Pressure = double.Parse(Console.ReadLine());
            if (Pressure > 1000)
            {
                NotifyHazard();
            }
        }

        public void NotifyHazard()
        {
            Console.WriteLine($"Hazardous event reported! Container Serial Number: {SerialNumber}");
        }

        public override string showCargo()
        {
           return base.showCargo() + ": Pressure-" + Pressure +" atmosphere";
        }
    }
}
using System;

namespace Apbd_miniProject01
{

    public class Liquid_Conteiners : Container, IHazardNotifier
    {
        CargoType CargoType {get;set; }

        public Liquid_Conteiners(double heightCm, double tareWeightKg, double depthCm, double maxPayloadKg) 
            : base(heightCm, tareWeightKg, depthCm, maxPayloadKg, ContainerType.L)
        {
            CargoType = CargoType.unknown;
        }

        public override void loadCargo(double massKg)
        {
            base.loadCargo(massKg);
            if (violationOfCargoPayload())
            {
                Console.WriteLine("Product type of the container (choose between 0 -> hazardous, 1 -> ordinary):");
                CargoType = (CargoType)int.Parse(Console.ReadLine());
                if (CargoType == CargoType.hazardous)
                {
                    MaxPayloadKg /= 2;
               
                }
                else if (CargoType == CargoType.ordinary)
                {
                    MaxPayloadKg *= 0.9;
                }
            }
            else
            {
                Console.WriteLine("I cannot load this cargo - it is too heavy!");
            }

        }

        public bool violationOfCargoPayload() 
        {
            if (CargoWeightItself > MaxPayloadKg)
            {
                Console.WriteLine($"Dangerous operation reported! Container Serial Number: {SerialNumber}\n" +
                                  $"You want to fiilled Cargo with Violation of the rules - Cargo weight too big!\n" +
                                  $"Max Payload Kg: {MaxPayloadKg}");
                return false;
            }
            return true;
        }

        public void NotifyHazard()
        {
            Console.WriteLine($"Hazardous event reported! Container Serial Number: {SerialNumber}");
        }
        
        public override string ToString()
        {
            return base.ToString() +": Cargo Type-" + CargoType;
        }
        
        public override string showCargo()
        {   
            
            return base.showCargo() + ": Cargo Type-" + CargoType;
        }
    }
}
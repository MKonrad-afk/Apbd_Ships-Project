using System;

namespace Apbd_miniProject01
{

    public class Liquid_Conteiners : Container, IHazardNotifier
    {
        CargoType CargoType {get;set; }

        public Liquid_Conteiners(double heightCm, double tareWeightKg, double depthCm, double maxPayloadKg) 
            : base(heightCm, tareWeightKg, depthCm, maxPayloadKg)
        {
            if (CargoType == CargoType.hazardous)
            {
                MaxPayloadKg = maxPayloadKg / 2;
               
            }
            else
            {
                MaxPayloadKg = maxPayloadKg * 0.9;
            }
        }

        public override void loadCargo(double massKg)
        {
            base.loadCargo(massKg);
            violationOfCargoPayload();
            Console.WriteLine("Product type of the container (choose between 0: hazardous, 1: ordinary):");
            CargoType = (CargoType)int.Parse(Console.ReadLine());

        }

        public void violationOfCargoPayload() 
        {
            if (CargoWeightItself > MaxPayloadKg)
            {
                Console.WriteLine($"Dangerous operation reported! Container Serial Number: {SerialNumber}\n" +
                                  $"You want to fiilled Cargo with Violation of the rules - Cargo weight too big!\n" +
                                  $"Max Payload Kg: {MaxPayloadKg}");
                return;
            }
        }

        public void NotifyHazard()
        {
            Console.WriteLine($"Hazardous event reported! Container Serial Number: {SerialNumber}");
        }
        
        public override string ToString()
        {
            return base.ToString() +$", CargoType: {CargoType} - Liquid Container";
        }
    }
}
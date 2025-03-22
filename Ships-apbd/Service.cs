using System.Collections.Generic;

namespace Apbd_miniProject01
{
    public static class Service
    {
        private static Dictionary<int, Container> accessibleContainers = new Dictionary<int, Container>();
        private static int counter = 0;
        private static int counter2 = 0;
        static Dictionary<int, Ship> ships = new  Dictionary<int, Ship>();

        public static Dictionary<int, Container> getAccessibleContainers()
        {
            return accessibleContainers;
        }

        public static int getCounter()
        {
            return counter;
        }

        private static Dictionary<int, Ship> getShips()
        {
            return ships;
        }

        public static void addShip()
        { 
            Console.WriteLine("Enter ship name: ");
            string shipName = Console.ReadLine();
            Console.WriteLine("Enter Max Speed of the ship in knots: ");
            double maxSpeed = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Max Container capacity of the ship : ");
            int containerCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Max Weight of the ship in kg: ");
            decimal maxWeight = decimal.Parse(Console.ReadLine());
            Ship ship =  new Ship(shipName, maxSpeed,containerCapacity, maxWeight);
            ships.Add(counter2++, ship);
        }
        public static void showAvailableContainers()
        {
            if (accessibleContainers.Count > 0)
            {   
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                foreach (var container in getAccessibleContainers())
                {
                    Console.WriteLine(container.Key + ": " + container.Value);
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            else
            {
                Console.WriteLine("There are no available containers.");
            }
        }
        
        public static void showAllShips()
        {    
            if(getShips().Count != 0){
                foreach (var ship in getShips())
                {
                    Console.WriteLine(ship.Key + ": " + ship.Value);
                }
            }
            else
            {
                Console.WriteLine("There are no ships");
            }
        }
        

        public static void createContainer(ContainerType containerType)
        {
            
            Console.WriteLine("To Load container give me following:" +
                              "\n Height of the container in cm:");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Depth of the container in cm:");
            double depth = double.Parse(Console.ReadLine());
            Console.WriteLine("Tare Weight of the container in kg:");
            double tareWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Max payload of the container in kg:");
            double maxPayload = double.Parse(Console.ReadLine());
            
            switch (containerType)
            {
                case ContainerType.R:
                    getAccessibleContainers().Add(counter + 1,new Refrigerated_Container(height, tareWeight, depth, maxPayload));
                    break;
                case ContainerType.G:
                    getAccessibleContainers().Add(counter + 1, new Gas_Containers(height, tareWeight, depth, maxPayload));
                    break;
                case ContainerType.L:
                    getAccessibleContainers().Add(counter + 1, new Liquid_Conteiners(height, tareWeight, depth, maxPayload));
                    break;
            }
        }

        public static void loadCargoINtoContainer()
        {   
            Console.WriteLine("To load cargo into a container type its number");
            showAvailableContainers();
            int choice = int.Parse(Console.ReadLine());
            if (accessibleContainers.ContainsKey(choice))
            {   
                Console.WriteLine("Provide me with the weight of the cargo in Kg");
                double weight = double.Parse(Console.ReadLine());
                accessibleContainers[choice].loadCargo(weight);
            }
            else
            {
                Console.WriteLine("Error: no accessible container found");
            }
              

        }

        public static void unloadCargoFromContainer()
        {
            showAllShips();
            Console.WriteLine("Enter ship number to unload container:");
            int shipNumber = int.Parse(Console.ReadLine());
            if (getShips().ContainsKey(shipNumber))
            {
                getShips()[shipNumber].unloadContainer();
            }
            else
            {
                Console.WriteLine("Invalid ship number.");
            }
        }
        public static void loadContainersOntoShip()
        {
            showAllShips();
            Console.WriteLine("Enter ship number to load containers onto:");
            int shipNumber = int.Parse(Console.ReadLine());
            if (getShips().ContainsKey(shipNumber))
            {
                getShips()[shipNumber].addContainerToShip();
            }
            else
            {
                Console.WriteLine("Invalid ship number.");
            }
        }

        public static void removeContainerFromShip()
        {
            showAllShips();
            Console.WriteLine("Enter ship number to remove Container:");
            int shipNumber = int.Parse(Console.ReadLine());
            if (getShips().ContainsKey(shipNumber))
            {
                getShips()[shipNumber].removeContainer();
            }
            else
            {
                Console.WriteLine("Invalid ship number.");
            }
        }


        public static void replaceContainerOnShip()
        {
            showAllShips();
            Console.WriteLine("Enter ship number to replace Containers with available one:");
            int shipNumber = int.Parse(Console.ReadLine());
            if (getShips().ContainsKey(shipNumber))
            {
                getShips()[shipNumber].replaceContainers();
            }
            else
            {
                Console.WriteLine("Invalid ship number.");
            }
        }

        public static void transferContainerBetweenShips()
        {
            showAllShips();
            Console.WriteLine("Enter source ship number:");
            int sourceShip = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter destination ship number:");
            int destShip = int.Parse(Console.ReadLine());
            if (getShips().ContainsKey(sourceShip) && getShips().ContainsKey(destShip))
            {
                Console.WriteLine("Enter container number to transfer:");
                int containerNumber = int.Parse(Console.ReadLine());
                var source = getShips()[sourceShip];
                var destination = getShips()[destShip];
                if (source.getContainers().ContainsKey(containerNumber))
                {
                    destination.addContainerToShip();
                    source.removeContainer();
                }
                else
                {
                    Console.WriteLine("Container not found in source ship.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ship numbers.");
            }
        }

        public static void PrintShipInfo()
        {
            if (accessibleContainers.Count > 0)
            {
                showAllShips();
                Console.WriteLine("Enter ship number to view details:");
                int shipNumber = int.Parse(Console.ReadLine());
                if (getShips().ContainsKey(shipNumber))
                {
                    getShips()[shipNumber].showMe();
                }
                else
                {
                    Console.WriteLine("Invalid ship number.");
                }
            }
        }

    }
}
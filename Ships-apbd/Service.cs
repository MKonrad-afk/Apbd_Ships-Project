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
        

        public static void createContainer()
        {
            Console.WriteLine("Provide me with the container Type:\n" +
                              "0 -> Refrigerated Containers\n" +
                              "1 -> Gas Containers\n" +
                              "2 -> Liquid Containers");
            int choice2 = int.Parse(Console.ReadLine());
            if (choice2 == 0 || choice2 == 1 || choice2 == 2){ 
                ContainerType containerType = (ContainerType)choice2;
                Console.WriteLine("To create container give me following:" +
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
                        counter++;
                        getAccessibleContainers().Add(counter,new Refrigerated_Container(height, tareWeight, depth, maxPayload));
                        break;
                    case ContainerType.G:
                        counter++;
                        getAccessibleContainers().Add(counter, new Gas_Containers(height, tareWeight, depth, maxPayload));
                        break;
                    case ContainerType.L:
                        counter++;
                        getAccessibleContainers().Add(counter, new Liquid_Conteiners(height, tareWeight, depth, maxPayload));
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }

        public static void loadCargoINtoContainer()
        {   
            if(accessibleContainers.Count > 0){
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
            else
            {
                Console.WriteLine("There are no available containers.");
            }
        }

        public static void unloadCargoFromContainer()
        {    
            if (getAccessibleContainers().Count > 0)
            {
                showAvailableContainers();
                Console.WriteLine("Enter container number to unload cargo from it:");
                int containerNumber = int.Parse(Console.ReadLine());
                if (getAccessibleContainers().ContainsKey(containerNumber))
                {
                   getAccessibleContainers()[containerNumber].emptyCargo();
                }
                else
                {
                    Console.WriteLine("Invalid container number.");
                }
            }
            else
            {
                Console.WriteLine("There are no containers");
            }
        }
        public static void loadContainersOntoShip()
        {
            if (getShips().Count > 0)
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
            else
            {
                Console.WriteLine("There are no ships");
            }
        }

        public static void removeContainerFromShip()
        {
            if (getShips().Count > 0)
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
            else
            {
                Console.WriteLine("There are no ships");
            }
        }


        public static void replaceContainerOnShip()
        {
            if (getShips().Count > 0)
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
            else
            {
                Console.WriteLine("There are no ships");
            }
        }

        public static void transferContainerBetweenShips()
        {
            if (getShips().Count > 0)
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
            else
            {
                Console.WriteLine("There are no ships");
            }
        }

        public static void printContainerINfo()
        {
            Console.WriteLine("Type which info you want to get:" +
                              "\n1. Container from the ship" +
                              "\n2. Container from available containers");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                if (getShips().Count > 0)
                {
                    showAllShips();
                    Console.WriteLine("Enter ship number to view details about the container:");
                    int shipNumber = int.Parse(Console.ReadLine());
                    if (getShips().ContainsKey(shipNumber))
                    {
                        Console.WriteLine("Enter container number to view it:");
                        getShips()[shipNumber].showContainers();
                        int containerNumber = int.Parse(Console.ReadLine());
                        if (getShips()[shipNumber].getContainers().ContainsKey(containerNumber))
                        {
                            getShips()[shipNumber].getContainers()[containerNumber].showCargo();
                        }
                        else
                        {
                            Console.WriteLine("Invalid container number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ship number.");
                    }   
                }
                else
                {
                    Console.WriteLine("There are no ships");
                }
            }
            else if (choice == 2)
            {
                if (getAccessibleContainers().Count > 0)
                {
                    Console.WriteLine("Enter container number to view it:");
                    showAvailableContainers();
                    int containerNumber = int.Parse(Console.ReadLine());
                    if (getAccessibleContainers().ContainsKey(containerNumber))
                    {
                        Console.WriteLine(getAccessibleContainers()[containerNumber].showCargo());
                    }
                    else
                    {
                        Console.WriteLine("Invalid container number.");
                    }
                }
                else
                {
                    Console.WriteLine("There are no accessible containers.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        public static void printShipInfo()
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
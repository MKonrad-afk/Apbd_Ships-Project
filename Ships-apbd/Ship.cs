using System;
using System.Collections.Generic;
using System.Linq;

namespace Apbd_miniProject01
{
    public enum ContainerType
    {
        R,
        G,
        L
    }
    public class Ship
    {
        Dictionary<int, Container> containers = new Dictionary<int, Container>();
        Dictionary<int, Container> accessibleContainers = Service.getAccessibleContainers();
        private static int counter0 = Service.getCounter();
        private static int counter1 = 0;

        private string name;
        public double MaxSpeed { get; set; }
        public int MaxContainersCapacity { get; private set; }
        public decimal MaxWeight { get; private set; }

        public Ship(double maxSpeed, int maxContainersCapacity, decimal maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainersCapacity = maxContainersCapacity;
            MaxWeight = maxWeight;
        }

        public void addContainerToShip()
        {
            if (MaxContainersCapacity < containers.Count)
            {
                if (accessibleContainers.Count() == 0)
                {
                    Console.WriteLine("No accessible containers!\n Load cargo into container first");
                }
                else
                {
                    Console.WriteLine("Info: you can see bellow the list of available containers" +
                                      "\nType its number to load a container onto a ship" +
                                      "\nTo load list of containers type their numbers spaceseparated in format <1 2 3 4>" +
                                      "\nYou cannot put twice the same container to the ship");
                    showAccessibleContainers();
                    String line = Console.ReadLine();
                    String[] splitted = line.Split(' ');
                    if (splitted.Length <= accessibleContainers.Count)
                    {
                        foreach (var word in splitted)
                        {
                            int choice = int.Parse(word);
                            if (accessibleContainers.ContainsKey(choice))
                            {
                                containers.Add(counter1++, accessibleContainers[choice]);
                                accessibleContainers.Remove(choice);
                            }
                            else
                            {
                                Console.WriteLine("Error: no accessible container found");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong number of accessible containers!");
                    }
                }


            }
            else
            {
                Console.WriteLine("You cannot add more containers.");
            }
            
        }

        public void createContainers(ContainerType containerType)
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
                    accessibleContainers.Add(counter0 + 1,new Refrigerated_Container(height, tareWeight, depth, maxPayload));
                    break;
                case ContainerType.G:
                    accessibleContainers.Add(counter0 + 1, new Gas_Containers(height, tareWeight, depth, maxPayload));
                    break;
                case ContainerType.L:
                    accessibleContainers.Add(counter0 + 1, new Liquid_Conteiners(height, tareWeight, depth, maxPayload));
                    break;
            }
        }
        public void loadCargoINtoContainer()
        {   
            Console.WriteLine("To load cargo into a container type its number");
            showAccessibleContainers();
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

        public void unloadContainer()
        {
            Console.WriteLine("Info: you can unload container by typing its number from the list bellow");
            showAccessibleContainers();
            int choice = int.Parse(Console.ReadLine());
            if (accessibleContainers.ContainsKey(choice))
            {
                accessibleContainers[choice].emptyCargo();
            }
            else
            {
                Console.WriteLine("Error: no accessible container found");
            }
        }

        public void removeContainer()
        {
            Console.WriteLine("To remove container from the ship, type its number");
            showContainers();
            int choice = int.Parse(Console.ReadLine());
            if (containers.ContainsKey(choice))
            {   
                Console.WriteLine("Proccesing with deleting the container:" + containers[choice] +
                                    "\nDo you want to move it to accessible containers?" +
                                    "\nFor yes type 1 for no 0");
                int choice1 = int.Parse(Console.ReadLine());
                if (choice1 == 1)
                {
                    accessibleContainers.Add(counter0++, containers[choice]);
                }
                containers.Remove(choice);
                Console.WriteLine("The container has been removed");
            }
            else
            {
                Console.WriteLine("No such container");
            }

            
        }

        public void showAccessibleContainers()
        {
            foreach (var container in accessibleContainers)
            {
                Console.WriteLine(container.Key + ": " + container.Value);
            }
        }

        public void replaceContainers()
        {
            Console.WriteLine("Info: First you will see containers on the ship" +
                              "\nType its number from the list bellow to choose it to replace with one from available container");
            showContainers();
            int choice0 = int.Parse(Console.ReadLine());
            if (!containers.ContainsKey(choice0))
            {
                Console.WriteLine("No such container, try again");
                replaceContainers();
            }
            Console.WriteLine("Info: NOw you will see the available containers." +
                              "\nTo choose one type its number");
            showAccessibleContainers();
            int choice1 = int.Parse(Console.ReadLine());
            if (!accessibleContainers.ContainsKey(choice1))
            {
                Console.WriteLine("No such container, try again");
                replaceContainers();
            }
            (accessibleContainers[choice1], containers[choice0]) = (containers[choice0], accessibleContainers[choice1]);
        }

        public void showContainers()
        {
            foreach (var container in containers)
            {
                Console.WriteLine(container.Key + ": " + container.Value);
            }
        }

        public void showMe()
        {
            Console.WriteLine(name + ", " + MaxSpeed + ", " + MaxContainersCapacity + ", " + MaxWeight + "\n");
            showContainers();
            Console.WriteLine("--------------------------------------------");
        }
    }
    
}
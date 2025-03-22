using System;
using System.Collections.Generic;

namespace Apbd_miniProject01
{
    public class AppItself
    {
        public static void Main(string[] args)
        {
            Console.Title = "Apbd_miniProject01";

            Console.WriteLine("\nWelcome to Shipping World!");
            while (true)
            {
                Console.WriteLine("\n--------------------------" +
                                  "\n1. See all ships" +
                                  "\n2. Add ship" +
                                  "\n3. See available containers" +
                                  "\n4. Create a container" +
                                  "\n5. Load cargo into a container" +
                                  "\n6. Load container(s) onto a ship" +
                                  "\n7. Remove a container from a ship" +
                                  "\n8. Unload a container" +
                                  "\n9. Replace a container on a ship" +
                                  "\n10. Transfer a container between ships" +
                                  "\n11. Print information about a ship" +
                                  "\n12. Exit"+
                                  "\n--------------------------");
                
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice)) continue;
                
                switch (choice)
                {
                    case 1:
                        Service.showAllShips();
                        break;
                    case 2:
                        
                        Service.addShip();
                        break;
                    case 3:
                        Service.showAvailableContainers();
                        break;
                    case 4:
                        Console.WriteLine("Provide me with the container Type:\n" +
                                          "1 -> Refrigerated Containers\n" +
                                          "2 -> Gas Containers\n" +
                                          "3 -> Liquid Containers");
                        ContainerType containerType = (ContainerType)int.Parse(Console.ReadLine());
                        Service.createContainer(containerType);
                        break;
                    case 5:
                        Service.loadCargoINtoContainer();
                        break;
                    case 6:
                        Service.loadContainersOntoShip();
                        break;
                    case 7:
                        Service.removeContainerFromShip();
                        break;
                    case 8:
                        Service.unloadCargoFromContainer();
                        break;
                    case 9:
                        Service.replaceContainerOnShip();
                        break;
                    case 10:
                        Service.transferContainerBetweenShips();
                        break;
                    case 11:
                        Service.PrintShipInfo();
                        break;
                    case 12:
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        

    }
}

using System;
using System.Collections.Generic;

namespace Apbd_miniProject01
{
    public class AppItself
    {
        public static void Main(string[] args)
        {
            Console.Title = "Apbd_miniProject01";

            Console.WriteLine("\nWelcome to Shipping World!\n" +
                              "         __/___        " +
                              "\n   _____/______|       " +
                              "\n   \\             |      " +
                              "\n~~~~\\______________~~~~" +
                              "\n~~~~~~~~~~~~~~~~~~~~~~~~" );
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

                if (!int.TryParse(Console.ReadLine(), out var choice)) continue;
                
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
                        Service.createContainer();
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
                        break;
                    case 13:
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

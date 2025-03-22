using System;

namespace Apbd_miniProject01
{
    public class AppItself
    {
        public static void Main(string[] args)
        {
            Console.Title = "Apbd_miniProject01";
            Console.WriteLine("Welcome into Shipping world!" +
                              "\n--------------------------" +
                              "\nType number to move between functionalities" +
                              "\n--------------------------" +
                              "\n1. To see all ships" +
                              "\n2. To see available containers" +
                              "\n3. To exit the app");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Info: To open ship type its number");
                    foreach (var ship in Service.getShips())
                    {
                        Console.WriteLine(ship.Key + ": " + ship.Value);
                    }
                    int choice2 =int.Parse(Console.ReadLine());
                    

                   
                    break;
                case 2:
                    break;
                case 3:
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
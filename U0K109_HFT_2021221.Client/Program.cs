using System;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Load..");
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:21980");
            
            
            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();
            string choice = "";
            while (choice!="Quit")
            {
                Console.WriteLine("Apple menu");
                Console.WriteLine("\n1. AppleService");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. AppleProduct");
                Console.WriteLine("4. Quit");
                Console.Write("\nYour choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                    default:
                        break;
                }
            }
        }
        //AppleService
        static void AppleServiceOption()
        {
            RestService rest = new RestService("http://localhost:21980");
            Console.WriteLine("Apple menu/AppleService");
            Console.WriteLine("\n1.Get all data from the database regarding the Apple services. ");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. AppleProduct");
            Console.WriteLine("4. Quit");
            Console.Write("\nYour choice: ");
            string choice2 = Console.ReadLine();
            switch (choice2)
            {
                case "1":
                    var result=rest.Get<AppleService>("AppleService");
                    Console.WriteLine("Apple services and details:");
                    foreach (var item in result)
                    {
                        Console.WriteLine("Apple service's name: "+item.ServiceName+"\n");
                        Console.WriteLine("Apple service's ID: " + item.ServiceID + "\n");
                        Console.WriteLine("Apple service's location: " + item.Location + "\n");
                        Console.WriteLine("Apple service's products: " + item.Products + "\n");
                        Console.WriteLine("Apple service's customers: " + item.Customers + "\n");

                    }
                    break;
                case

                default:
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Z_02;

class Program
{
    static List<ShipContainer> ships = new List<ShipContainer>();
    static List<ContainerGeneral> containers = new List<ContainerGeneral>();
    ShipManagement shipManagement = new ShipManagement();
    bool exit = false;

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Dodaj kontener chłodniczy");
            Console.WriteLine("3. Dodaj kontener na płyny");
            Console.WriteLine("4. Dodaj kontener na gaz");
            Console.WriteLine("5. Znajdź kontener po numerze seryjnym");
            Console.WriteLine("6. Załaduj kontener na statek");
            Console.WriteLine("7. Wyświetl statki i kontenery");
            Console.WriteLine("8. Wyjście");

            Console.Write("\nWybierz opcję: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShipManagement.AddShip();
                    break;
                case "2":
                    ContainerFactory.CreateColdContainer();
                    break;
                case "3":
                    ContainerFactory.CreateLiquidContainer();
                    break;
                case "4":
                    ContainerFactory.CreateGasContainer();
                    break;
                case "5":
                    ShipManagement.FindContainerBySerialNumber(null);
                    break;
                case "6":
                    ShipManagement.LoadContainerOntoShip();
                    break;
                case "7":
                    ShipManagement.DisplayShipsAndContainers();
                    break;
                case "8":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }
}

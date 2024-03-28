using System;
using System.Collections.Generic;
using Z_02;

class Program
{
    bool exit = false;

    static void Main(string[] args)
    {
        ColdContainer coldContainer1 = new ColdContainer(1000, 250, 200, 500, 12000, "Banany", 13.3);
        ColdContainer coldContainer2 = new ColdContainer(1000, 250, 200, 500, 24000, "Mięso", -15);

        LiquidContainer liquidContainer1 = new LiquidContainer(1500, 300, 250, 600, 33000, true);
        LiquidContainer liquidContainer2 = new LiquidContainer(1500, 300, 250, 600, 30000, false);

        GasContainer gasContainer1 = new GasContainer(2000, 350, 300, 700, 18000, 100);
        GasContainer gasContainer2 = new GasContainer(2000, 350, 300, 700, 24000, 150);

        ContainerGeneral.allContainers.AddRange(new ContainerGeneral[]
            { coldContainer1, coldContainer2, liquidContainer1, liquidContainer2, gasContainer1, gasContainer2 });

        ContainerShip ship1 = new ContainerShip(22, 240000, 300000, "statek1");
        ContainerShip ship2 = new ContainerShip(25, 150000, 22000, "statek2");

        ship1.AddContainerOntoShip(coldContainer1);
        ship1.AddContainerOntoShip(liquidContainer1);
        ship2.AddContainerOntoShip(gasContainer1);
        ship2.AddContainerOntoShip(coldContainer2);

        // Dodajemy statki do globalnej listy statków
        ShipManagement.ships.AddRange(new ContainerShip[] { ship1, ship2 });

        var isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Dodaj kontener ");
            Console.WriteLine("3. Załaduj ładunek do kontenera");
            Console.WriteLine("4. Rozładuj kontener");
            Console.WriteLine("5. Znajdź kontener po numerze seryjnym");
            Console.WriteLine("6. Załaduj kontener na statek");
            Console.WriteLine("7. Załaduj listę kontenerów na statek");
            Console.WriteLine("8. Usunięcie kontenera ze statku");
            Console.WriteLine("9. Usuń kontener ze statku");
            Console.WriteLine("10. Zastąp kontener na statku");
            Console.WriteLine("11.Przenieś kontener między statkami");
            Console.WriteLine("12. Info o danym kontenerze");
            Console.WriteLine("13. Info o statku i jego ładunku");
            Console.WriteLine("14. Wyjście");

            Console.Write("\nWybierz opcję: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShipManagement.AddShip();
                    break;
                case "2":
                    ContainerFactory.CreateContainer();
                    break;
                case "3":
                    ContainerManagement.LoadCargoToSelectedContainer();
                    break;
                case "4":
                    ContainerManagement.UnloadCargoFromSelectedContainer();
                    break;
                case "5":
                    ContainerManagement.ContainerInfoBySerialNumber();
                    break;
                case "6":
                    ShipManagement.LoadContainerOntoShip();
                    break;
                case "7":
                    ShipManagement.LoadContainerListOntoShip();
                    break;
                case "8":
                    ShipManagement.RemoveContainerFromShip();
                    break;
                case "9":
                    ContainerShip.ReplaceContainer();
                    break;
                case "10":
                    ContainerShip.TransferContainerBetweenShips();
                    break;
                case "11":
                    ShipManagement.DisplayShipsAndContainers();
                    break;
                case "12":
                    ContainerShip.DisplayShipInfo();
                    break;
                case "13":
                    ContainerShip.ReplaceContainer();
                    break;
                case "14":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }
}
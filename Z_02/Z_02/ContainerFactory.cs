using System;
using System.Collections.Generic;

namespace Z_02
{
    public  class ContainerFactory
    {
        public static ContainerGeneral CreateContainer(string containerType)
        {
            switch (containerType.ToUpper())
            {
                case "COLD":
                    return CreateColdContainer();
                case "LIQUID":
                    return CreateLiquidContainer();
                case "GAS":
                    return CreateGasContainer();
                default:
                    throw new ArgumentException("Nieznany typ kontenera.");
            }
        }

        public static ColdContainer CreateColdContainer()
        {
            Console.WriteLine("Tworzenie kontenera chłodniczego:");
            Console.Write("Podaj typ produktu: ");
            string productType = Console.ReadLine();
            Console.Write("Podaj temperaturę kontenera: ");
            double containerTemp = double.Parse(Console.ReadLine());

            // Przykładowe wartości dla innych parametrów, które normalnie też powinny być pobierane od użytkownika
            double weight = 1000, height = 200, netWeight = 100, depth = 200;
            double maxCapacity = 5000;

            return new ColdContainer(weight, height, netWeight, depth, maxCapacity, productType, containerTemp);
        }

        public static LiquidContainer CreateLiquidContainer()
        {
            Console.WriteLine("Tworzenie kontenera na płyny:");
            Console.Write("Czy ładunek jest niebezpieczny? (tak/nie): ");
            bool isDangerous = Console.ReadLine().Trim().ToLower() == "tak";

            // Przykładowe wartości dla innych parametrów
            double weight = 1200, height = 250, netWeight = 150, depth = 250;
            double maxCapacity = 6000;

            return new LiquidContainer(weight, height, netWeight, depth, maxCapacity,isDangerous);
        }

        public static GasContainer CreateGasContainer()
        {
            Console.WriteLine("Tworzenie kontenera na gaz:");
            Console.Write("Podaj ciśnienie gazu: ");
            int pressure = int.Parse(Console.ReadLine());

            // Przykładowe wartości dla innych parametrów
            double weight = 950, height = 180, netWeight = 90, depth = 180;
            double maxCapacity = 4500;

            return new GasContainer(weight, height, netWeight, depth, maxCapacity, pressure);
        }
    }
}


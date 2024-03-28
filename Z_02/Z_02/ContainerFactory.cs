using System;
using System.Collections.Generic;

namespace Z_02
{
    public class ContainerFactory
    {
        public static void CreateContainer()
        {
            Console.WriteLine("Wybierz rodzaj kontenera:");
            Console.WriteLine("1. Kontener chłodniczy");
            Console.WriteLine("2. Kontener na płyny");
            Console.WriteLine("3. Kontener na gaz");
            Console.Write("Twój wybór: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var coldContainer = CreateColdContainer();
                    Console.WriteLine("Dodano kontener chłodniczy.");
                    break;
                case "2":
                    var liquidContainer = CreateLiquidContainer();
                    Console.WriteLine("Dodano kontener na płyny.");
                    break;
                case "3":
                    var gasContainer = ContainerFactory.CreateGasContainer();
                    Console.WriteLine("Dodano kontener na gaz.");
                    break;
                default:
                    Console.WriteLine("Nieznany wybór. Spróbuj ponownie.");
                    break;
            }
        }
    


    public static ColdContainer CreateColdContainer()
        {
            var productNames = new List<string>
            {
                "Banany",
                "Czekolada",
                "Ryby",
                "Mięso",
                "Lody",
                "Mrożona pizza",
                "Ser",
                "Kiełbasa",
                "Masło",
                "Jajka",
                "Inne"
            };
            
            Console.WriteLine("Tworzenie kontenera chłodniczego:");
            Console.Write("Podaj numer produktu:" +
                          "\n1.Banany" +
                          "\n2.Czekolada" +
                          "\n3.Ryby" +
                          "\n4.Mięso" +
                          "\n5.Lody" +
                          "\n6.Mrożona pizza"+
                          "\n7.Ser" +
                          "\n8.Kiełbasa" +
                          "\n9.Masło" +
                          "\n10.Jajka" +
                          "\n11.Inne"+
                          "\nTwój wybór: ");
            int choice = int.Parse(Console.ReadLine());
            string selectedProductName;
            double temperature=0;
            // Sprawdzamy, czy wybór mieści się w zakresie listy
            if (choice == 11)
            {
                Console.Write("Podaj nazwę produktu: ");
                selectedProductName = Console.ReadLine();
                Console.Write("Podaj temperaturę kontenera: ");
                temperature = double.Parse(Console.ReadLine());
            }
            if (choice >= 1 && choice <= productNames.Count-1)
            {
                selectedProductName = productNames[choice - 1];

                // Sprawdzamy, czy słownik zawiera wybrany produkt
                if (ColdContainer.productTypeMap.TryGetValue(selectedProductName, out temperature))
                {
                    Console.WriteLine($"Wybrano: {selectedProductName}, Temperatura: {temperature}°C");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono temperatury dla wybranego produktu.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór.");
            }
            double weight = 33000, height = 300, netWeight = 2200, depth = 2000;
            double maxCapacity = 5000;

            return new ColdContainer(weight, height, netWeight, depth, maxCapacity, productNames[choice - 1], temperature);
        }

        public static LiquidContainer CreateLiquidContainer()
        {
            Console.WriteLine("Tworzenie kontenera na płyny:");
            Console.Write("Czy ładunek jest niebezpieczny? (tak/nie): ");
            bool isDangerous = Console.ReadLine().Trim().ToLower() == "tak";
            double weight = 1200, height = 250, netWeight = 150, depth = 250;
            double maxCapacity = 6000;

            return new LiquidContainer(weight, height, netWeight, depth, maxCapacity,isDangerous);
        }

        public static GasContainer CreateGasContainer()
        {
            Console.WriteLine("Tworzenie kontenera na gaz:");
            Console.Write("Podaj ciśnienie gazu: ");
            int pressure = int.Parse(Console.ReadLine());
            double weight = 950, height = 180, netWeight = 90, depth = 180;
            double maxCapacity = 4500;

            return new GasContainer(weight, height, netWeight, depth, maxCapacity, pressure);
        }
    }
}


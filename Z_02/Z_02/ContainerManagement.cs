namespace Z_02;

public class ContainerManagement : ContainerGeneral
{
    public static void LoadCargoToSelectedContainer()
    {
    
        Console.Write("Podaj numer seryjny kontenera: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Podaj wagę ładunku do załadowania (kg): ");
        double weight = double.Parse(Console.ReadLine());

        
        var container = ContainerGeneral.allContainers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container != null)
        {
            try
            {
                container.LoadContainer(weight);
                Console.WriteLine($"Ładunek został załadowany. Obecne obciążenie: {container.currentLoad} kg. Wolne miejsce: {container.maxCapacity - container.currentLoad} kg.");

                var ship = ShipManagement.ships.FirstOrDefault(s => s.containers.Any(c => c.serialNumber == serialNumber));
                if (ship != null)
                {
                    Console.WriteLine($"Kontener znajduje się na statku: {ship.name}.");
                }
                else
                {
                    Console.WriteLine("Kontener znajduje się na placu.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }

    public ContainerManagement(double weight, double height, double netWeight, double depth, string serialNumber, double maxCapacity) : base(weight, height, netWeight, depth, serialNumber, maxCapacity)
    {
    }
}
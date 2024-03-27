namespace Z_02;

public class ShipManagement
{
    public static List<ShipContainer> ships { get; private set; } = new List<ShipContainer>();
    public static List<ContainerGeneral> containers { get; private set; } = new List<ContainerGeneral>();


    public static void AddShip()
    {
        Console.WriteLine("Podaj maksymalną prędkość statku (w węzłach):");
        double maxSpeed = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną liczbę kontenerów:");
        int maxLoad = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną wagę wszystkich kontenerów (w tonach):");
        double maxTotalWeight = double.Parse(Console.ReadLine());

        ShipContainer ship = new ShipContainer(maxSpeed, maxLoad, maxTotalWeight);
        ships.Add(ship);
        Console.WriteLine("Dodano kontenerowiec.");
    }

       
public static void LoadContainerOntoShip()
    {
       
        Console.WriteLine("Wybierz kontener do załadowania (podaj numer):");
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Kontener typu {ContainerGeneral.containers[i].GetType().Name}, Numer seryjny: {ContainerGeneral.containers[i].serialNumber}");
        }

        int containerIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Wybierz statek (podaj numer):");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Statek, Maksymalna liczba kontenerów: {ships[i].maxLoad}, Obecnie załadowane kontenery: {ships[i].containers.Count}");
        }

        int shipIndex = int.Parse(Console.ReadLine()) - 1;

        try
        {
            ships[shipIndex].AddContainer(ContainerGeneral.containers[containerIndex]);
            Console.WriteLine("Kontener został pomyślnie załadowany na statek.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie udało się załadować kontenera: {e.Message}");
        }
    }

    public static void DisplayShipsAndContainers()
    {
        // Wyświetl statki i kontenery
        Console.WriteLine("Statki:");
        foreach (var ship in ships)
        {
            Console.WriteLine($"Statek: Maksymalna prędkość {ship.maxSpeed} węzłów, Maksymalna liczba kontenerów: {ship.maxLoad}, Maksymalna waga: {ship.maxTotalWeight} ton");
            foreach (var container in ship.containers)
            {
                Console.WriteLine($"\tKontener: Typ: {container.GetType().Name}, Numer seryjny: {container.serialNumber}, Waga: {container.weight}");
            }
        }

        Console.WriteLine("\nDostępne kontenery:");
        foreach (var container in ContainerGeneral.containers.Where(c => !ships.Any(s => s.containers.Contains(c))))
        {
            Console.WriteLine($"Kontener: Typ: {container.GetType().Name}, Numer seryjny: {container.serialNumber}, Waga: {container.weight}");
        }
    }
    
    public static ContainerGeneral FindContainerBySerialNumber(string serialNumber)
    {
        return containers.FirstOrDefault(c => c.serialNumber == serialNumber);
    }

    public List<ContainerGeneral> FindContainersByType(Type containerType)
    {
        return containers.Where(c => c.GetType() == containerType).ToList();
    }
}
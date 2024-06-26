namespace Z_02;

public class ShipManagement
{
    public static List<ContainerShip> ships { get; private set; } = [];
    public static List<ContainerGeneral> containersOnShip { get; private set; } = [];

    public static void AddShip()
    {
        Console.WriteLine("Podaj maksymalną prędkość statku (w węzłach):");
        var maxSpeed = double.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj maksymalną liczbę kontenerów:");
        var maxLoad = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj maksymalną wagę wszystkich kontenerów (w tonach):");
        var maxTotalWeight = double.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Podaj nazwe statku:");
        var name = Console.ReadLine();
        if (name != null)
        {
            var containerShip = new ContainerShip(maxSpeed, maxLoad, maxTotalWeight, name);
            ships.Add(containerShip);
        }

        Console.WriteLine("Dodano kontenerowiec.");
    }


    public static void LoadContainerOntoShip()
    {
        Console.WriteLine("Podaj numer seryjny kontenera do załadowania:");
        var serialNumber = Console.ReadLine();


        var containerToLoad = ContainerGeneral.allContainers.FirstOrDefault(c =>
            c.serialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        if (containerToLoad == null)
        {
            Console.WriteLine($"Nie znaleziono kontenera o numerze seryjnym: {serialNumber}.");
            return;
        }


        Console.WriteLine("Wybierz statek (podaj numer):");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. Statek {ships[i].name}, Maksymalna liczba kontenerów: {ships[i].maxLoad}, Obecnie załadowane kontenery: {ships[i].containers.Count}, Obecne obciążenie: {ships[i].currentLoad} ton");
        }

        var shipIndex = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
        if (shipIndex < 0 || shipIndex >= ships.Count)
        {
            Console.WriteLine("Wybrano nieprawidłowy numer statku.");
            return;
        }

        var ship = ships[shipIndex];


        if (ship.containers.Count >= ship.maxLoad || ship.currentLoad + containerToLoad.weight > ship.maxTotalWeight)
        {
            Console.WriteLine(
                "Nie można załadować kontenera: przekroczono limit masy lub liczby kontenerów na statku.");
            return;
        }

        ship.containers.Add(containerToLoad);
        ship.currentLoad += containerToLoad.weight;

        Console.WriteLine($"Kontener {serialNumber} został pomyślnie załadowany na statek {ship.name}.");
    }

    public static void RemoveContainerFromShip()
    {
        Console.WriteLine("Wybierz statek (podaj numer):");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. Statek {ships[i].name}, Obecnie załadowane kontenery: {ships[i].containers.Count}, Obecne obciążenie: {ships[i].currentLoad} ton");
        }

        var shipIndex = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
        if (shipIndex < 0 || shipIndex >= ships.Count)
        {
            Console.WriteLine("Wybrano nieprawidłowy numer statku.");
            return;
        }

        var ship = ships[shipIndex];


        Console.WriteLine($"Wybierz kontener do usunięcia z {ship.name} (podaj numer seryjny):");
        foreach (var container in ship.containers)
        {
            Console.WriteLine(
                $"Numer seryjny: {container.serialNumber}, Typ: {container.GetType().Name}, Waga: {container.weight}");
        }

        var serialNumber = Console.ReadLine();

        var containerToRemove =
            ship.containers.FirstOrDefault(c =>
                c.serialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        if (containerToRemove == null)
        {
            Console.WriteLine(
                $"Kontener o numerze seryjnym {serialNumber} nie został znaleziony na statku {ship.name}.");
            return;
        }

        ship.containers.Remove(containerToRemove);
        ship.currentLoad -= containerToRemove.weight;
        Console.WriteLine($"Kontener {serialNumber} został usunięty ze statku {ship.name}.");
    }

    public static void DisplayShipsAndContainers()
    {
        Console.WriteLine("Statki:");
        foreach (var ship in ships)
        {
            Console.WriteLine(
                $"Statek: Maksymalna prędkość {ship.maxSpeed} węzłów, Maksymalna liczba kontenerów: {ship.maxLoad}, Maksymalna waga: {ship.maxTotalWeight} ton");
            foreach (var container in ship.containers)
            {
                Console.WriteLine(
                    $"\tKontener: Typ: {container.GetType().Name}, Numer seryjny: {container.serialNumber}, Waga: {container.weight}");
            }
        }

        Console.WriteLine("\nDostępne kontenery:");
        foreach (var container in ContainerGeneral.allContainers.Where(c => !ships.Any(s => s.containers.Contains(c))))
        {
            Console.WriteLine(
                $"Kontener: Typ: {container.GetType().Name}, Numer seryjny: {container.serialNumber}, Waga: {container.weight}");
        }
    }

    public static void LoadContainerListOntoShip()
    {
        Console.WriteLine("Wybierz statek (podaj numer):");
        for (int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Statek {ships[i].name}, Maksymalna liczba kontenerów: {ships[i].maxLoad}, " +
                              $"Obecnie załadowane kontenery: {ships[i].containers.Count}, Obecne obciążenie: {ships[i].currentLoad} ton");
        }

        var shipIndex = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
        if (shipIndex < 0 || shipIndex >= ships.Count)
        {
            Console.WriteLine("Wybrano nieprawidłowy numer statku.");
            return;
        }

        var ship = ships[shipIndex];
        LoadContainersOntoSelectedShip(ship);
    }

    private static void LoadContainersOntoSelectedShip(ContainerShip ship)
    {
        List<ContainerGeneral> selectedContainers = [];
        Console.WriteLine("Dostępne kontenery do załadunku (maksymalnie 10):");

        var count = 0;
        foreach (var container in ContainerGeneral.allContainers.Where(c => !ship.containers.Contains(c)))
        {
            Console.WriteLine(
                $"{++count}. Kontener typu {container.GetType().Name}, Numer seryjny: {container.serialNumber}");
        }

        while (selectedContainers.Count < 10)
        {
            Console.WriteLine("Wybierz kontener do dodania do listy załadunku (lub wpisz 'koniec', aby zakończyć):");
            var input = Console.ReadLine();
            if (input?.ToLower() == "koniec") break;

            if (int.TryParse(input, out var containerIndex) && containerIndex <= count && containerIndex > 0)
            {
                selectedContainers.Add(ContainerGeneral.allContainers[containerIndex - 1]);
                Console.WriteLine(
                    $"Dodano kontener {ContainerGeneral.allContainers[containerIndex - 1].serialNumber} do listy.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
            }
        }

        CheckAndLoadContainers(ship, selectedContainers);
    }

    private static void CheckAndLoadContainers(ContainerShip ship, List<ContainerGeneral> selectedContainers)
    {
        var totalWeight = selectedContainers.Sum(c => c.weight);
        if (ship.containers.Count + selectedContainers.Count > ship.maxLoad ||
            ship.currentLoad + totalWeight > ship.maxTotalWeight)
        {
            Console.WriteLine(
                "Nie można załadować wybranych kontenerów na statek: przekroczono limit masy lub liczby kontenerów.");
            return;
        }

        foreach (var container in selectedContainers)
        {
            ship.containers.Add(container);
            ship.currentLoad += container.weight;
        }

        Console.WriteLine("Wybrane kontenery zostały pomyślnie załadowane na statek.");
    }
}
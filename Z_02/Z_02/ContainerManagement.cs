namespace Z_02;

public class ContainerManagement
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
                Console.WriteLine(
                    $"Ładunek został załadowany. Obecne obciążenie: {container.currentLoad} kg. Wolne miejsce: {container.maxCapacity - container.currentLoad} kg.");

                var ship = ShipManagement.ships.FirstOrDefault(s =>
                    s.containers.Any(c => c.serialNumber == serialNumber));
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

    public static void UnloadCargoFromSelectedContainer()
    {
        Console.Write("Podaj numer seryjny kontenera: ");
        string serialNumber = Console.ReadLine();

        var container = ContainerGeneral.allContainers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container != null)
        {
            Console.WriteLine(
                $"Aktualne obciążenie kontenera: {container.currentLoad} kg. Wolne miejsce: {container.maxCapacity - container.currentLoad} kg.");

            Console.Write("Czy chcesz rozładować kontener całkowicie? (y/n): ");
            string fullUnload = Console.ReadLine().ToLower();

            if (fullUnload == "y")
            {
                try
                {
                    container.ClearContainer();
                    Console.WriteLine("Kontener został całkowicie rozładowany.");

                    DisplayContainerLocation(container);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił problem: {ex.Message}");
                }
            }
            else
            {
                Console.Write("Podaj wagę ładunku do rozładowania (kg): ");
                double weightToUnload = double.Parse(Console.ReadLine());

                if (weightToUnload > container.currentLoad)
                {
                    Console.WriteLine("Nie można rozładować więcej niż jest załadowane.");
                }
                else
                {
                    try
                    {
                        container.UnloadContainer(weightToUnload);
                        Console.WriteLine(
                            $"Ładunek został rozładowany. Pozostałe obciążenie: {container.currentLoad} kg. Wolne miejsce: {container.maxCapacity - container.currentLoad} kg.");

                        DisplayContainerLocation(container);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Wystąpił problem: {ex.Message}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }

    private static void DisplayContainerLocation(ContainerGeneral container)
    {
        var ship = ShipManagement.ships.FirstOrDefault(s => s.containers.Contains(container));
        if (ship != null)
        {
            Console.WriteLine($"Kontener znajduje się na statku: {ship.name}.");
        }
        else
        {
            Console.WriteLine("Kontener znajduje się na placu.");
        }
    }

    public static void DisplayContainerDetails(ContainerGeneral container)
    {
        
        string containerType = container.GetType().Name;

        
        Console.WriteLine($"Typ kontenera: {containerType}");
        Console.WriteLine($"Numer seryjny: {container.serialNumber}");
        Console.WriteLine($"Obecne obciążenie: {container.currentLoad} kg");
        Console.WriteLine($"Maksymalna pojemność: {container.maxCapacity} kg");
        DisplayContainerLocation(container);
    }

    public static void ContainerInfoBySerialNumber()
    {
        Console.Write("Podaj serial number kontenera: ");
        string serialNumber = Console.ReadLine().ToLower();
        var container = ContainerGeneral.allContainers.FirstOrDefault(c => c.serialNumber.ToLower() == serialNumber);

        if (container != null)
        {
            DisplayContainerDetails(container);
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }

    }


    public List<ContainerGeneral> FindContainersByType(Type containerType)
{
    return ContainerGeneral.allContainers.Where(c => c.GetType() == containerType).ToList();
}
    public static class ContainerLoader
    {
        public static List<ContainerGeneral> containersToLoad = new List<ContainerGeneral>();

        public static void AddContainerToLoadList(string serialNumber)
        {
            var container = ContainerGeneral.allContainers.FirstOrDefault(c => c.serialNumber == serialNumber);
            if (container != null)
            {
                containersToLoad.Add(container);
                Console.WriteLine($"Kontener {serialNumber} dodany do listy załadunku.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
            }
        }
    }

}
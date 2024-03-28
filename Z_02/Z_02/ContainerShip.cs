using System.ComponentModel.Design.Serialization;

namespace Z_02;

public class ContainerShip
{


    public double maxSpeed;
    public int maxLoad;
    public double maxTotalWeight;
    public string name;
    public double currentLoad { get; set; } = 0;
    public List<ContainerGeneral> containers { get; private set; } = new List<ContainerGeneral>();


    public ContainerShip(double maxSpeed, int maxLoad, double maxTotalWeight, string name)
    {
        this.maxSpeed = maxSpeed;
        this.maxLoad = maxLoad;
        this.maxTotalWeight = maxTotalWeight;
        this.name = name;

    }

    public void AddContainerOntoShip(ContainerGeneral container)
    {

        if (containers.Count >= maxLoad)
        {
            throw new InvalidOperationException("Cannot add more containers: maximum capacity reached.");
        }

        double totalWeight = containers.Sum(c => c.weight + c.netWeight) + container.weight + container.netWeight;
        if (totalWeight > maxTotalWeight)
        {
            throw new InvalidOperationException("Cannot add the container: exceeding maximum weight capacity.");
        }

        containers.Add(container);
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.serialNumber.ToString() == serialNumber);
        if (container != null)
        {
            containers.Remove(container);
        }
        else
        {
            throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
        }
    }

    public void LoadCargoToContainer(string serialNumber, double weight)
    {
        var container = containers.FirstOrDefault(c => c.serialNumber.ToString() == serialNumber);
        if (container != null)
        {
            container.LoadContainer(weight);
        }
        else
        {
            throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
        }
    }


    public static void ReplaceContainer()
    {
       
        Console.WriteLine("Wybierz statek, na którym chcesz zamienić kontener:");
        for (int i = 0; i < ShipManagement.ships.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ShipManagement.ships[i].name}");
        }

        int shipChoice;
        if (!int.TryParse(Console.ReadLine(), out shipChoice) || shipChoice < 1 || shipChoice > ShipManagement.ships.Count)
        {
            Console.WriteLine("Nieprawidłowy wybór statku.");
            return;
        }

        var selectedShip = ShipManagement.ships[shipChoice - 1];

        
        Console.WriteLine("Wybierz kontener do zamiany:");
        for (int i = 0; i < selectedShip.containers.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {selectedShip.containers[i].serialNumber} ({selectedShip.containers[i].GetType().Name})");
        }

        int containerChoice;
        if (!int.TryParse(Console.ReadLine(), out containerChoice) || containerChoice < 1 ||
            containerChoice > selectedShip.containers.Count)
        {
            Console.WriteLine("Nieprawidłowy wybór kontenera.");
            return;
        }

        var oldContainer = selectedShip.containers[containerChoice - 1];

        
        Console.WriteLine("Wybierz nowy kontener:");
        var availableContainers = ContainerGeneral.allContainers.Except(selectedShip.containers).ToList();
        for (int i = 0; i < availableContainers.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {availableContainers[i].serialNumber} ({availableContainers[i].GetType().Name})");
        }

        int newContainerChoice;
        if (!int.TryParse(Console.ReadLine(), out newContainerChoice) || newContainerChoice < 1 ||
            newContainerChoice > availableContainers.Count)
        {
            Console.WriteLine("Nieprawidłowy wybór nowego kontenera.");
            return;
        }

        var newContainer = availableContainers[newContainerChoice - 1];

        
        int index = selectedShip.containers.IndexOf(oldContainer);
        if (index != -1)
        {
            selectedShip.containers[index] = newContainer;
            Console.WriteLine(
                $"Kontener {oldContainer.serialNumber} został zamieniony na {newContainer.serialNumber} na statku {selectedShip.name}.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera do zamiany.");
        }
    }



    public static void TransferContainerBetweenShips()
    {
        
        Console.WriteLine("Wybierz statek źródłowy (podaj numer):");
        for (int i = 0; i < ShipManagement.ships.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ShipManagement.ships[i].name}");
        }

        int sourceShipIndex = int.Parse(Console.ReadLine()) - 1;
        var sourceShip = ShipManagement.ships[sourceShipIndex];

     
        Console.WriteLine($"Wybierz kontener do przeniesienia ze statku {sourceShip.name} (podaj numer):");
        for (int i = 0; i < sourceShip.containers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sourceShip.containers[i].serialNumber}");
        }

        int containerChoice = int.Parse(Console.ReadLine()) - 1;
        var containerToTransfer = sourceShip.containers[containerChoice];

        
        Console.WriteLine("Wybierz statek docelowy (podaj numer):");
        for (int i = 0; i < ShipManagement.ships.Count; i++)
        {
            if (i != sourceShipIndex) 
            {
                Console.WriteLine($"{i + 1}. {ShipManagement.ships[i].name}");
            }
        }

        int targetShipIndex = int.Parse(Console.ReadLine()) - 1;
        var targetShip = ShipManagement.ships[targetShipIndex];

 
        if (targetShip.containers.Count < targetShip.maxLoad && targetShip.currentLoad + containerToTransfer.weight <= targetShip.maxTotalWeight)
        {
            sourceShip.containers.Remove(containerToTransfer);
            sourceShip.currentLoad -= containerToTransfer.weight;

            targetShip.containers.Add(containerToTransfer);
            targetShip.currentLoad += containerToTransfer.weight;

            Console.WriteLine($"Kontener {containerToTransfer.serialNumber} został przeniesiony ze statku {sourceShip.name} na statek {targetShip.name}.");
        }
        else
        {
            Console.WriteLine("Nie można przenieść kontenera: przekroczono limit masy lub liczby kontenerów na statku docelowym.");
        }
    }



public static void DisplayShipInfo()
{
    var ships = ShipManagement.ships;
            // Wyświetlanie listy dostępnych statków
            Console.WriteLine("Dostępne statki:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i].name}");
            }

            // Prośba o wybór statku
            Console.WriteLine("Wybierz numer statku, aby zobaczyć szczegółowe informacje:");
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex < 0 || shipIndex >= ships.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór.");
                return;
            }

            var ship = ships[shipIndex];

            
            Console.WriteLine($"Statek: {ship.name}, Maksymalna prędkość: {ship.maxSpeed} węzłów, Maksymalna liczba kontenerów:" +
                              $" {ship.maxLoad}, Maksymalna waga: {ship.maxTotalWeight} ton, Obecne obciążenie: {ship.currentLoad} ton");

            
            if (ship.containers.Any())
            {
                foreach (var container in ship.containers)
                {
                    Console.WriteLine($"Kontener: Typ = {container.GetType().Name}, Serial = {container.serialNumber}, Waga = {container.weight}");
                }
            }
            else
            {
                Console.WriteLine("Na statku nie ma obecnie załadowanych kontenerów.");
            }
        }

    

public override string ToString()
{
    return $"Container Ship: Max Speed = {maxSpeed} knots, Max Containers = {containers.Count()}, Max Weight = {maxTotalWeight} tons, Currently Loaded Containers = {containers.Count}";
}
}


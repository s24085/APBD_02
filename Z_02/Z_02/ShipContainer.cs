using System.ComponentModel.Design.Serialization;

namespace Z_02;

public class ShipContainer
{
   
   
    public double maxSpeed;
    public int maxLoad;
    public double maxTotalWeight;
    public List<ContainerGeneral> containers { get; private set; } = new List<ContainerGeneral>();

    public ShipContainer(double maxSpeed, int maxLoad, double maxTotalWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxLoad = maxLoad;
        this.maxTotalWeight = maxTotalWeight;
    }
    
    public void AddContainer(ContainerGeneral container)
    {
       
    if (containers.Count >= maxLoad)
    {
        throw new InvalidOperationException("Cannot add more containers: maximum capacity reached.");
    }

    double totalWeight = containers.Sum(c => c.weight + c.netWeight) + container.weight + container.netWeight;
        if (totalWeight > maxTotalWeight ) //w tonach
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
        container.LoadContainer (weight);
    }
    else
    {
        throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
    }
}

public void UnloadCargoFromContainer(string serialNumber)
{
    var container = containers.FirstOrDefault(c => c.serialNumber.ToString() == serialNumber);
    if (container != null)
    {
        container.ClearContainer();
    }
    else
    {
        throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
    }

    void ReplaceContainer(ContainerGeneral oldContainer, ContainerGeneral newContainer)
    {
        int index =containers.IndexOf(oldContainer);
        if (index != -1)
        {
            containers[index] = newContainer;
        }
        else
        {
            throw new InvalidOperationException("Nie znaleziono kontenera do zamiany.");
        }
    }


    static void TransferContainer(ShipContainer fromShip, ShipContainer toShip, ContainerGeneral container)
    {
        fromShip.RemoveContainer(container.serialNumber);
        toShip.AddContainer(container);
    }


    void DisplayShipInfo()
    {
        Console.WriteLine(
            $"Statek: Max Speed = {maxSpeed} knots, Max Containers = {maxLoad}, Max Weight = {maxTotalWeight} tons");
        foreach (var container in containers)
        {
            Console.WriteLine(
                $"Kontener: Typ = {container.GetType().Name}, Serial = {container.serialNumber}, Weight = {container.weight}");
        }
    }
}

public override string ToString()
{
    return $"Container Ship: Max Speed = {maxSpeed} knots, Max Containers = {containers.Count()}, Max Weight = {maxTotalWeight} tons, Currently Loaded Containers = {containers.Count}";
}
}


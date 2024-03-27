namespace Z_02;

public class ShipContainer
{
    public List<ContainerGeneral> Containers { get; private set; } = new List<ContainerGeneral>();
    public double maxSpeed;
    public int maxLoad;
    public double maxTotalWeight;

    public ShipContainer(double maxSpeed, int maxLoad, double maxTotalWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxLoad = maxLoad;
        this.maxTotalWeight = maxTotalWeight;
    }
    public void AddContainer(ContainerGeneral container)
    {
       
    if (Containers.Count >= maxLoad)
    {
        throw new InvalidOperationException("Cannot add more containers: maximum capacity reached.");
    }

    double totalWeight = Containers.Sum(c => c.weight + c.netWeight) + container.weight + container.netWeight;
        if (totalWeight > maxTotalWeight * 1000) // Convert MaxWeight from tons to kilograms for comparison
    {
        throw new InvalidOperationException("Cannot add the container: exceeding maximum weight capacity.");
    }

    Containers.Add(container);
}

public void RemoveContainer(string serialNumber)
{
    var container = Containers.FirstOrDefault(c => c.serialNumber.ToString() == serialNumber);
    if (container != null)
    {
        Containers.Remove(container);
    }
    else
    {
        throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
    }
}

public void LoadCargoToContainer(string serialNumber, double weight)
{
    var container = Containers.FirstOrDefault(c => c.serialNumber.ToString() == serialNumber);
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
    var container = Containers.FirstOrDefault(c => c.serialNumber.ToString() == serialNumber);
    if (container != null)
    {
        container.ClearContainer();
    }
    else
    {
        throw new InvalidOperationException($"Container with serial number {serialNumber} not found.");
    }
}

public override string ToString()
{
    return $"Container Ship: Max Speed = {maxSpeed} knots, Max Containers = {Containers.Count()}, Max Weight = {maxTotalWeight} tons, Currently Loaded Containers = {Containers.Count}";
}
}


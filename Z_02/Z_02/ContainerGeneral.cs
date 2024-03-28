namespace Z_02;

public abstract class ContainerGeneral
{
    public double weight { get; protected set; }
    public double height { get; private set; }
    public double netWeight { get; private set; }
    public double depth { get; private set; }
    public string serialNumber { get; private set; }
    public double maxCapacity { get; protected set; }
    public double currentLoad { get; protected set; }
    public static List<ContainerGeneral> allContainers = new List<ContainerGeneral>();

    protected ContainerGeneral(double weight, double height, double netWeight, double depth, string serialNumber,
        double maxCapacity)
    {
        this.weight = weight;
        this.height = height;
        this.netWeight = netWeight;
        this.depth = depth;
        this.serialNumber = serialNumber;
        this.maxCapacity = maxCapacity;
        this.currentLoad = 0;
        allContainers.Add(this);
    }

    public void LoadContainer(double weight)
    {
        if (this.currentLoad + weight > this.maxCapacity)
        {
            throw new InvalidOperationException("Próba przeciążenia kontenera.");
        }

        this.currentLoad += weight;

    }
    public  void ClearContainer()
    {
        this.currentLoad = 0;
    }
    public void UnloadContainer(double weight)
    {
        if (weight > this.currentLoad)
        {
            throw new InvalidOperationException("Próba rozładowania więcej niż aktualne obciążenie.");
        }
        this.currentLoad -= weight;
    }
}
namespace Z_02;

public abstract class ContainerGeneral
{
    public double weight { get; protected set;}
    public double height{ get; private set;}
    public double netWeight{ get; private set;}
    public double depth{ get; private set;}
    public string serialNumber{ get; private set;}
    public double maxCapacity{ get; protected set;}
    public static List<ContainerGeneral> containers = new List<ContainerGeneral>();
    protected ContainerGeneral(double weight, double height, double netWeight, double depth,string serialNumber, double maxCapacity)
    {
        this.weight = weight;
        this.height = height;
        this.netWeight = netWeight;
        this.depth = depth;
        this.serialNumber = serialNumber;
        this.maxCapacity = maxCapacity;
        containers.Add(this);
    }
    

    public abstract void LoadContainer(double weight);
    public abstract void ClearContainer();
    public abstract void AddContainer();
}
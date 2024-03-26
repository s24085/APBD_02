namespace Z_02;

abstract class ContainerGeneral
{
    public double weight { get; protected set;}
    public double height{ get; private set;}
    public double netWeight{ get; private set;}
    public double depth{ get; private set;}
    public SerialNumber serialNumber{ get; private set;}
    public double maxCapacity{ get; private set;}

    protected ContainerGeneral(double weight, double height, double netWeight, double depth, SerialNumber serialNumber, double maxCapacity)
    {
        this.weight = weight;
        this.height = height;
        this.netWeight = netWeight;
        this.depth = depth;
        this.serialNumber = serialNumber;
        this.maxCapacity = maxCapacity;
    }

    public abstract void LoadContainer(double weight);
    public abstract void ClearContainer();
}
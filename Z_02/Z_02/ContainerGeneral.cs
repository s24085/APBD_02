namespace Z_02;

public class ContainerGeneral
{
    private double weight;
    private double height;
    private double netWeight;
    private double depth;
    private SerialNumber serialNumber;
    private double maxCapacity;
    

    void ClearContainer(ContainerGeneral container)
    {
        this.weight = weight - weight;
    }

    double LoadContainer(ContainerGeneral container)
    {
        if (container.maxCapacity < weight)
            throw new Exception("Overfill Exception");
        double NewWeight= container.maxCapacity - container.weight;
        return weight;
    }

    public double getWeight()
    {
        return weight;
    }
}
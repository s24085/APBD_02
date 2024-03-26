namespace Z_02;

public class Container
{
    private double weight;
    private double height;
    private double netWeight;
    private double depth;
    private SerialNumber serialNumber;
    private double maxCapacity;
    

    private void ClearContainer(Container container)
    {
        this.weight = weight - weight;
    }

    private double LoadContainer(Container container)
    {
        if (container.maxCapacity < weight)
            throw new Exception("Overfill Exception");
        double NewWeight= container.maxCapacity - container.weight;
        return weight;
    }
}